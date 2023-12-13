using FluentValidation;
using Tarefa.Application.Interface.Repositories;

namespace Tarefa.Application.Features.Task.Delete
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        protected readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandValidator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(command => command.Id)
            .MustAsync(BeValidId)
            .MustAsync(BeValidCompleted)
            .WithMessage("A Tarefa não foi encontrada ou não está concluída.");
        }

        private async Task<bool> BeValidId(int id, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return task != null;
        }

        private async Task<bool> BeValidCompleted(int id, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return (task is not null && task.Concluida);
        }
    }
}
