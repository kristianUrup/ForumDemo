using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using QuestionAPI.Service;
using SharedModels;
using UserAPI.Repository;

namespace QuestionAPI.Repository
{
    public class MessageListener
    {
        private IServiceProvider _service;
        private string _connectionString;

        public MessageListener(IServiceProvider service, string connectionString)
        {
            _service = service;
            _connectionString = connectionString;
        }

        public void Start()
        {
            using (var bus = RabbitHutch.CreateBus(_connectionString))
            {
                bus.Rpc.Respond<GetQuestionsMessage, List<QuestionDto>>(request => {
                    return HandleGetQuestionsMessage(request).ToList();
                });
                
                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
            
            
        }

        private IEnumerable<QuestionDto> HandleGetQuestionsMessage(GetQuestionsMessage getQuestionsMessage)
        {
            using (var scope = _service.CreateScope())
            {
                var services = scope.ServiceProvider;
                var questionRepository = services.GetService<IRepository<Question>>();
                var converter = new ConvertDtoHelper();

                var questionDtos = new List<QuestionDto>();
                var questions = questionRepository.GetAllByUserId(getQuestionsMessage.UserId);
                foreach (var question in questions)
                {
                    var answers = new List<AnswerDto>();
                    questionDtos.Add(converter.ConvertToDto(question,answers));
                }

                return questionDtos;
            }
        }
        
    }
}