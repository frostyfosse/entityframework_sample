using DataAccess.Models;

namespace DataAccess.Tests.Fakers
{
    internal class PersonFaker : FakerBase<Models.Person>
    {
        public PersonFaker()
        {
            AddRules();
        }

        bool _addressRuleAdded;
        bool _emailRuleAdded;

        void AddEmailRule(int count)
        {
            if (_emailRuleAdded)
                return;
            
            var emailFaker = new EmailFaker();

            Faker = Faker
                .RuleFor(p => p.EmailAddresses, emailFaker.Generate(count));

            _emailRuleAdded = true;
        }

        void AddAddressRule(int count)
        {
            if (_addressRuleAdded)
                return;

            var addressFaker = new AddressFaker();

            Faker = Faker
                .RuleFor(p => p.Addresses, addressFaker.Generate(count));

            _addressRuleAdded = true;
        }

        protected override void AddRules()
        {
            var addressFaker = new AddressFaker();

            Faker = this.Faker
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.Age, f => f.Random.Number(1, 100))
                .RuleFor(p => p.Id, f => f.Random.Number(101, 10000));
        }

        public override IEnumerable<Person> Generate(int count)
        {
            AddAddressRule(count);
            AddEmailRule(count);

            return base.Generate(count);
        }
    }
}
