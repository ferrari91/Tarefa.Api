using MediatR;
using Tarefa.Application.Features.Task.Delete;
using Tarefa.Domain.Model;

namespace Tarefa.Application.Features.Task.Update
{
    public class UpdateTaskCommand : TaskModel, IRequest<TaskModel>
    {
    }
}
