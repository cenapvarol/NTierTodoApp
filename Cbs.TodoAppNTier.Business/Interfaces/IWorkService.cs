using Cbs.TodoAppNTier.Dtos.WorkDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cbs.TodoAppNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAllAsync();
        Task Cretae(WorkCreateDto dto);
        Task<WorkListDto> GetById(int id);
        Task Remove(int id);
        Task Update(WorkUpdateDto dto);
    }
}
