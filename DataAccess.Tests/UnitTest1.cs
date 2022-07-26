using Bogus;
using DataAccess.Models;
using DataAccess.Tests.Fakers;
using Newtonsoft.Json;

namespace DataAccess.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GeneratePersonFaker()
        {
            //Need to remove duplicates
            var persons = new PersonFaker().Generate(100);
            var addresses = new List<Address>();
            var emails = new List<Email>();
            var addressChanged = new List<Address>();

            FakerIdGenerator.UpdateIds(persons);

            foreach(var personGrp in persons.GroupBy(x => x.Id))
            {
                var count = personGrp.Count() > 1;

                Assert.False(count);
            }

            foreach (var emailGrp in emails.GroupBy(x => x.Id))
            {
                var count = emailGrp.Count() > 1;
                
                Assert.False(count);
            }

            foreach (var addreessGrp in addresses.GroupBy(x => x.Id))
            {
                var count = addreessGrp.Count() > 1;

                Assert.False(count);
            }

            var json = JsonConvert.SerializeObject(persons);

            await File.WriteAllTextAsync(Path.Combine("..", "..", "..", "GeneratedPersons.json"), json);
        }
    }
}