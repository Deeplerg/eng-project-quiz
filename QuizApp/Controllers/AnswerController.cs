using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using QuizApp.Application.Answers.Commands.CreateAnswer;
using QuizApp.Application.Answers.Commands.DeleteAnswer;
using QuizApp.Application.Answers.Queries.GetAnswer;
using QuizApp.Core.Entities;
using QuizApp.Views;

namespace QuizApp.Controllers;

[Route("api/answers")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly ISender _sender;

    public AnswerController(ISender sender)
    {
        _sender = sender;
    }

    // GET api/<AnswerController>/5
    [HttpGet("{id}")]
    [Produces(typeof(AnswerDTO))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetAnswerQuery
        {
            Id = id
        };

        var result = await _sender.Send(query);

        if (result is null)
            return NotFound();
        return Ok((AnswerDTO)result);
    }

    // POST api/<AnswerController>
    [HttpPost]
    [Produces(typeof(AnswerDTO))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateAnswerCommand command)
    {
        var result = await _sender.Send(command);

        int id = result.Id;

        return CreatedAtAction(nameof(Get), new { id }, (AnswerDTO)result);
    }

    // // PUT api/<AnswerController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/<AnswerController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAnswerCommand
        {
            Id = id
        };

        await _sender.Send(command);

        return NoContent();
    }
}