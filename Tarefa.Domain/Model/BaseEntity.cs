using System.ComponentModel.DataAnnotations;

namespace Tarefa.Domain.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
