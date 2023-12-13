using MediatR;
using Tarefa.Application.Features.Task.Update;
using Tarefa.Application.Interface;
using Tarefa.Domain.Dto;
using Tarefa.Domain.Entities;

namespace Tarefa.Application.Features.Task.View.Id
{
    public class GetTaskById : IRequest<TaskDto>
    {
        public int Id { get; set; }
    }
}
