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
        [StringLength(50, MinimumLength =3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event!")]
        [StringLength(500, MinimumLength =5, ErrorMessage = "Your description must be between 5 and 500 characters")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public EventType Type { get; set; }


        //public List<string> EventTypeString { get; set; } = new List<string>

        static string conferenceString = EventType.Conference.ToString();
        static string conferenceStringNumber = ((int)EventType.Conference).ToString();

        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(
                conferenceString, conferenceStringNumber
                ),
            //<option value="0">Conference</option>

            new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString() ),

            new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString() ),

            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString() )

        };

    }
}
