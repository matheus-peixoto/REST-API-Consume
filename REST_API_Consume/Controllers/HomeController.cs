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
        private PloomesAPIRepository _ploomesApiRepo;

        public HomeController(PloomesAPIRepository ploomesApiRepo)
        {
            _ploomesApiRepo = ploomesApiRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _ploomesApiRepo.FindAllContactsAsync();
            return View(contacts);
        }
    }
}
