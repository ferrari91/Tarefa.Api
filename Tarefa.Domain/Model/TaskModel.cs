namespace Tarefa.Domain.Model
{
    public class TaskModel : BaseEntity
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; } 
    }
}
