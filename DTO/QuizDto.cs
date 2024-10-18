using System.Collections.Generic;
using QuizSystemAPI.DTO; 
namespace QuizSystemAPI.DTO
{
    public class QuizCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}