using Microsoft.AspNetCore.Mvc;
using REST_API_Consume.APIs;
using REST_API_Consume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Controllers
{
    public class InteractionsRecordsController : Controller
    {
        private PloomesAPIServices _ploomesApi;

        public InteractionsRecordsController(PloomesAPIServices ploomesApi)
        {
            _ploomesApi = ploomesApi;
        }

        public IActionResult Create(int id)
        {
            ViewBag.ContactId = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InteractionRecord interactionRecord)
        {
            if (!ModelState.IsValid)
                return View();

            await _ploomesApi.CreateInteractionRecordAsync(interactionRecord);

            return RedirectToAction("Index", "Home");
        }
    }
}
