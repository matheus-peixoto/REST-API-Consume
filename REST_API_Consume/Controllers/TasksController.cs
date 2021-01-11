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
        private PloomesAPIServices _ploomesApi;

        public TasksController(PloomesAPIServices ploomesApi)
        {
            _ploomesApi = ploomesApi;
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

            await _ploomesApi.CreateTaskAsync(task);

            return RedirectToAction("Details", "Deals", new { Id = task.DealId });
        }

        public async Task<IActionResult> Finish(int id)
        {
            Models.Task task = await _ploomesApi.FindTaskByIdAsync(id);

            await _ploomesApi.FinishTaskAsync(task);

            return RedirectToAction("Details", "Deals", new { Id = task.DealId });
        }
    }
}
