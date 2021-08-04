# Chapter 19: Introduction to Object-Relational Mapping
- [Chapter 19: Introduction to Object-Relational Mapping](#chapter-19-introduction-to-object-relational-mapping)
  - [Object-Relational Mapping](#object-relational-mapping)
  - [Setting Up a Persistent Database](#setting-up-a-persistent-database)
    - [Part 1: Install EntityFrameworkCore CLI Tools](#part-1-install-entityframeworkcore-cli-tools)
    - [Part 2: Create and Configure a MySQL Database Via MySQL Workbench](#part-2-create-and-configure-a-mysql-database-via-mysql-workbench)
    - [Part 3: Notes On The Codebase](#part-3-notes-on-the-codebase)
    - [Part 4.1: Install NeGet Packages - If You Used Your Own Project Code](#part-41-install-neget-packages---if-you-used-your-own-project-code)
      - [Part 4.1: Configure The Startup.cs File - If You Used Your Own Project Code](#part-41-configure-the-startupcs-file---if-you-used-your-own-project-code)
      - [Part 4.2: Configure The appsettings.json File - If You Used The LaunchCode Starter Code](#part-42-configure-the-appsettingsjson-file---if-you-used-the-launchcode-starter-code)
      - [Part 4.2: Configure The Startup.cs File - If You Used The LaunchCode Starter Code](#part-42-configure-the-startupcs-file---if-you-used-the-launchcode-starter-code)
    - [Part 5: Create and Configure DbContext](#part-5-create-and-configure-dbcontext)
    - [Part 6: Update The `Event` Model](#part-6-update-the-event-model)
    - [Part 7: Migrations](#part-7-migrations)
    - [Part 8: Data Stores in the Controller](#part-8-data-stores-in-the-controller)
    - [Conclusion](#conclusion)
## Object-Relational Mapping

## Setting Up a Persistent Database
### Part 1: Install EntityFrameworkCore CLI Tools
* **Gotchas**:
  * You only need to perform this set of steps once
  * After performing these steps any other time you create a MVC project you will not need to do this
* **Instructions**:
  1. Open your terminal
     * Mac users open the `terminal` program
     * Windows users open `PowerShell`
  2. In the terminal run the following command: `dotnet tool install -g dotnet-ef`
     * If you get an output saying `Tool 'dotnet-ef' is already installed.` that is ok
     * If it installs the program, that is also ok
     * **MAC USERS:** Once you install `dotnet-ef` complete the following steps:
       1. In your terminal run this command: `code ~/.bash_profile`
       2. Add this line of code to the file: `export PATH="$PATH:$HOME/.dotnet/tools/"`
       3. Save and close the file
       4. Back in your terminal run the following command: `source ~/.bash_profile`
       5. Run the following command to test if everything is functional `dotnet ef`
          * You should see an image of a unicorn show up in your terminal
  3. That's it your done!

### Part 2: Create and Configure a MySQL Database Via MySQL Workbench
1. Open and login to `MySQL Workbench`
2. Create a new schema and name it `coding_events`
3. In the `Administration` tab click `Users and Privileges`
4. Click `Add Account`
   * Can be found towards the bottom left of the `Users and Privileges` window
5. In the `Login Name` field type `coding_events`
   * This will be the `name` of the user you are creating
   * When working on small projects it is convention to name the user the same as the database you are creating
6. In the `Limit to Host Matching` field update it to contain `localhost`
7. Create a `password` and be sure to type it in the `Password` and `Confirm Password` fields
8. Hit `Apply`
9. Click the `Schema Privileges` tab
10. Click `Add Entry`
11. Click the `Select schema` checkbox
    * Then click the dropdown menu and select `coding_events`
    * Click `OK`
12. Click the `Select "ALL"` button
   * This will allow you to grant the newly created user full access to the database
11. Hit `Apply`

### Part 3: Notes On The Codebase
* If you created your own MVC app when we started the MVC video tutorials, you are more than welcome to continue using that code
* Also you have the option to use the `Starter Code` that `LaunchCode` provides:
  * [LaunchCode Starter Code](https://github.com/LaunchCodeEducation/CodingEventsDemo/tree/enums) - The starter code is located on the `enums` branch
* **GOTCHAS**:
  * Based on wether or not you use the provided `LaunchCode Starter Code` above there is a difference in how you configure the `connection between` your `MVC App` and `MySQL Database`
    * Due to this I have provided two different set of instructions for `Part 5: Configure the Connection Between Your MVC App and MySQL Database` which are:
      1. If You Used Your Own Project Code: Start at [Part 4.1: Install NeGet Packages - If You Used Your Own Project Code](#part-41-configure-the-startupcs-file---if-you-used-your-own-project-code)
      2. If You Used The LaunchCode Starter Code:  Start at [Part 4.2: Configure The appsettings.json File - If You Used The LaunchCode Starter Code](#part-42-configure-the-appsettingsjson-file---if-you-used-the-launchcode-starter-code)

### Part 4.1: Install NeGet Packages - If You Used Your Own Project Code
1. Open your project in `Visual Studio`
  * For this demo we will be utilizing the `Coding Event` project
2. Right click the project folder and click `Manage NuGet Packages..`
3. Search for and install the `Pomelo.EntityFrameworkCore.MySql` and `Microsoft.EntityFrameworkCore.design` package
   * The lecture demos do not tell students to install `Microsoft.EntityFrameworkCore.design` until later but it should be done upfront
#### Part 4.1: Configure The Startup.cs File - If You Used Your Own Project Code
1.  Open the `Startup.cs` file
2.  Update the `ConfigureServices()` method by adding the following code after `services.AddControllersWithViews();`:
```csharp
public void ConfigureServices(IServiceCollection services)
{
   services.AddControllersWithViews();

   string connectionString = "server=localhost;userid=coding_events;password=<Password Goes Here>;database=coding_events;";
   var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

   services.AddDbContext<EventDbContext>(options =>
          options.UseMySql(connectionString, serverVersion));
}
```
3. Update the `<Password Goes Here>` value within the `connectionString` variable with your `DB User Password`
   * This is the one you created in `Part 2: Create and Configure a MySQL Database Via MySQL Workbench - Step 7`
4. Move on to [Part 5: Create and Configure DbContext](#part-5-create-and-configure-dbcontext)

#### Part 4.2: Configure The appsettings.json File - If You Used The LaunchCode Starter Code
1. In the root level of your project open the `appsettings.json` file and update the file so that it looks as follows:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;userid=coding_events;password=<Password Goes Here>;database=coding_events;"
  }
}
```
2. Update the `<Password Goes Here>` with the password you provided the `coding_events` user in your `MySQL Workbench`

#### Part 4.2: Configure The Startup.cs File - If You Used The LaunchCode Starter Code
1.  Open the `Startup.cs` file
3.  Update the `ConfigureServices()` method by adding the following code after `services.AddControllersWithViews();`:
```csharp
public void ConfigureServices(IServiceCollection services)
{
   services.AddControllersWithViews();

   services.AddDbContext<EventDbContext>(options =>
      options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
}
```

### Part 5: Create and Configure DbContext
1. Inside the `Data` directory, create the a class called `EventDbContext`
2. The `EventDbContext` class should extent a class called `DbContext`:
```csharp
 public class EventDbContext : DbContext
 {
     // All the Code...
 }
```
3. Import `DbContext`
```csharp
using Microsoft.EntityFrameworkCore;
```
4. Create a `public prop` called `Events` which stores `DbSet<Event>`
```csharp
public DbSet<Event> Events { get; set; }
```
5. Import `Event Model` class
```csharp
using UseTheProperNameSpace.Models; // Be sure to use the correct namespace here
```
6. Update the `default constructor` with the following code:
```csharp
public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
{
}
```

### Part 6: Update The `Event` Model
1. Open the `Event.cs` file
2. Remove the `_nextId` field
3. Add a `set` method to the `Id` property
```csharp
public int Id { get; set; }
```
4. Remove the code inside the `default constructor`
```csharp
public Event()
{
}
```
5. Remove the `:this()` syntax from the overloaded constructor
   * If you would like you can actually remove the overloaded constructor all together
```csharp
public Event(string name, string description, string contactEmail)
{
   this.Name = name;
   this.Description = description;
   this.ContactEmail = contactEmail;
}
```
### Part 7: Migrations
1. Open your a separate terminal window
2. Cd to the `project` directory of your `Coding Events` Project
   1. This is why it is important to name the solution directory properly
3. In your terminal run your first Migration: `dotnet ef migrations add InitialMigration`
   * A migration is a set of instructions for your database
5. Then run `dotnet ef database update`
   * Running this command executes the commands listed in your migration(s)

### Part 8: Data Stores in the Controller
In this section we are going to be reconfiguring our `EventController` to interface with our newly connected Database. With this in mind we will be remove some unneeded files and code.

1. Delete the `EventData.cs` file
   * This files was initially used to mimic our DB, now that we have one we no longer need this file
2. Inside the `EventsController.cs` file we need to do some major updates:
   1. Create a private field called `_context` which stores `EventDbContext` object:
```csharp
namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext _context;
        // ... All the other code
    }
}
```
   2. Add a constructor to the class which accepts a `EventDbContext dbContext` as a parameter and sets the `_context` field to its value:
```csharp
public EventsController(EventDbContext dbContext)
{
   _context = dbContext;
}
```
   3. Inside the `Index()` action remove the `List<Event>` and replace it with:
```csharp
List<Event> events = _context.Events.ToList();
```
   4. Inside the `Add() Post` action remove the `EventData.Add(newEvent)` syntax and replace it with:
```csharp
_context.Events.Add(newEvent); // This stages the data
_context.SaveChanges(); // This actually saves the data in the DB
```
   5. Inside the `Delete() Get` action remove the `ViewBag.events = EventData.GetAll();` and replace it with:
```csharp
ViewBag.events = _context.Events.ToList();
```
   6. Inside the `Delete() Post` action remove the `EventData.Remove(eventId);` and update the action so it looks as follows:
```csharp
[HttpPost]
public IActionResult Delete(int[] eventIds)
{
   foreach(int eventId in eventIds)
   {
       Event theEvent = _context.Events.Find(eventId);
       _context.Events.Remove(theEvent);
   }

   _context.SaveChanges();

   return Redirect("/Events");
}
```
### Conclusion
* That's it!!
* Now you have a fully functional application with a persisting DB!!!!
* Try running your app:
  * Create 4 new Event records
  * Delete 2 of them
  * Stop you app from running
  * Restart your app and you will see that the data persist
