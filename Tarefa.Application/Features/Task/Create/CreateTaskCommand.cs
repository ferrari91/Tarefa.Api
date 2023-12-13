using MediatR;
using Tarefa.Domain.Common;

namespace Tarefa.Application.Features.Task.Create
{
    public class CreateTaskCommand : IRequest<BaseEntity>
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
