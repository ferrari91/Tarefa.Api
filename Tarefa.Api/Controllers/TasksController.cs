using Microsoft.AspNetCore.Mvc;
using Tarefa.Application.Features.Task.Create;
using Tarefa.Domain.Model;

namespace Tarefa.Api.Controllers
{
    public class TasksController : BaseApiController
    {
        [HttpPost]
        public async Task<BaseEntity> RegisterTask([FromBody] CreateTaskCommand task) => await Mediator.Send(task);
    }
}
