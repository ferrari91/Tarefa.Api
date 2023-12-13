using System.ComponentModel.DataAnnotations;

namespace Tarefa.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
