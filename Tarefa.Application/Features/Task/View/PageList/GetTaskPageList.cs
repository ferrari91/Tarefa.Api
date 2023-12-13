using MediatR;
using Tarefa.Domain.Dto;

namespace Tarefa.Application.Features.Task.View.PageList
{
    public class GetTaskPageList : IRequest<List<TaskDto>>
    {
    }
}
