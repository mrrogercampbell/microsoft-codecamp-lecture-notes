using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event!")]
        [StringLength(500, MinimumLength =5, ErrorMessage = "Your description must be between 5 and 500 characters")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

    }
}
