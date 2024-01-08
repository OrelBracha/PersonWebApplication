using CardComWebApplication.Models;
using CardComWebApplication.Models.Domain;

namespace CardComWebApplication.Services
{
    public interface IPersonService
    {

        public bool IsIDUniqueEdit(string newId, string currentId);

        public bool IsEmailUniqueEdit(string newId, string currentId);

        public bool IsPhoneUniqueEdit(string newId, string currentId);

        bool IsIdUnique(string id);
        bool IsEmailUnique(string email);
        bool IsPhoneUnique(string phone);
        void AddPerson(AddPersonViewModel personViewModel);
        List<Person> GetPersons();
        Person GetPersonById(string id);
        public void EditPerson(Person person, EditPersonViewModel model);
        void DeletePerson(string id);
    }
}
