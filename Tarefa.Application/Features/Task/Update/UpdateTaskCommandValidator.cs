using FluentValidation;
using Tarefa.Application.Interface.Repositories;

namespace Tarefa.Application.Features.Task.Update
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        protected readonly ITaskRepository _taskRepository;

        public UpdateTaskCommandValidator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(command => command.Id)
            .MustAsync(BeValidId)
            .WithMessage("A Tarefa não foi encontrada.");

            RuleFor(command => command.Id)
            .MustAsync(BeValidCompleted)
            .WithMessage("Somente tarefas não concluídas podem receber alteração.");
        }

        private async Task<bool> BeValidId(int id, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return task != null;
        }

        private async Task<bool> BeValidCompleted(int id, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return (task is not null && !task.Concluida);
        }
    }
}
