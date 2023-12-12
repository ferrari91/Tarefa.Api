namespace Tarefa.Domain.Model
{
    public class Tarefa : BaseEntity
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; } 
    }
}
