using QuizSystemAPI.Models;
using QuizSystemAPI.DTO; 
namespace QuizSystemAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; } // กำหนดว่าเป็นคำตอบที่ถูกต้องหรือไม่
    }
}
