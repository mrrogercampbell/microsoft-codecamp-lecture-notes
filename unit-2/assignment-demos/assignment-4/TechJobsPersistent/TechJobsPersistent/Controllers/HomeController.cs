using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {   
        private JobDbContext _context;

        public HomeController(JobDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = _context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> employers = _context.Employers.ToList();
            List<Skill> skills = _context.Skills.ToList();

            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);

            return View(addJobViewModel);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel newAddJobViewModel, string[] selectedSkills)
        {
            Employer theEmployer = _context.Employers.Find(newAddJobViewModel.EmployerId);

            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    Name = newAddJobViewModel.Name,
                    EmployerId = newAddJobViewModel.EmployerId,
                    Employer = theEmployer
                };

                foreach(string skill in selectedSkills)
                {
                    JobSkill newJobSkill = new JobSkill
                    {
                        Job = newJob,
                        JobId = newJob.Id,
                        SkillId = Int32.Parse(skill)
                    };

                    _context.JobSkills.Add(newJobSkill);
                }

                _context.Jobs.Add(newJob);
                _context.SaveChanges();

                return Redirect("Index");
            }


            // This is the fix so that the newAddJobViewModel has the data needed to populate the procceding View:
            List<Skill> skills = _context.Skills.ToList();

            newAddJobViewModel.Skills = skills;

            List<Employer> employers = _context.Employers.ToList();

            newAddJobViewModel.createSelectListItems(employers);

            Console.WriteLine(newAddJobViewModel.Skills);

            return View("~/Views/Home/AddJob.cshtml",newAddJobViewModel);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = _context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = _context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
