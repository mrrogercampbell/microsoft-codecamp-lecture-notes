using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.Data;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"employer", "Employer"},
            {"skill", "Skill"}
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "employer",
            "skill"
        };

        private JobDbContext context;

        public ListController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.employers = context.Employers.ToList();
            ViewBag.skills = context.Skills.ToList();
            return View();
        }

        // list jobs by column and value
        public IActionResult Jobs(string column, string value)
        {
            List<Job> jobs = new List<Job>();
            List<JobDetailViewModel> displayJobs = new List<JobDetailViewModel>();

            if (column.ToLower().Equals("all"))
            {
                jobs = context.Jobs
                    .Include(j => j.Employer)
                    .ToList();

                foreach (var job in jobs)
                {
                    List<JobSkill> jobSkills = context.JobSkills
                        .Where(js => js.JobId == job.Id)
                        .Include(js => js.Skill)
                        .ToList();

                    JobDetailViewModel newDisplayJob = new JobDetailViewModel(job, jobSkills);
                    displayJobs.Add(newDisplayJob);
                }

                ViewBag.title = "All Jobs";
            }
            else
            {
                if (column == "employer")
                {
                    jobs = context.Jobs
                        .Include(j => j.Employer)
                        .Where(j => j.Employer.Name == value)
                        .ToList();

                    foreach (Job job in jobs)
                    {
                        List<JobSkill> jobSkills = context.JobSkills
                        .Where(js => js.JobId == job.Id)
                        .Include(js => js.Skill)
                        .ToList();

                        JobDetailViewModel newDisplayJob = new JobDetailViewModel(job, jobSkills);
                        displayJobs.Add(newDisplayJob);
                    }
                }
                else if (column == "skill")
                {
                    List<JobSkill> jobSkills = context.JobSkills
                        .Where(j => j.Skill.Name == value)
                        .Include(j => j.Job)
                        .ToList();

                    foreach (var job in jobSkills)
                    {
                        Job foundJob = context.Jobs
                            .Include(j => j.Employer)
                            .Single(j => j.Id == job.JobId);

                        List<JobSkill> displaySkills = context.JobSkills
                            .Where(js => js.JobId == foundJob.Id)
                            .Include(js => js.Skill)
                            .ToList();

                        JobDetailViewModel newDisplayJob = new JobDetailViewModel(foundJob, displaySkills);
                        displayJobs.Add(newDisplayJob);
                    }
                }
                ViewBag.title = "Jobs with " + ColumnChoices[column] + ": " + value;
            }
            ViewBag.jobs = displayJobs;

            return View();
        }
    }
}
