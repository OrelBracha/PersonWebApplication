using CardComWebApplication.Models.Domain;
using CardComWebApplication.Models;
using CardComWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;

namespace CardComWebApplication.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly PersonDBContext _context;

        public PersonRepository(PersonDBContext context)
        {
            _context = context;
        }

        public bool EmailExists(string email)
        {
            return _context.Person.Any(p => p.Email == email);
        }

        public bool IdExists(string id)
        {
            return _context.Person.Any(p => p.ID == id);
        }

        public bool PhoneExists(string phone)
        {
            return _context.Person.Any(p => p.Phone == phone);
        }

        public void AddPerson(AddPersonViewModel personViewModel)
        {
            // Implement logic to add a person to the database
            var person = new Person
            {
                ID = personViewModel.ID,
                Name = personViewModel.Name,
                Email = personViewModel.Email,
                Birthdate = personViewModel.Birthdate,
                Gender = personViewModel.Gender?.ToString(),
                Phone = personViewModel.Phone
            };

            _context.Person.Add(person);
            _context.SaveChanges();
        }
        public List<Person> GetPersons()
        {
            return   _context.Person.ToList();
        }
        public Person GetPersonById(string id)
        {
            return _context.Person.FirstOrDefault(p => p.ID == id);
        }

        public Person GetPersonByMail(string mail)
        {
            return _context.Person.FirstOrDefault(p => p.Email == mail);
        }

        public Person GetPersonByPhone(string phone)
        {
            return _context.Person.FirstOrDefault(p => p.Phone == phone);
        }

        public void EditPerson(Person person, EditPersonViewModel updatedPerson)
        {
            var existingPerson = _context.Person.Find(person.ID);

            if (existingPerson != null)
            {
                // Assuming that person is a DTO with updated data
                existingPerson.ID = updatedPerson.ID;
                existingPerson.Name = updatedPerson.Name;
                existingPerson.Email = updatedPerson.Email;
                existingPerson.Birthdate = updatedPerson.Birthdate;
                existingPerson.Gender = updatedPerson.Gender?.ToString();
                existingPerson.Phone = updatedPerson.Phone;

                _context.SaveChanges();
            }
        }

        public void DeletePerson(string id)
        {
            // Implement logic to delete a person
            var person = _context.Person.FirstOrDefault(p => p.ID == id);

            if (person != null)
            {
                _context.Person.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
