using pra_test.Models;

namespace pra_test.Interface
{
    public interface IPerson
    {
        IEnumerable<PersonModel> GetPeople();
        PersonModel GetPersonById(int id);
        void AddPerson(PersonModel person);
        void UpdatePerson(PersonModel person);
        void DeletePerson(int id);
    }
}
