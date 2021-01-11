using Microsoft.AspNetCore.Mvc;
using REST_API_Consume.APIs;
using REST_API_Consume.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Controllers
{
    public class HomeController : Controller
    {
        private PloomesAPIServices _ploomesApi;

        public HomeController(PloomesAPIServices ploomesApi)
        {
            _ploomesApi = ploomesApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _ploomesApi.FindAllContactsAsync();
            return View(contacts);
        }
    }
}
