using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Quizzes.Commands.DeleteQuiz;
using QuizApp.Application.Quizzes.Queries.GetAllQuizzes;
using QuizApp.Application.Quizzes.Queries.GetQuiz;
using QuizApp.Views;

namespace QuizApp.Controllers;

[Route("api/quizzes")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly ISender _sender;

    public QuizController(ISender sender)
    {
        _sender = sender;
    }

    // GET: api/<QuizController>
    [HttpGet]
    [Produces(typeof(IEnumerable<QuizDTO>))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllQuizzesQuery();
            
        var result = await _sender.Send(query);

        var dtos = new List<QuizDTO>();
        foreach(var question in result)
        {
            var dto = (QuizDTO)question;
            dtos.Add(dto);
        }
        
        return Ok(dtos);
    }
    
    // GET api/<QuizController>/5
    [HttpGet("{id}")]
    [Produces(typeof(QuizDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetQuizQuery
        {
            Id = id
        };

        var result = await _sender.Send(query);

        if (result is null)
            return NotFound();
        return Ok((QuizDTO)result);
    }

    // POST api/<QuizController>
    [HttpPost]
    [Produces(typeof(QuizDTO))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateQuizCommand command)
    {
        var result = await _sender.Send(command);

        int id = result.Id;

        return CreatedAtAction(nameof(Get), new { id }, (QuizDTO)result);
    }

    // // PUT api/<QuizController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<QuizController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteQuizCommand
        {
            Id = id
        };

        await _sender.Send(command);

        return NoContent();
    }
}