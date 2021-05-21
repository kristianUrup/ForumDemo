using System;

namespace QuestionAPI
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}