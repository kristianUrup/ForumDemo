using System;

namespace AnswerAPI
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}