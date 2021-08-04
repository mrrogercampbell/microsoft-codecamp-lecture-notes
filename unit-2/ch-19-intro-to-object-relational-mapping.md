# Chapter 19: Introduction to Object-Relational Mapping

## Object-Relational Mapping

### Setting Up a Persistent Database
#### MySQL Set Up
1. Open and login to `MySQL Workbench`
2. Create a new schema and name it `coding_events`
3. In the `Administration` tab click `Users and Privileges`
4. Click `Add Account`
   * Can be found towards the bottom left of the `Users and Privileges` window
5. In the `Login Name` field type `coding_events
   * This will be the `name` of the user you are creating
   * When working on small projects it is convention to name the user the same as the database you are creating
6. Create a password and be sure to type it in the `Password` and `Confirm Password` fields
7. Hit `Apply`
8. Click the `Schema Privileges` tab
9. Click the `Select "ALL"` button
   * This will allow you to grant the newly created user full access to the database
10. Hit `Apply`

#### Project Set Up: Visual Studio
* [Starter Code](https://github.com/LaunchCodeEducation/CodingEventsDemo/tree/enums) - The starter code is located on the `enums` branch
* [Solution Code](https://github.com/LaunchCodeEducation/CodingEventsDemo/tree/db-setup) - This is where you can find code that is fully configured

1. Open your project in `Visual Studio`
  * For this demo we will be utilizing the `Coding Event` project
2. In the root level of your project open the `appsettings.json` file and update the file so that it looks as follows:
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
3. Update the `<Password Goes Here>` with the password you provided the `coding_events` user in your `MySQL Workbench`
4. Right click the project folder and click `Manage NuGet Packages..`
5. Search for and install the `Pomelo.EntityFrameworkCore.MySql` and `Microsoft.EntityFrameworkCore.design` package
   * The lecture demos do not tell students to install `Microsoft.EntityFrameworkCore.design` until later but it should be done upfront

#### Install EntityFrameworkCore Tools
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

## Accessing Data
1. Create the `EventDbContext` class in the `Data` dir
2. Extent `DbContext`
3. Import `DbContext`
4. Create the `prop` `DbSet<Event> Events`
5. Import Event class
6. Update the constructor to accept `DbContextOptions<EventDbContext> options` as an `arg`
7. Pass the `options` para to the `:base()` class constructor
8. Open the `Startup.cs` file
9. Update the `ConfigureServices()` method by adding the following code after `services.AddControllersWithViews();`:
```csharp
 services.AddDbContext<EventDbContext>(options =>
                   options.UseMySql(connectionString, serverVersion));
```
<!-- ```csharp
services.AddDbContext<EventDbContext>(options =>
      options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
``` -->
10. Update the `Event` Model
    1. Remove the `_nextId` field
    2. Add a `set` method to the `Id` property
    3. Remove the code inside the `default constructor`

### Migrations
1. Open your terminal
2. Cd to the `project` directory of your `Coding Events` Project
   1. This is why it is important to name the solution directory properly
3. In your terminal run your first Migration: `dotnet ef migrations add InitialMigration`
   * A migration is a set of instructions for your database
5. Then run `dotnet ef database update`
   * Running this command executes the commands listed in your migration(s)

### Data Stores in the Controller
In this section we are going to be reconfiguring our `EventController` to interface with our newly connected Database. With this in mind we will be remove some unneeded files and code.
1. Delete the `EventData.cs` file
   * This files was initially used to mimic our DB, now that we have one we no longer need it
2. Inside the `EventsController.cs` file we need to do some major updates:
   1. Create a private field called `_context`:
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
   2. Add a constructor to the class which accepts a `EventDbContext` as a parameter:
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

Now you have a fully functional application with a persisting DB!!!!