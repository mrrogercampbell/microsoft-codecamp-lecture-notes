using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext _context { get; set; }

        public EmployerController(JobDbContext dbContext)
        {
            this._context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = _context.Employers.ToList();

            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();

            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if(ModelState.IsValid)
            {
                Employer newEmployer = new Employer()
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                _context.Employers.Add(newEmployer);
                _context.SaveChanges();

                return Redirect("/Employer");
            }

            return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer employer = _context.Employers.Find(id);

            return View(employer);
        }
    }
}
