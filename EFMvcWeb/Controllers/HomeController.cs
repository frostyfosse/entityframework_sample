using DataAccess.DataAccess;
using DataAccess.Models;
using EFMvcWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EFMvcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly PeopleContext _db;
        static bool _inprogress;

        void LoadSampleData()
        {
            if (_db.People.Count() > 0)
                return;

            var filePath = Path.Combine("Sample", "GeneratedPersons.json");
            var json = System.IO.File.ReadAllText(filePath);
            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            if (people != null && 
                people.Any() &&
                !_inprogress)
            {
                _inprogress = true;

                _db.AddRange(people);

                _db.SaveChanges();

                _inprogress = false;
            }
        }

        public HomeController(ILogger<HomeController> logger, PeopleContext db)
        {
            _logger = logger;
            _db = db;

            LoadSampleData();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}