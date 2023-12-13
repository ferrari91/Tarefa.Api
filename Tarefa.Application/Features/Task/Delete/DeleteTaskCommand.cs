using MediatR;
using Tarefa.Application.Features.Task.Create;

namespace Tarefa.Application.Features.Task.Delete
{

    public class DeleteTaskCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
