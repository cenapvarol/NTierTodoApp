using Cbs.TodoAppNTier.Business.Interfaces;
using Cbs.TodoAppNTier.DataAccess.UnitofWork;
using Cbs.TodoAppNTier.Dtos.WorkDtos;
using Cbs.TodoAppNTier.Entities.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cbs.TodoAppNTier.Business.Services
{
    class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task Cretae(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().CreateAsync(new()
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });
            await _uow.SaveChange();
        }


        public async Task<List<WorkListDto>> GetAllAsync()
        {
            var listData = await _uow.GetRepository<Work>().GetAllAsync();

            var workList = new List<WorkListDto>();

            if (listData != null && listData.Count > 0)
            {
                foreach (var work in listData)
                {
                    workList.Add(new()
                    {
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted,
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var data = await _uow.GetRepository<Work>().GetByFilterAsync(x => x.Id == id);
            return new()
            {
                Definition = data.Definition,
                IsCompleted = data.IsCompleted,
            };
        }

        public async Task Remove(int id)
        {
            var deleteWork = await _uow.GetRepository<Work>().GetByFilterAsync(x => x.Id == id);
            _uow.GetRepository<Work>().RemoveAsync(deleteWork);
            _uow.SaveChange();

        }

        public async Task Update(WorkUpdateDto dto)
        {
            var workUpdate = await _uow.GetRepository<Work>().GetByIdAsync(dto.Id);
            _uow.GetRepository<Work>().UpdateAsync(new()
            {
                Definition = workUpdate.Definition,
                IsCompleted = workUpdate.IsCompleted,
            });
            _uow.SaveChange();

        }
    }
}
