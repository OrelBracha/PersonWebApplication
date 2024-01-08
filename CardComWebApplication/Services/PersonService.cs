using CardComWebApplication.Models;
using CardComWebApplication.Models.Domain;
using CardComWebApplication.Repository;
using System.Data;

namespace CardComWebApplication.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        public bool IsIDUniqueEdit(string newId, string currentId)
        {
            // Check uniqueness, excluding the current ID
            var existingPerson = _personRepository.GetPersonById(newId);
            return existingPerson == null || existingPerson.ID == currentId;
        }

        public bool IsEmailUniqueEdit(string newMail, string currentMail)
        {
            // Check uniqueness, excluding the current ID
            var existingPerson = _personRepository.GetPersonByMail(newMail);
            return existingPerson == null || existingPerson.Email == currentMail;
        }

        public bool IsPhoneUniqueEdit(string newPhone, string currentPhone)
        {
            // Check uniqueness, excluding the current ID
            var existingPerson = _personRepository.GetPersonByPhone(newPhone);
            return existingPerson == null || existingPerson.Phone == currentPhone;
        }

        public bool IsIdUnique(string id)
        {
            // Implement logic to check if the ID already exists in the database
            return !_personRepository.IdExists(id);
        }

        public bool IsEmailUnique(string email)
        {
            // Implement logic to check if the email already exists in the database
            return !_personRepository.EmailExists(email);
        }
        public bool IsPhoneUnique(string phone)
        {
            // Implement logic to check if the phone number already exists in the database
            return !_personRepository.PhoneExists(phone);
        }

        public void AddPerson(AddPersonViewModel personViewModel)
        {
            // Implement logic to add a person to the database
            _personRepository.AddPerson(personViewModel);
        }
        public List<Person> GetPersons()
        {
            return _personRepository.GetPersons();
        }


        public Person GetPersonById(string id)
        {
            // Implement logic to get a person by ID
            return _personRepository.GetPersonById(id);
        }

        public void EditPerson(Person person, EditPersonViewModel personViewModel)
        {
            
            // Example: Update the person in the repository
            _personRepository.EditPerson(person,personViewModel);
        }

        public void DeletePerson(string id)
        {
            // Implement logic to delete a person
            _personRepository.DeletePerson(id);
        }
    }
}
