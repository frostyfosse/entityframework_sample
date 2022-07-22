using Bogus;

namespace DataAccess.Tests.Fakers
{
    internal abstract class FakerBase<T>
        where T : class
    {
        public FakerBase()
        {
            Faker = new Faker<T>();
            AddRules();
        }

        protected Faker<T> Faker { get; set; }

        protected abstract void AddRules();
        public virtual IEnumerable<T> Generate(int count)
        {
            return Faker.Generate(count);
        }
    }
}
