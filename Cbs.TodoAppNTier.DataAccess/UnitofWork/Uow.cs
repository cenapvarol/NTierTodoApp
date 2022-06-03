using Cbs.TodoAppNTier.DataAccess.Context;
using Cbs.TodoAppNTier.DataAccess.Interfaces;
using Cbs.TodoAppNTier.DataAccess.Repositories;
using System.Threading.Tasks;

namespace Cbs.TodoAppNTier.DataAccess.UnitofWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _contex;

        public Uow(TodoContext contex)
        {
            _contex = contex;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_contex);
        }

        public async Task SaveChange()
        {
            await _contex.SaveChangesAsync();
        }
    }
}
