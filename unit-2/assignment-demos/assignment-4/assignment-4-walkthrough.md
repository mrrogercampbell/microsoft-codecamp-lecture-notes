# Assignment 4

## Part 1: Connect a Database to an ASP.NET App
1. Start MySQL Workbench and create a new schema named `techjobs`.
   * **Answer**: Just do as the instruction as and open `MySQL Workbench` and create a new `Schema`
       * You can find a walk-through on this in [Chapter 19 - Part 2: Create and Configure a MySQL Database Via MySQL Workbench](ch-19-intro-to-object-relational-mapping.md#part-2-create-and-configure-a-mysql-database-via-mysql-workbench)
2. In the administration tab, create a new user, `techjobs` with the same settings as described in the lesson tutorial.
* **Answer**: Just do as the instruction as and open `MySQL Workbench` and access the `Administration` tab and  follow the steps in [Chapter 19 - Part 2: Create and Configure a MySQL Database Via MySQL Workbench](ch-19-intro-to-object-relational-mapping.md#part-2-create-and-configure-a-mysql-database-via-mysql-workbench)
3. Make sure that TechJobsPersistent has all of the necessary dependencies.
   * **Answer**: You need to install `Pomelo.EntityFrameworkCore.MySql` and `Microsoft.EntityFrameworkCore.design` via the `Manage NuGet Packages..` tab. See the link above for instructions.
4. Read through the code that is currently in JobDbContext to get an idea for what the database will look like.
   * Do just as the instructions say and look at the codebase!
5. Update `appsettings.json` with the right info. This will include the name of the database, as well as the username and password for a user you have created.
   * Depending on whether you upgraded the `Pomelo.EntityFrameworkCore.MySql` NuGet Package or not will dictate which set of instruction you need to follow:
     * [Pomelo.EntityFrameworkCore.MySql Version 3.1](ch-19-intro-to-object-relational-mapping.md#part-42-configure-the-appsettingsjson-file---if-you-used-the-launchcode-starter-code)
     * [Pomelo.EntityFrameworkCore.MySql Version 5.1](ch-19-intro-to-object-relational-mapping.md#part-41-configure-the-startupcs-file---if-you-used-your-own-project-code)
       * This walk through follows the Version 5.1 instructions
   * **Answer**: You do not need to do this step for the `5.1` solution
6. Check that ConfigureServices in Startup.cs includes the configuration for the database.
   * **Answer**: Inside the `Startup.cs` file add the following code:
```csharp
// ~/Startup.cs

public void ConfigureServices(IServiceCollection services)
{
   // the AddControllersWithViews()

   string connectionString = "server=localhost;userid=techjobs;password=codingisthebeast;database=techjobs;";
   var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

   services.AddDbContext<JobDbContext>(options =>
          options.UseMySql(connectionString, serverVersion));
}
```
### Part 1: Test it with SQL
1. In your MySQL workbench, open a new query tab to check your database connection.
   * **Answers**:
     * Based on the instructions provided, I do not understand how they want you to be able to see the different `tables` without creating and then running a `migration`
     * With that said to accomplish this you can:
       1. `dotnet ef migrations add InitialMigration`
       2. `dotnet ef database update`
2. **SQL TASK**: At this point, you will have tables for Jobs, Employers, Skills, and JobSkills. In queries.sql under “Part 1”, list the columns and their data types in the Jobs table.
   * Answers:
     * Employers.Id = int | Employers.Location = longtext | Employers.Name = longtext
     * Jobs.EmployerId = int | Jobs.Id = int | Jobs.Name = longtext
     * JobSkills.JobId = int | JobSkills.SkillId = int
     * Skills.Description = longtext | Skills.Id = int | Skills.Name = longtext

## Part 2: Adding Employers
You will need to have completed the [Part 1: Connect a Database to an ASP.NET AppPart 1: Connect a Database to an ASP.NET App](#part-1-connect-a-database-to-an-aspnet-app) steps before starting this section.

### Part 2: ViewModels
1. Create a new `ViewModel` called `AddEmployerViewModel` that has 2 properties: `Name` and `Location`.
2. Add validation to both properties in the ViewModel so that both properties are required.
```Csharp
// ~/ViewModels/AddEmployerViewModel

public class AddEmployerViewModel
{
    [Required(ErrorMessage ="A Name is required for every Employer")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A Location is required for every Employer")]
    public string Location { get; set; }

    public AddEmployerViewModel(){}
}
```
### Part 2: Controllers
EmployerController contains four relatively empty action methods. Take the following steps to handle traffic between the views and the model:

1. Set up a private DbContext variable so you can perform CRUD operations on the database. Pass it into a EmployerController constructor.
```csharp
// ~/Controllers/EmployerController
public class EmployerController : Controller
{
    private DbContext _context { get; set; }

    public EmployerController(JobDbContext dbContext)
    {
        this._context = dbContext;
    }
}
```
2. Complete Index() so that it passes all of the Employer objects in the database to the view.
```csharp
// ~/Controllers/EmployerController
public IActionResult Index()
{
   List<Employer> employers = _context.Employers.ToList();

   return View(employers);
}
```
3. Create an instance of AddEmployerViewModel inside of the Add() method and pass the instance into the View() return method.
```csharp
// ~/Controllers/EmployerController

public IActionResult Add()
{
   AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();

   return View(addEmployerViewModel);
}
```
4. Add the appropriate code to ProcessAddEmployerForm() so that it will process form submissions and make sure that only valid Employer objects are being saved to the database.
```csharp
// ~/Controllers/EmployerController

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
```
5. About() currently returns a view with vital information about each employer such as their name and location. Make sure that the method is actually passing an Employer object to the view for display.
```csharp
// ~/Controllers/EmployerController

public IActionResult About(int id)
{
    Employer employer = _context.Employers.Find(id);

    return View(employer);
}
```

### Part 2: Views
The starter code comes with 3 views in the `Employer` subdirectory. Read through the code in each view. You may have to add models or make sure naming is consistent between the controller and the view.
1. `Index.cshtml`: This file is fine the way it is.
2. `Add.cshtml`: 3 parts need to be updated:
   1. Add the `@model`
   2. Add the `asp-for` for each `label` and `input` tag
```html
<!-- ~/Views/Employer/Add.cshtml -->
@model TechJobsPersistent.ViewModels.AddEmployerViewModel

<h1>Add New Employer</h1>

<form
      asp-controller="Employer"
      asp-action="ProcessAddEmployerForm"
      method="post"
 >
    <div class="form-group">
        <label asp-for="Name">Employer Name</label>
        <input asp-for="Name"/>
    </div>

    <div class="form-group">
        <label asp-for="Location">Employer Location</label>
        <input asp-for="Location"/>
    </div>

    <input type="submit" value="Submit" />
</form>
```
3. `About.cshtml`: 3 parts need to be updated:
   1. Add the `@model`
   2. Replace the `h1` tag's `Name` for `@Model.Name`
   3. Replace the `p` tag's`name` for `@Model.Name`
   4. Replace the `p` tag's `location` for `@Model.Location`
```html
<!-- ~/Views/Employer/About.cshtml -->
@model TechJobsPersistent.Models.Employer

<h1>Employer: @Model.Name</h1>

<div>
    <p>Name: @Model.Name</p>
    <p>Location: @Model.Location</p>
</div>
```

### Part 2: Adding a Job
One important feature of your application is a form to add a new job. Two action methods in HomeController, AddJob() and ProcessAddJobForm(), will work together to return the view that contains the form and handle form submission. In the Home subdirectory in Views, you will find an AddJob.cshtml file which contains the beginning of the form. Right now, there is only one field to the form and that is for the job’s name. As you work on the application, you will add more fields to this form to add employer and skill info.

1. Create a new ViewModel called AddJobViewModel. You will need properties for the job’s name, the selected employer’s ID, and a list of all employers as SelectListItem.
```csharp
// ~/ViewModels/AddJobViewModel.cs

public class AddJobViewModel
{
    [Required(ErrorMessage ="A Name is required")]
    public string Name { get; set; }

    public int EmployerId { get; set; }

    public List<SelectListItem> Employers { get; set; }

    public AddJobViewModel(){}

    public AddJobViewModel(List<Employer> employers)
    {
        this.Employers = new List<SelectListItem>();

        foreach(Employer employer in employers)
        {
            this.Employers.Add(
                new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
        }
    }
}
```

2. In `AddJob()` pass an instance of `AddJobViewModel` to the view.
```csharp
// ~/Controllers/HomeController.cs

[HttpGet("/Add")]
public IActionResult AddJob()
{
    List<Employer> employers = _context.Employers.ToList();

    AddJobViewModel addJobViewModel = new AddJobViewModel(employers);

    return View(addJobViewModel);
}
```
3. In `AddJob.cshtml`, add a new `<div class="form-group">` element to the form. Add the appropriate `<label>` and `<input>` tags to the new `<div>` element to create the form field to add employer information to the job. This field should be a dropdown menu with all of the employers in the database. In addition, add a link to the `<div>` element to add new employers. This way, if a user doesn’t see the employer they are looking for, they can easily click on the link and add a new employer to the database.
   * **Answers**:
     1. Add the `@model` so that the view expects the `AddJobViewModel`
     2. Update the first `<div class="form-group">` element so that its child elements: `label`, `input`, and `span` are all linked to the `Name` property within the `AddJobViewModel`
     3. Create a new `<div class="form-group">` element and provide it two child elements: `label` amd `select`
        * `label`: will need to utilize the `asp-for` helper
        * `select`: will need to utilize the `asp-for` and `asp-items` helpers
     4. Below the closing `form` element create an `a` element that utilizes the `asp-controller` and `asp-action` helpers
```html
<!-- ~/Views/Home/AddJob.cshtml -->

@model TechJobsPersistent.ViewModels.AddJobViewModel

<h1>Add a Job</h1>

<form asp-controller="Home"
      asp-action="ProcessAddJobForm"
      method="post">
    <div class="form-group">

        <label asp-for="Name">Name</label>

        <input class="form-control" asp-for="Name" />

        <span asp-validation-for="Name"></span>

    </div>

    <div class="form-group">
        <label asp-for="EmployerId">Employer</label>

        <select asp-for="EmployerId" asp-items="Model.Employers">
        </select>
    </div>

    <input type="submit" value="Add Job" />
</form>

<a asp-controller="Employer" asp-action="Add">Create a New Employer</a>
```

4. In `ProcessAddJobForm()`, you need to take in an instance of `AddJobViewModel` and make sure that any validation conditions you want to add are met before creating a new `Job` object and saving it to the database.
```csharp
// ~/Controllers/HomeController.cs

public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel)
{
    Employer theEmployer = _context.Employers.Find(addJobViewModel.EmployerId);

    if(ModelState.IsValid)
    {
        Job newJob = new Job
        {
            Name = addJobViewModel.Name,
            EmployerId = addJobViewModel.EmployerId,
            Employer = theEmployer
        };

        _context.Jobs.Add(newJob);
        _context.SaveChanges();

        return Redirect("Index");
    }

    return View(addJobViewModel);
}
```
### Part 2: Test It with SQL
Before you move on, test your application now to make sure it runs as expected. You should be able to create Employer objects and view them.

1. Open MySQL Workbench and make sure you have an Employers table and that it is empty.
2. Start up your application – don’t forget to have your SQL server running – and go to the Add Jobs view.
3. You won’t be able to add a job yet, but you’ll see a link to Add Employers in the form. Click on it and proceed to check the functionality of the form that follows.
4. Be sure to test your validation requirements and error handling.
   * **Answers**: for questions 1-4 just test your code
5. SQL TASK: In queries.sql under “Part 2”, write a query to list the names of the employers in St. Louis City.
   * **Answers**:
```sql
-- ~/queries.sql
SELECT Name FROM Employers WHERE Location = "St. Louis City";
```

## Part 3: Working with a Many-To-Many Relationship
### Part 3: Updating AddJobViewModel
In order to add additional functionality to the form for adding a job, we need to add properties to `AddJobViewModel`.

1. Add a property for a list of each `Skill` object in the database.
    * **Answer**:
```csharp
// ~/ViewModels/AddJobViewModel.cs

public class AddJobViewModel
{
    // ... The other props

    public List<Skill> Skills { get; set; }
}
```
2. Previously, in an `AddJobViewModel` constructor, you probably set up a `SelectListItem` list of `Employer` information. Pass another parameter of a list of `Skill` objects. Set the `List<Skill>` property equal to the parameter you have just passed in.
    * **Answer**:
```csharp
// ~/ViewModels/AddJobViewModel.cs

public class AddJobViewModel
{
    public AddJobViewModel(List<Employer> employers, List<Skill> skills)
    {
        this.Skills = skills;

        // The other bit of Constructor code
    }
}
```
* **Full Answer**:
```csharp
// ~/ViewModels/AddJobViewModel.cs

public class AddJobViewModel
{
    [Required(ErrorMessage ="A Name is required")]
    public string Name { get; set; }
    public int EmployerId { get; set; }
    public List<SelectListItem> Employers { get; set; }
    public List<Skill> Skills { get; set; }

    public AddJobViewModel(){}

    public AddJobViewModel(List<Employer> employers, List<Skill> skills)
    {
        this.Skills = skills;
        this.Employers = new List<SelectListItem>();

        foreach (Employer employer in employers)
        {
            this.Employers.Add(
                new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
        }
    }
}
```
### Part 3: Updating HomeController
You next need to update `HomeController` so that skills data is being shared with the form and that the user’s skill selections are properly handled.

1. In the `AddJob()` method, update the `AddJobViewModel` object so that you pass all of the `Skill` objects in the database to the constructor.
```csharp
// ~/Controllers/HomeController.cs

[HttpGet("/Add")]
public IActionResult AddJob()
{
    List<Employer> employers = _context.Employers.ToList();
    List<Skill> skills = _context.Skills.ToList();

    AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);

    return View(addJobViewModel);
}
```
2. In the `ProcessAddJobForm()` method, pass in a new parameter: an array of strings called `selectedSkills`. When we allow the user to select multiple checkboxes, the user’s selections are stored in a string array. The way we connect the checkboxes together is by giving the `name` attribute on the `<input>` tag the name of the array. In this case, each `<input>` tag on the form for the skills checkboxes should have `"selectedSkills"` as the name.
   * **Answer**:
```csharp
// ~/Controllers/HomeController.cs

public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
```
   1. After you add a new parameter, you want to set up a loop to go through each item in `selectedSkills`. This loop should go right after you create a new `Job` object and before you add that Job object to the database.
      * **Answer**:
```csharp
public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
{
    Employer theEmployer = _context.Employers.Find(addJobViewModel.EmployerId);

    if(ModelState.IsValid)
    {
        // ... Where we created a new job

        foreach(string skill in selectedSkills)
        {

        }
    }
}
```
   2. Inside the loop, you will create a new `JobSkill` object with the newly-created `Job` object. You will also need to parse each item in `selectedSkills` as an integer to use for `SkillId`.
      * **Answer**:
```csharp
// ~/Controllers/HomeController.cs

public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
{
    Employer theEmployer = _context.Employers.Find(addJobViewModel.EmployerId);

    if(ModelState.IsValid)
    {
        // ... Where we created a new job

        foreach(string skill in selectedSkills)
        {
            JobSkill newJobSkill = new JobSkill
            {
                Job = newJob,
                JobId = newJob.Id,
                SkillId = Int32.Parse(skill)
            };
        }
    }
}
```
   3. Add each new `JobSkill` object to the `DbContext` object, but do not add an additional call to `SaveChanges()` inside the loop! One call at the end of the method is enough to get the updated info to the database.
      * **Full Answer**:
```csharp
// ~/Controllers/HomeController.cs

public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
{
    Employer theEmployer = _context.Employers.Find(addJobViewModel.EmployerId);

    if(ModelState.IsValid)
    {
        // ... Where we created a new job

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
    }
}
```
### Part 3: Updating Home/AddJob.cshtml
Now that we have the controller and ViewModel set up, we need to update the form to add a job.

1. Add a new `<div class="form-group">` element to the form for collecting skills.
   * **Answer**:
```html
<!-- ~/Views/Home/AddJob.cshtml -->

<div class="form-group">

</div>
```
2. Loop through each object in the list of `Skill` objects.
   * **Answer**:
```html
<div class="form-group">
  @foreach (Skill skill in Model.Skills)
  {
  }
</div>
```
3. Give each checkbox a label and add the checkbox input itself. Here is an example of how that `<input>` tag might look:
```html
<!-- ~/Views/Home/AddJob.cshtml -->

<input type="checkbox" name="selectedSkills" value="@skill.Id" />
```
   * **Answer**:
```html
<div class="form-group">
  @foreach (Skill skill in Model.Skills)
  {
      <label for="@skill.Id">@skill.Name</label>
      <input
             type="checkbox"
             name="selectedSkills"
             value="@skill.Id"
       />
  }
</div>
```
4. Add a link to the form to add skills to the database so if a user doesn’t see the skills they need, they can add skills themselves!
   * Answer:
```html
<!-- ~/Views/Home/AddJob.cshtml -->

<div>
    <a asp-controller="Skill" asp-action="Add">Create a New Employer</a>
</div>
```

* **Full Answer**:
```html
<!-- ~/Views/Home/AddJob.cshtml -->

@model TechJobsPersistent.ViewModels.AddJobViewModel

<h1>Add a Job</h1>

<form asp-controller="Home"
      asp-action="ProcessAddJobForm"
      method="post">
    <div class="form-group">

        <label asp-for="Name">Name</label>

        <input class="form-control" asp-for="Name" />

        <span asp-validation-for="Name"></span>

    </div>

    <div class="form-group">
        <label asp-for="EmployerId">Employer</label>

        <select asp-for="EmployerId" asp-items="Model.Employers">
        </select>
    </div>

    <div class="form-group">
        @foreach (Skill skill in Model.Skills)
        {
            <label for="@skill.Id">@skill.Name</label>
            <input
                   type="checkbox"
                   name="selectedSkills"
                   value="@skill.Id"
             />
        }
    </div>

    <input type="submit" value="Add Job" />
</form>

<br/>

<div>
    <a asp-controller="Employer" asp-action="Add">Create a New Employer</a>
</div>

<br/>

<div>
    <a asp-controller="Skill" asp-action="Add">Create a New Skill</a>
</div>
```


### Part 3: Test It with SQL
Run your application and make sure you can create a new job with an employer and several skills. You should now also have restored full list and search capabilities.

1. SQL TASK: In queries.sql under “Part 3”, write a query to return a list of the names and descriptions of all skills that are attached to jobs in alphabetical order. If a skill does not have a job listed, it should not be included in the results of this query.
```sql
-- ~/queries.sql

SELECT * FROM Skills
      LEFT JOIN JobSkills ON Skills.Id = JobSkills.SkillId
      WHERE JobSkills.JobId IS NOT NULL
      ORDER BY name ASC;
```

When you are able to add new employers and skills and use those objects to create a new job, you’re done! Congrats!

