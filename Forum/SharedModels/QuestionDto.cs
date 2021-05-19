using System;
using System.Collections;
using System.Collections.Generic;

namespace SharedModels
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        private IEnumerable<AnswerDto> Answers { get; set; }
    }
}