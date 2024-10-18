using QuizSystemAPI.Models;
using QuizSystemAPI.DTO;
namespace QuizSystemAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
