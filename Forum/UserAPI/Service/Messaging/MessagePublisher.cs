using System.Collections;
using System.Collections.Generic;
using EasyNetQ;
using SharedModels;

namespace UserAPI.Service.Messaging
{
    public class MessagePublisher: IMessagePublisher
    {
        private IBus bus;

        public MessagePublisher(string connectionString)
        {
            bus = RabbitHutch.CreateBus(connectionString);
        }

        public void Dispose()
        {
            bus.Dispose();
        }

        public IEnumerable<QuestionDto> GetQuestionByUserIdMessage(int id)
        {
            var request = new GetQuestionsMessage {UserId = id};
            var response = bus.Rpc.Request<GetQuestionsMessage, List<QuestionDto>>(request);
            return response;
        }
    }
}