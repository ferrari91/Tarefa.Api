using MediatR;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Dto;

namespace Tarefa.Application.Features.Task.View.PageList
{
    public class GetTaskPageListHandler : IRequestHandler<GetTaskPageList, List<TaskDto>>
    {
        protected readonly ITaskRepository _taskRepository;

        public GetTaskPageListHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> Handle(GetTaskPageList request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetAllAsync();
            var list = new List<TaskDto>();

            task.ForEach(item =>
            {
                list.Add(new TaskDto(item));
            });

            return list;
        }
    }
}
