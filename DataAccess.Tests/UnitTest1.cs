using DataAccess.Tests.Fakers;
using Newtonsoft.Json;

namespace DataAccess.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GeneratePersonFaker()
        {
            var persons = new PersonFaker().Generate(5);

            var json = JsonConvert.SerializeObject(persons);
        }
    }
}