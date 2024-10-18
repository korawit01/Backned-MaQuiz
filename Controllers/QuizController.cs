using Microsoft.AspNetCore.Mvc;
using QuizSystemAPI.DTO;
[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
    private static List<Quiz> Quizzes = new List<Quiz>();

    [HttpGet]
    public ActionResult<List<Quiz>> Get()
    {
        return Ok(Quizzes);
    }

    [HttpPost]
    public ActionResult<Quiz> Create(Quiz newQuiz)
    {
        newQuiz.Id = Quizzes.Count + 1;
        Quizzes.Add(newQuiz);
        return CreatedAtAction(nameof(Get), new { id = newQuiz.Id }, newQuiz);
    }
}

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
