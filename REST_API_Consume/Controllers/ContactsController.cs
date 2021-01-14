using Microsoft.AspNetCore.Mvc;
using REST_API_Consume.APIs;
using REST_API_Consume.Models;
using REST_API_Consume.Models.ViewModels;
using System.Threading.Tasks;

namespace REST_API_Consume.Controllers
{
    public class ContactsController : Controller
    {
        private PloomesAPIRepository _ploomesApiRepo;

        public ContactsController(PloomesAPIRepository ploomesApiRepo)
        {
            _ploomesApiRepo = ploomesApiRepo;
        }

        public async Task<IActionResult> Details(int id)
        {
            ContactViewModel viewModel = new ContactViewModel()
            {
                Contact = await _ploomesApiRepo.FindContacByIdtAsync(id),
                Deals = await _ploomesApiRepo.FindAllContactDealsAsync(id)
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            await _ploomesApiRepo.CreateContactAsync(contact);

            return RedirectToAction("Index", "Home");
        }
    }
}
