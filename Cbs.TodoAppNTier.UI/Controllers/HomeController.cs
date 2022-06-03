using Cbs.TodoAppNTier.Business.Interfaces;
using Cbs.TodoAppNTier.Dtos.WorkDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cbs.TodoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAllAsync();
            return View(workList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Cretae(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workService.GetById(id);

            return View(new WorkUpdateDto
            {
                Id = dto.Id,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);

        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _workService.Remove(id);
            return RedirectToAction("Index");

        }
    }
}
