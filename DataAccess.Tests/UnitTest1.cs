using DataAccess.Tests.Fakers;
using Newtonsoft.Json;

namespace DataAccess.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GeneratePersonFaker()
        {
            var persons = new PersonFaker().Generate(100);
            var json = JsonConvert.SerializeObject(persons);

            await File.WriteAllTextAsync(Path.Combine("..", "..", "..", "GeneratedPersons.json"), json);
        }
    }
}