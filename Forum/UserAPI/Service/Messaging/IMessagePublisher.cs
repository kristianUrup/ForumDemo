using System.Collections.Generic;
using SharedModels;

namespace UserAPI.Service.Messaging
{
    public interface IMessagePublisher
    {
        public IEnumerable<QuestionDto> GetQuestionByUserIdMessage(int id);
    }
}