using MediatR;
using Tarefa.Application.Interface;
using Tarefa.Application.Interface.Repositories;

namespace Tarefa.Application.Features.Task.Delete
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        protected readonly ITaskRepository _taskRepository;
        protected readonly IUnityOfWork _unitOfWork;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository, IUnityOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var data = await _taskRepository.GetByIdAsync(request.Id);

            if (data is not null)
                 _taskRepository.Delete(data);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
