using QuizSystemAPI.DTO;
using System.Collections.Generic;
namespace QuizSystemAPI.DTO
{
    public class QuestionDto
    {
        public string Text { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}