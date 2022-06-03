using Cbs.TodoAppNTier.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cbs.TodoAppNTier.DataAccess.UnitofWork
{
   public interface IUow 
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChange();
    }
}
