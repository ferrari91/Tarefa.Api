using MediatR;

namespace Tarefa.Application.Features.Task.Delete
{

    public class DeleteTaskCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
