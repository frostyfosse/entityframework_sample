using DataAccess.Models;

namespace DataAccess.Tests.Fakers
{
    internal class PersonFaker : FakerBase<Models.Person>
    {
        public PersonFaker()
        {
            AddRules();
            _addressFaker = new AddressFaker();
            _emailFaker = new EmailFaker();
        }

        AddressFaker _addressFaker;
        EmailFaker _emailFaker;

        //bool _addressRuleAdded;
        //bool _emailRuleAdded;

        //void AddEmailRule(int count)
        //{
        //    if (_emailRuleAdded)
        //        return;
            
        //    var emailFaker = new EmailFaker();

        //    Faker = Faker
        //        .RuleFor(p => p.EmailAddresses, emailFaker.Generate(count));

        //    _emailRuleAdded = true;
        //}

        //void AddAddressRule(int count)
        //{
        //    if (_addressRuleAdded)
        //        return;

        //    var addressFaker = new AddressFaker();

        //    Faker = Faker
        //        .RuleFor(p => p.Addresses, addressFaker.Generate(count));

        //    _addressRuleAdded = true;
        //}

        void AddChildren(int count, IEnumerable<Person> persons)
        {
            foreach(var person in persons)
            {
                var addresses = _addressFaker.Generate(count);
                var emails = _emailFaker.Generate(count);

                person.Addresses.AddRange(addresses);
                person.EmailAddresses.AddRange(emails);
            }
        }

        protected override void AddRules()
        {
            var addressFaker = new AddressFaker();

            Faker = this.Faker
                //.RuleFor(x => x.Id, f => FakerIdGenerator.GenerateId())
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.Age, f => f.Random.Number(1, 100));
        }

        public override IEnumerable<Person> Generate(int count)
        {
            var persons = base.Generate(count);

            AddChildren(3, persons);

            return persons;
        }
    }
}
