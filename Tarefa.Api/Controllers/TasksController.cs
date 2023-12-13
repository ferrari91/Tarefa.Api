using Microsoft.AspNetCore.Mvc;
using Tarefa.Application.Exceptions;
using Tarefa.Application.Features.Task.Create;

namespace Tarefa.Api.Controllers
{
    public class TasksController : BaseApiController
    {
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
    }
}
