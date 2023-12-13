using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarefa.Application.Exceptions;
using Tarefa.Application.Features.Task.Create;
using Tarefa.Application.Features.Task.Delete;
using Tarefa.Application.Features.Task.Update;
using Tarefa.Application.Features.Task.View.Id;
using Tarefa.Application.Features.Task.View.PageList;

namespace Tarefa.Api.Controllers
{
    public class TasksController : BaseApiController
    {
        public TasksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("registar-tarefa")]
        public async Task<IActionResult> RegisterTask([FromBody] CreateTaskCommand model)
        {
            try
            {
                var result = await Mediator.Send(model);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x => new { Message = x.ErrorMessage }).ToList());
            }
        }

        [HttpDelete]
        [Route("deletar-tarefa")]
        public async Task<IActionResult> DeleteTask([FromQuery] DeleteTaskCommand model)
        {
            try
            {
                var result = await Mediator.Send(model);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x => new { Message = x.ErrorMessage }).ToList());
            }
        }

        [HttpPut]
        [Route("atualizar-tarefa")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommand model)
        {
            try
            {
                var result = await Mediator.Send(model);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors.Select(x => new { Message = x.ErrorMessage }).ToList());
            }
        }

        [HttpGet]
        [Route("obter-tarefa-por-id")]
        public async Task<IActionResult> GetTaskById([FromQuery] GetTaskById model)
        {
            var result = await Mediator.Send(model);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("obter-todas-tarefas")]
        public async Task<IActionResult> GetAllTasks([FromQuery] GetTaskPageList model)
        {
            return Ok(await Mediator.Send(model));
        }
    }
}
