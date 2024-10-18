using System.Collections.Generic; 
using QuizSystemAPI.Models;
using QuizSystemAPI.DTO; 

namespace QuizSystemAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
    }
}
