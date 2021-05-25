using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RestSharp;
using SharedModels;
using UserAPI.Repository;

namespace QuestionAPI.Service.Implementation
{
    public class QuestionService: IQuestionService
    {
        private IRepository<Question> _questionRepo;

        public QuestionService(IRepository<Question> questionRepo)
        {
            _questionRepo = questionRepo;
        }
        public IEnumerable<QuestionDto> GetAllByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Create(QuestionDto entity)
        {
            throw new System.NotImplementedException();
        }

        public QuestionDto GetById(int id)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("http://answerapi/answers/GetAllAnswersByQuestionId/");
            var request = new RestRequest(id.ToString(), Method.GET);
            var answersToQuestion = c.Execute<List<AnswerDto>>(request).Data;
            var converter = new ConvertDtoHelper();
            Question question = _questionRepo.GetById(id);
            QuestionDto questionDto = converter.ConvertToDto(question, answersToQuestion);
            return questionDto;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}