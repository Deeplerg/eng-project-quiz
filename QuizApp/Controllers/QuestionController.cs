using System.Collections.Immutable;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Common;
using QuizApp.Application.Questions.Commands.CreateQuestion;
using QuizApp.Application.Questions.Commands.DeleteQuestion;
using QuizApp.Application.Questions.Queries.GetQuestion;
using QuizApp.Application.Questions.Queries.GetQuestions;
using QuizApp.Application.Questions.Queries.GetQuizQuestions;
using QuizApp.Core.Entities;
using QuizApp.Views;

namespace QuizApp.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly ISender _sender;

    public QuestionController(ISender sender)
    {
        _sender = sender;
    }
        
    // GET: api/by-quiz/<QuestionController>
    [HttpGet("by-quiz/{quizId}")]
    [Produces(typeof(IEnumerable<QuestionDTO>))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByQuiz(int quizId)
    {
        var query = new GetQuizQuestionsQuery()
        {
            QuizId = quizId
        };
            
        var result = await _sender.Send(query);

        var dtos = new List<QuestionDTO>();
        foreach(var question in result)
        {
            var dto = (QuestionDTO)question;
            dtos.Add(dto);
        }
        
        return Ok(dtos);
    }

    // GET api/<QuestionController>/5
    [HttpGet("{id}")]
    [Produces(typeof(QuestionDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetQuestionQuery
        {
            Id = id
        };
            
        var result = await _sender.Send(query);

        if (result is null)
            return NotFound();

        return Ok((QuestionDTO)result);
    }

    // POST api/<QuestionController>
    [HttpPost]
    [Produces(typeof(QuestionDTO))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateQuestionCommand command)
    {
        var result = await _sender.Send(command);

        int id = result.Id;
            
        return CreatedAtAction(nameof(Get), new { id }, (QuestionDTO)result);
    }

    // // PUT api/<QuestionController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<QuestionController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteQuestionCommand
        {
            Id = id
        };

        await _sender.Send(command);

        return NoContent();
    }
}