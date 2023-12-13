using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefa.Domain.Common;

namespace Tarefa.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
    }
}
