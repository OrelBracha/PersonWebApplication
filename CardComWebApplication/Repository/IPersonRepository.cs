using CardComWebApplication.Models;
using CardComWebApplication.Models.Domain;

namespace CardComWebApplication.Repository
{
    public interface IPersonRepository
    {
        bool EmailExists(string email);
        bool IdExists(string id);
        bool PhoneExists(string phone);
        void AddPerson(AddPersonViewModel personViewModel);
		List<Person> GetPersons();
        Person GetPersonById(string id);
        public Person GetPersonByMail(string mail);
        public Person GetPersonByPhone(string phone);
        void EditPerson(Person person, EditPersonViewModel personViewModel);
        void DeletePerson(string id);
    }
}
