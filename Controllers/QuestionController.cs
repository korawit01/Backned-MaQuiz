using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizSystemAPI.Models;
using QuizSystemAPI.Data; // นำเข้า namespace ที่มี DbContext
using QuizSystemAPI.DTO;
namespace QuizSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.Include(q => q.Answers).ToListAsync();
        }

        // GET: api/question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.Include(q => q.Answers)
                                                    .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // POST: api/question
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(QuestionDto dto) // เปลี่ยนชื่อพารามิเตอร์จาก question เป็น dto
        {
            // แปลงจาก QuestionDto เป็น Question
            var question = new Question
            {
                Text = dto.Text, // แก้ไขการอ้างถึงตัวแปร dto
                Answers = dto.Answers.Select(a => new Answer
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };

            // เพิ่ม question เข้าไปใน context
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            // คืนค่า question ที่ถูกสร้างใหม่
            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        // PUT: api/question/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
