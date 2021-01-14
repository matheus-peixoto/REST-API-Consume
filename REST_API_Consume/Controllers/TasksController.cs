using Microsoft.AspNetCore.Mvc;
using REST_API_Consume.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Controllers
{
    public class TasksController : Controller
    {
        private PloomesAPIRepository _ploomesApiRepo;

        public TasksController(PloomesAPIRepository ploomesApiRepo)
        {
            _ploomesApiRepo = ploomesApiRepo;
        }

        public IActionResult Create(int dealId, int contactId)
        {
            Models.Task task = new Models.Task() { ContactId = contactId, DealId = dealId };
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task)
        {
            if (!ModelState.IsValid)
                return NotFound();

            await _ploomesApiRepo.CreateTaskAsync(task);

            return RedirectToAction("Details", "Deals", new { Id = task.DealId });
        }

        public async Task<IActionResult> Finish(int id)
        {
            Models.Task task = await _ploomesApiRepo.FindTaskByIdAsync(id);

            await _ploomesApiRepo.FinishTaskAsync(task);

            return RedirectToAction("Details", "Deals", new { Id = task.DealId });
        }
    }
}
