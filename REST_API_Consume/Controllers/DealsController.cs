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
        private PloomesAPIRepository _ploomesApiRepo;

        public DealsController(PloomesAPIRepository ploomesApiRepo)
        {
            _ploomesApiRepo = ploomesApiRepo;
        }

        public async Task<IActionResult> Create()
        {
            DealViewModel viewModel = new DealViewModel() { Contacts = await _ploomesApiRepo.FindAllContactsAsync() };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Deal deal)
        {
            if (!ModelState.IsValid)
            {
                DealViewModel viewModel = new DealViewModel() { Contacts = await _ploomesApiRepo.FindAllContactsAsync() };
                return View(viewModel);
            }

            await _ploomesApiRepo.CreateDealAsync(deal);

            return RedirectToAction("Details", "Contacts", new { Id = deal.ContactId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            Deal deal = await _ploomesApiRepo.FindDealByIdAsync(id);
            return View(deal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Deal deal)
        {
            if (!ModelState.IsValid)
                return View(deal.Id);

            await _ploomesApiRepo.UpdateDealAsync(deal);

            return RedirectToAction("Details", "Contacts", new { Id = deal.ContactId });
        }

        public async Task<IActionResult> Details(int id)
        {
            DealViewModel viewModel = new DealViewModel()
            {
                Deal = await _ploomesApiRepo.FindDealByIdAsync(id),
                DealTasks = await _ploomesApiRepo.FindAllDealTasksAsync(id)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Win(int dealId)
        {
            Deal deal = await _ploomesApiRepo.FindDealByIdAsync(dealId);
            await _ploomesApiRepo.WinDealAsync(deal);
            await _ploomesApiRepo.CreateInteractionRecordAsync(new InteractionRecord() { ContactId = deal.ContactId, Content = "Negócio fechado!" });

            return RedirectToAction("Index", "Home");
        }
    }
}
