using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.QuizResults.Commands.CreateQuiz;
using QuizApp.Application.QuizResults.Commands.DeleteQuizResult;
using QuizApp.Application.QuizResults.Queries.GetQuizResult;
using QuizApp.Application.QuizResults.Queries.GetQuizResultsByQuiz;
using QuizApp.Views;

namespace QuizApp.Controllers;

[Route("api/quiz-results")]
[ApiController]
public class QuizResultController : ControllerBase
{
    private readonly ISender _sender;

    public QuizResultController(ISender sender)
    {
        _sender = sender;
    }
        
    // GET: api/by-quiz/<QuizResultController>
    [HttpGet("by-quiz/{quizId}")]
    [Produces(typeof(IEnumerable<QuizResultDTO>))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByQuiz(int quizId)
    {
        var query = new GetQuizResultsByQuizQuery()
        {
            QuizId = quizId
        };
            
        var result = await _sender.Send(query);

        var dtos = new List<QuizResultDTO>();
        foreach(var question in result)
        {
            var dto = (QuizResultDTO)question;
            dtos.Add(dto);
        }
        
        return Ok(dtos);
    }

    // GET api/<QuizResultController>/5
    [HttpGet("{id}")]
    [Produces(typeof(QuizResultDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetQuizResultQuery
        {
            Id = id
        };
            
        var result = await _sender.Send(query);

        if (result is null)
            return NotFound();

        return Ok((QuizResultDTO)result);
    }

    // POST api/<QuizResultController>
    [HttpPost]
    [Produces(typeof(QuizResultDTO))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateQuizResultCommand command)
    {
        var result = await _sender.Send(command);

        int id = result.Id;
            
        return CreatedAtAction(nameof(Get), new { id }, (QuizResultDTO)result);
    }

    // // PUT api/<QuizResultController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<QuizResultController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteQuizResultCommand
        {
            Id = id
        };

        await _sender.Send(command);

        return NoContent();
    }
}