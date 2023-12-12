using MediatR;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;
using Tarefa.Domain.Model;

namespace Tarefa.Application.Features.Task.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskModel>
    {
        protected readonly ITaskRepository _taskRepository;
        protected readonly IUnityOfWork _unitOfWork;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnityOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskModel> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
             _taskRepository.Update(request);
           
            await _unitOfWork.SaveChangesAsync();

            return request;
        }
    }
}
