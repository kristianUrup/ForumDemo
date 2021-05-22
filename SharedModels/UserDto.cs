using System.Collections.Generic;

namespace SharedModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
