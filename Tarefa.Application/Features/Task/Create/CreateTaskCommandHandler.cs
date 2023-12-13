using MediatR;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Common;
using Tarefa.Domain.Entities;

namespace Tarefa.Application.Features.Task.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, BaseEntity>
    {
        protected readonly ITaskRepository _taskRepository;
        protected readonly IUnityOfWork _unitOfWork;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IUnityOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseEntity> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskEntity() { Titulo = request.Titulo, Concluida = request.Concluida };

            await _taskRepository.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();

            return task;
        }
    }
}
