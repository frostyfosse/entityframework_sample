namespace DataAccess.Tests.Fakers
{
    internal class AddressFaker : FakerBase<Models.Address>
    {
        protected override void AddRules()
        {
            Faker = Faker
                //.RuleFor(x => x.Id, f => FakerIdGenerator.GenerateId())
                .RuleFor(x => x.StreetAddress, f => f.Address.StreetAddress(true))
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.State, f => f.Address.StateAbbr())
                .RuleFor(x => x.ZipCode, f => f.Address.ZipCode());
        }
    }
}
