using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage ="A Name is required for every Employer")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A Location is required for every Employer")]
        public string Location { get; set; }

        public AddEmployerViewModel()
        {
        }
    }
}
