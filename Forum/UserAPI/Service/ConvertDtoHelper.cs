using System.Collections.Generic;
using SharedModels;

namespace UserAPI.Service
{
    public class ConvertDtoHelper
    {
        public UserDto ConvertToUserDto(User user, IEnumerable<QuestionDto> questions, IEnumerable<AnswerDto> answers)
        {
            return new()
            {
                Id = user.Id,
                Answers = answers,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Questions = questions,
                Username = user.Username
            };
        }
    }
}