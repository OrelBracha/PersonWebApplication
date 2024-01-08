using CardComWebApplication.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CardComWebApplication.Models
{
    public class EditPersonViewModel
    {

            [Required(ErrorMessage = "ID is required")]
            [RegularExpression(@"^[0-9]{9,9}$", ErrorMessage = "Must be 9 digits long. only numbers ")]
            public string ID { get; set; }


            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Birthdate is required")]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            public Gender? Gender { get; set; }


            [RegularExpression("^[0-9]{9,10}$", ErrorMessage = "Phone must contain 9 or 10 digits, only digits")]
            public string Phone { get; set; }


    }

        
}

