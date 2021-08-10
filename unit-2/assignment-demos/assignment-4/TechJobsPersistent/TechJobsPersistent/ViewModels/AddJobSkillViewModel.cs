using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobSkillViewModel
    {
        [Required(ErrorMessage = "Job is required")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Skill is required")]
        public int SkillId { get; set; }

        public Job Job { get; set; }

        public List<SelectListItem> Skills { get; set; }

        public AddJobSkillViewModel(Job theJob, List<Skill> possibleSkills)
        {
            Skills = new List<SelectListItem>();

            foreach (var skill in possibleSkills)
            {
                Skills.Add(new SelectListItem
                {
                    Value = skill.Id.ToString(),
                    Text = skill.Name
                });
            }

            Job = theJob;
        }

        public AddJobSkillViewModel()
        {
        }
    }
}
