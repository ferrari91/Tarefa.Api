using Tarefa.Domain.Entities;

namespace Tarefa.Domain.Dto
{
    public class TaskDto
    {
        public TaskDto(TaskEntity task)
        {
            Id = task.Id;
            Titulo = task.Titulo;
            Concluida = task.Concluida;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
