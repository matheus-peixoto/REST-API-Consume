using Microsoft.AspNetCore.Mvc;
using REST_API_Consume.APIs;
using REST_API_Consume.Models;
using REST_API_Consume.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Controllers
{
    public class DealsController : Controller
    {
        private PloomesAPIServices _ploomesApi;

        public DealsController(PloomesAPIServices ploomesApi)
        {
            _ploomesApi = ploomesApi;
        }

        public async Task<IActionResult> Create()
        {
            DealViewModel viewModel = new DealViewModel() { Contacts = await _ploomesApi.FindAllContactsAsync() };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Deal deal)
        {
            if (!ModelState.IsValid)
            {
                DealViewModel viewModel = new DealViewModel() { Contacts = await _ploomesApi.FindAllContactsAsync() };
                return View(viewModel);
            }

            await _ploomesApi.CreateDealAsync(deal);

            return RedirectToAction("Details", "Contacts", new { Id = deal.ContactId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            Deal deal = await _ploomesApi.FindDealByIdAsync(id);
            Console.WriteLine();
            return View(deal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Deal deal)
        {
            if (!ModelState.IsValid)
                return View(deal.Id);

            await _ploomesApi.UpdateDealAsync(deal);

            return RedirectToAction("Details", "Contacts", new { Id = deal.ContactId });
        }

        public async Task<IActionResult> Details(int id)
        {
            DealViewModel viewModel = new DealViewModel()
            {
                Deal = await _ploomesApi.FindDealByIdAsync(id),
                DealTasks = await _ploomesApi.FindAllDealTasksAsync(id)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Win(int dealId)
        {
            Deal deal = await _ploomesApi.FindDealByIdAsync(dealId);
            await _ploomesApi.WinDealAsync(deal);
            await _ploomesApi.CreateInteractionRecordAsync(new InteractionRecord() { ContactId = deal.ContactId, Content = "Negócio fechado!" });

            return RedirectToAction("Index", "Home");
        }
    }
}
