using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.QuizSubmissions.Commands.CreateQuizSubmission;
using QuizApp.Application.QuizSubmissions.Commands.DeleteQuizSubmission;
using QuizApp.Application.QuizSubmissions.Queries.GetQuizSubmission;
using QuizApp.Application.QuizSubmissions.Queries.GetQuizSubmissionsByQuiz;
using QuizApp.Views;

namespace QuizApp.Controllers;

[Route("api/quiz-submissions")]
[ApiController]
public class QuizSubmissionController : ControllerBase
{
    private readonly ISender _sender;

    public QuizSubmissionController(ISender sender)
    {
        _sender = sender;
    }
        
    // GET: api/by-quiz/<QuizSubmissionController>
    [HttpGet("by-quiz/{quizId}")]
    [Produces(typeof(IEnumerable<QuizSubmissionDTO>))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByQuiz(int quizId)
    {
        var query = new GetQuizSubmissionsByQuizQuery()
        {
            QuizId = quizId
        };
            
        var result = await _sender.Send(query);

        var dtos = new List<QuizSubmissionDTO>();
        foreach(var question in result)
        {
            var dto = (QuizSubmissionDTO)question;
            dtos.Add(dto);
        }
        
        return Ok(dtos);
    }

    // GET api/<QuizSubmissionController>/5
    [HttpGet("{id}")]
    [Produces(typeof(QuizSubmissionDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetQuizSubmissionQuery
        {
            Id = id
        };
            
        var result = await _sender.Send(query);

        if (result is null)
            return NotFound();

        return Ok((QuizSubmissionDTO)result);
    }

    // POST api/<QuizSubmissionController>
    [HttpPost]
    [Produces(typeof(QuizSubmissionDTO))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateQuizSubmissionCommand command)
    {
        var result = await _sender.Send(command);

        int id = result.Id;
            
        return CreatedAtAction(nameof(Get), new { id }, (QuizSubmissionDTO)result);
    }

    // // PUT api/<QuizSubmissionController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<QuizSubmissionController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteQuizSubmissionCommand
        {
            Id = id
        };

        await _sender.Send(command);

        return NoContent();
    }
}