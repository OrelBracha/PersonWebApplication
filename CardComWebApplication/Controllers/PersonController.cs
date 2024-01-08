using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CardComWebApplication.Data;
using CardComWebApplication.Models.Domain;
using System.Net;
using CardComWebApplication.Models;
using CardComWebApplication.Services;
using System.Data;

namespace CardComWebApplication.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var person =  _personService.GetPersons();
            return View(person);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Add(AddPersonViewModel addPersonRequest)
        {
            if (ModelState.IsValid)
            {
                // Check for uniqueness
                if (!_personService.IsEmailUnique(addPersonRequest.Email))
                {
                    ModelState.AddModelError("Email", "Email address already exists.");
                    return View(addPersonRequest);
                }

                if (!_personService.IsIdUnique(addPersonRequest.ID))
                {
                    ModelState.AddModelError("ID", "ID already exists.");
                    return View(addPersonRequest);
                }

                if (!_personService.IsPhoneUnique(addPersonRequest.Phone))
                {
                    ModelState.AddModelError("Phone", "Phone number already exists.");
                    return View(addPersonRequest);
                }

                // If everything is okay, proceed to save to the database
                _personService.AddPerson(addPersonRequest);

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the view with errors
            return View(addPersonRequest);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var person = _personService.GetPersonById(id);

            // If the person is not found, return NotFound
            if (person == null)
            {
                return NotFound();
            }

            EditPersonViewModel editViewModel = MapToEditViewModel(person);

            return View(editViewModel);
        }

        private EditPersonViewModel MapToEditViewModel(Person person)
        {
            return new EditPersonViewModel
            {
                ID = person.ID,
                Name = person.Name,
                Email = person.Email,
                Birthdate = person.Birthdate,
                Phone = person.Phone
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditPersonViewModel editpersonViewModel)
        {
            // Fetch the existing person from the database
            var existingPerson = _personService.GetPersonById(editpersonViewModel.ID);

            // Check uniqueness, excluding the current person's ID
            if (_personService.IsIDUniqueEdit(editpersonViewModel.ID, existingPerson.ID) &&
                _personService.IsEmailUniqueEdit(editpersonViewModel.ID, existingPerson.ID) &&
                _personService.IsPhoneUniqueEdit(editpersonViewModel.ID, existingPerson.ID)
                )
            {
                // Your update logic
                _personService.EditPerson(existingPerson,editpersonViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                // Set a validation error
                ModelState.AddModelError("ID","The ID,Email,Phone must be unique.");
                return View(editpersonViewModel);
            }
        }



		[HttpGet]
		public IActionResult Delete(string id)
		{
            var person = _personService.GetPersonById(id);

            // If the person is not found, return NotFound
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Person person)
        {
            _personService.DeletePerson(person.ID);

            return RedirectToAction("Index");
        }
    }


}

