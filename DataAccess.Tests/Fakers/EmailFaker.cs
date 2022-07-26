namespace DataAccess.Tests.Fakers
{
    internal class EmailFaker : FakerBase<Models.Email>
    {
        protected override void AddRules()
        {
            Faker = Faker
                //.RuleFor(x => x.Id, f => FakerIdGenerator.GenerateId())
                .RuleFor(x => x.EmailAddress, f => f.Internet.Email());
        }
    }
}
