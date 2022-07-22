namespace DataAccess.Tests.Fakers
{
    internal class EmailFaker : FakerBase<Models.Email>
    {
        protected override void AddRules()
        {
            Faker = Faker
                .RuleFor(x => x.Id, f => f.Random.Number(0, 1000))
                .RuleFor(x => x.EmailAddress, f => f.Internet.Email());
        }
    }
}
