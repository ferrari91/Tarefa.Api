using FluentValidation;

namespace Tarefa.Application.Features.Task.Create
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(p => p.Titulo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
