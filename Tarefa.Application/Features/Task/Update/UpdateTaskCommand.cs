using MediatR;
using Tarefa.Domain.Entities;

namespace Tarefa.Application.Features.Task.Update
{
    public class UpdateTaskCommand : TaskEntity, IRequest<TaskEntity>
    {
    }
}
