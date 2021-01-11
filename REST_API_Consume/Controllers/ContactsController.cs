using Microsoft.AspNetCore.Mvc;
using REST_API_Consume.APIs;
using REST_API_Consume.Models;
using REST_API_Consume.Models.ViewModels;
using System.Threading.Tasks;

namespace REST_API_Consume.Controllers
{
    public class ContactsController : Controller
    {
        private PloomesAPIServices _ploomesApi;

        public ContactsController(PloomesAPIServices ploomesApi)
        {
            _ploomesApi = ploomesApi;
        }

        public async Task<IActionResult> Details(int id)
        {
            ContactViewModel viewModel = new ContactViewModel()
            {
                Contact = await _ploomesApi.FindContacByIdtAsync(id),
                Deals = await _ploomesApi.FindAllContactDealsAsync(id)
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

            await _ploomesApi.CreateContactAsync(contact);

            return RedirectToAction("Index", "Home");
        }
    }
}
