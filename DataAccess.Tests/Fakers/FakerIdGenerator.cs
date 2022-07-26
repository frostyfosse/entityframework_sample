using DataAccess.Models;

namespace DataAccess.Tests.Fakers
{
    internal static class FakerIdGenerator
    {
        static int _id = 1;

        static void UpdateId(ModelBase model)
        {
            model.Id = _id++;
        }

        static void UpdateIds(IEnumerable<ModelBase> models)
        {
            if (models == null)
                return;

            foreach(var model in models)
            {
                UpdateId(model);
            }
        }

        public static int GenerateId()
        {
            return _id++;
        }

        public static void UpdateIds(IEnumerable<Person> persons)
        {
            if (persons == null)
                return;

            foreach(var person in persons)
            {
                UpdateId(person);
                UpdateIds(person.Addresses);
                UpdateIds(person.EmailAddresses);
            }
        }
    }
}
