using MediatR;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Dto;

namespace Tarefa.Application.Features.Task.View.Id
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskById, TaskDto?>
    {
        protected readonly ITaskRepository _taskRepository;

        public GetTaskByIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto?> Handle(GetTaskById request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);

            if (task is null)
                return null;

            return new TaskDto(task);
        }
    }
}
