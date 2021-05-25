using System.Collections;
using System.Collections.Generic;
using SharedModels;

namespace QuestionAPI.Service
{
    public class ConvertDtoHelper
    {
        public QuestionDto ConvertToDto(Question question, IEnumerable<AnswerDto> answers)
        {
            return new QuestionDto
            {
                Answers = answers,
                Created = question.Created,
                Description = question.Description,
                Id = question.Id,
                Title = question.Title,
                UserId = question.UserId
            };
        }
    }
}