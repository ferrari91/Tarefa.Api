using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefa.Application.Interface
{
    public interface IDataService
    {
        Task<bool> CreateDataBaseAsync();
    }
}
