using DataAccess.DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EFMvcWeb.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            LoadSampleData();
        }

        void LoadSampleData()
        {
            if (_db.People.Count() <= 0)
                return;

            var filePath = Path.Combine("Sample", "GeneratedPersons.json");
            var json = System.IO.File.ReadAllText(filePath);
            var people = JsonConvert.DeserializeObject<List<Person>>(json);

            if (people != null && people.Any())
            {
                _db.AddRange(people);

                _db.SaveChanges();
            }
        }
    }
}
