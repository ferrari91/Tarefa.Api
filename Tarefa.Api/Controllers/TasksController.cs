using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarefa.Application.Exceptions;
using Tarefa.Application.Features.Task.Create;
using Tarefa.Application.Features.Task.Delete;
using Tarefa.Application.Features.Task.Update;

namespace Tarefa.Api.Controllers
{
    public class TasksController : BaseApiController
    {
        public TasksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTask([FromBody] CreateTaskCommand task)
        {
            try
            {
                var result = await Mediator.Send(task);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x => new { Message = x.ErrorMessage }).ToList());
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromQuery] DeleteTaskCommand task)
        {
            try
            {
                var result = await Mediator.Send(task);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x => new { Message = x.ErrorMessage }).ToList());
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommand task)
        {
            try
            {
                var result = await Mediator.Send(task);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x => new { Message = x.ErrorMessage }).ToList());
            }
        }
    }
}
