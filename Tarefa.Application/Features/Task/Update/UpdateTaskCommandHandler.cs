using MediatR;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Entities;

namespace Tarefa.Application.Features.Task.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskEntity>
    {
        protected readonly ITaskRepository _taskRepository;
        protected readonly IUnityOfWork _unitOfWork;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnityOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskEntity> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
             _taskRepository.Update(request);
           
            await _unitOfWork.SaveChangesAsync();

            return request;
        }
    }
}
