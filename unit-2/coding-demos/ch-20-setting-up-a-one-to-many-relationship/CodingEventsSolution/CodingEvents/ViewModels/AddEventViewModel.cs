using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must ne between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel() { }

        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();
            {
                // The add method on line 42 in then adding each Category record that is iterated over into the Categories property
                    // <option value="1">Category Name</option>
                    // <option value="2">Category Name 2</option>
                    // <option value="3">Category Name 3</option>

            }

            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name

                        // This loop is creating an Option tag for each Category record that is passed to the constructor:
                        // Example: <option value="1">Category Name</option>
                    }
                );
            };
        }

    }
}
