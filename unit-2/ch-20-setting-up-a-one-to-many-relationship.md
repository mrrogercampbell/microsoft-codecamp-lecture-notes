# Chapter 20: Setting Up a One-to-Many Relationship
**Gotchas**:
* Be sure to have all solution code for from Chapter 19 Exercise and Studio in your codebase before starting this lecture
* Also student will need to have completed the Exercise and Studios for chapter 19 to have enough context to walk through this lecture.
* Might be worth doing a review on that codebase before starting this lecture...

- [Chapter 20: Setting Up a One-to-Many Relationship](#chapter-20-setting-up-a-one-to-many-relationship)
  - [Setting Up the Relationship](#setting-up-the-relationship)
    - [Update the Event Model](#update-the-event-model)
    - [Update the EventCategory Model](#update-the-eventcategory-model)
    - [Update the AddEventViewModel](#update-the-addeventviewmodel)
    - [Update the EventsController](#update-the-eventscontroller)
    - [Update the Events Add.cshtml](#update-the-events-addcshtml)
    - [Delete the EventType Model](#delete-the-eventtype-model)
  - [Refactoring the Controller and View](#refactoring-the-controller-and-view)
    - [Update the EventsController](#update-the-eventscontroller-1)
    - [Update the Events Index.cshtml File](#update-the-events-indexcshtml-file)
  - [Migrations and Testing](#migrations-and-testing)
    - [Truncate Your Events Database](#truncate-your-events-database)
    - [Testing to See if it Worked](#testing-to-see-if-it-worked)
  - [Event Details View and Tag Model](#event-details-view-and-tag-model)
    - [Initial Setup: Creating the Tag Resource](#initial-setup-creating-the-tag-resource)
    - [The EventTag Model](#the-eventtag-model)
  - [Adding a Tag to an Event](#adding-a-tag-to-an-event)
## Setting Up the Relationship
### Update the Event Model
1. Delete the `EventType` property
2. Replace it with `public EventCategory Category { get; set; }`
3. Then add `public int CategoryId { get; set; }` below it

### Update the EventCategory Model
1. Create a new property `public List<Event> Events { get; set; }`


### Update the AddEventViewModel
1. Delete the `public EventType Type { get; set; }` property
2. Replace it with
```csharp
[Required(ErrorMessage = "Category is Required")]
public int CategoryId { get; set; }
```
   1. Be sure to make notes on this
3. Then add `public List<SelectListItem> Categories { get; set; }`
4. Delete all the code for the `public List<SelectListItem> EventTypes { get; set; }` property
5. Next add the following constructor:
```csharp
        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach(var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    }
                );
            };
        }
```
6. Also add a default constructor:
```csharp
public AddEventViewModel() { }
```

### Update the EventsController
1. Update the `Get Add()` action so that you are passing the `List<EventCategory>` objects to the ViewModel.
```csharp
[HttpGet]
public IActionResult Add()
{
   List<EventCategory> categories = _context.Categories.ToList();

   AddEventViewModel addEventViewModel = new AddEventViewModel(categories);

   return View(addEventViewModel);
}
```
2. Update the `Post Add()` action by:
   1. Create a `EventCategory theCategory` variable that stores the actually `CategoryId` that is passed in via the `ViewModel`:
```csharp
if(ModelState.IsValid)
{
    EventCategory theCategory = _context.Categories.Find(addEventViewModel.CategoryId);
    //... The Rest of the code
}
```
   2. Replace the `Type = addEventViewModel.Type` with the following:
```csharp
Event newEvent = new Event
{
    // ... The other properties,
    Category = theCategory
};
```
### Update the Events Add.cshtml
1. Replace all reference to the `Type` & `EventType` properties with `CategoryId` and `Categories` respectively:
```html
<div class="form-group">
  <label asp-for="CategoryId">Category</label>
  <select asp-for="CategoryId" asp-items="Model.Categories"></select>
</div>
```
### Delete the EventType Model
1. Just as the heading says... Delete the EventType Model

## Refactoring the Controller and View
### Update the EventsController
1. Update `Index` action so its code looks as follows:
```csharp
[HttpGet]
public IActionResult Index()
{

   List<Event> events = _context.Events
       .Include(e => e.Category )
       .ToList();

   return View(events);
}
```

### Update the Events Index.cshtml File
1. Update the `Table Header <th> tag` that says `Event Type` to `Category`
```html
<th>
    Category
</th>
```
2. Update the `<td scope="row">@evt.Type</td>` to the following:
```html
<td>@evt.Category.Name</td>
```
## Migrations and Testing
### Truncate Your Events Database
1. Open `MySQL Workbench`
2. Navigate to your `Events Database`
3. Right click the `Events table` name
4. Select the `Truncate Table...` option
   * This will remove all records from your `Table`
      * Due to the fact that we removed the `Type` property from our `Event Model` and replaced it with a reference to the `Category Model` that column no longer exist
      * If we were to attempt to run a newly created `Migrate` on our Database we would receive quite a few errors due to the change mentioned above
      * There are advance ways for us to handle a change like this to our `Model` without `truncating` our Database but that is outside the scope of this lesson
5. Open the within your `CodingEvents` project open the terminal and `cd` into the `Project` directory
6. Create a new migration: `dotnet ef migrations add RelateEventsAndCategories`
7. Then run the newly created migration: `dotnet ef database update`
8. At this point if you go back to `MySQL Workbench` and refresh the `Schema tab` you will see that the `Events table` has been updated

### Testing to See if it Worked
1. Now go ahead and run your application
2. Create two new `Category` records
3. Then created two new `Event` records
4. Now if you run a `SELECT * FROM` both tables (Events and Category) you will see that the `Event` table is able to reference a record from the `Category` table based on an `ID`

## Event Details View and Tag Model
### Initial Setup: Creating the Tag Resource
1. To start we need to add a couple new files:
   1. Create a new model called `Tag`
```csharp
public class Tag
{
  public int Id { get; set; }
  public string Name { get; set; }

  public Tag()
  {
  }
}
```
   2. Next, let's create a `TagController.cs`
```csharp
public class TagController : Controller
{
  private EventDbContext _context;

  public TagController(EventDbContext dbContext)
  {
      _context = dbContext;
  }

  // GET: /<controller>/
  public IActionResult Index()
  {
      List<Tag> tags = _context.Tags.ToList();

      return View(tags);
  }

  [HttpGet]
  public IActionResult Add()
  {
      AddTagViewModel addTagViewModel = new AddTagViewModel();

      return View(addTagViewModel);
  }

  [HttpPost]
  public IActionResult Add(AddTagViewModel addTagViewModel)
  {
      if(ModelState.IsValid)
      {
          Tag newTag = new Tag
          { Name = addTagViewModel.Name };

          _context.Tags.Add(newTag);
          _context.SaveChanges();

          return Redirect("/Tag");
      }

      return View(addTagViewModel);
  }
}
```
   3. Then, we need to create a `ViewModel` for our `Detail() action` which we will call `EventDetailViewModel.cs`
```csharp
public class EventDetailViewModel
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string ContactEmail { get; set; }
  public string CategoryName { get; set; }

  public EventDetailViewModel(Event theEvent)
  {
      this.Name = theEvent.Name;
      this.Description = theEvent.Description;
      this.ContactEmail = theEvent.ContactEmail;
      this.CategoryName = theEvent.Category.Name;
  }
}
```
   4. Next we need to create a `Detail()` Action in our `EventsController`:
```csharp
[HttpGet]
public IActionResult Detail(int id)
{
   Event theEvent = _context.Events
      .Include(e => e.Category)
      .FirstOrDefault(e => e.Id == id);

   EventDetailViewModel viewModel = new EventDetailViewModel(theEvent);


   return View(viewModel);
}
```
   * In the book they tell students to use `Single()` instead of `FirstOrDefault()`
     * The `Single()` Method no longers works properly. They need to use `FirstOrDefault()` instead.
   5. Then we need to create two new `Views`;
      1. `Index`
```html
<!-- Index.cshtml -->
@using CodingEvents.Models
@model List<Event>

<h1>Coding Events</h1>

<p>
    <a asp-controller="Events" asp-action="Add">Add Event</a>
</p>

<p>
    <a asp-controller="Events" asp-action="Delete">Delete Events</a>
</p>

@if (Model.Count == 0)
{
    <p>No Events Yet!</p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Event Name</th>
                <th scope="col">Event Description</th>
                <th scope="col">Event Owners Email</th>
                <th scope="col">Event Category</th>
            </tr>
        </thead>
        <tbody>
            @foreach (Event evt in Model)
            {
            <tr>
                <td scope="row">@evt.Id</td>

                <td scope="row">
                    <a asp-controller="Events"
                       asp-action="Detail"
                       asp-route-eventId="@evt.Id"
                       >
                        @evt.Name
                    </a>
                </td>
                <td scope="row">@evt.Description</td>
                <td scope="row">@evt.ContactEmail</td>
                <td>@evt.Category.Name</td>

            </tr>
            }
        </tbody>
    </table>
}

<partial name="/Views/Shared/_LinkListPartial.cshtml" />
```
      1. `Detail`:
```html
<!-- Detail.cshtml -->
@model CodingEvents.ViewModels.EventDetailViewModel

<h1>@Model.Name</h1>

<table class="table">
    <tr>
        <th>Description</th>
        <td>@Model.Description</td>
    </tr>
    <tr>
        <th>Contact Email</th>
        <td>@Model.ContactEmail</td>
    </tr>
    <tr>
        <th>Category</th>
        <td>@Model.CategoryName</td>
    </tr>
</table>
```
   5. The last step is to create the `AddTagViewModel`:
```csharp
public class AddTagViewModel
{
  [Required(ErrorMessage ="A Name is required")]
  [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
  public string Name { get; set; }
}
```
### The EventTag Model
1. Create a new `Model` called `EventTag`
```csharp
public class EventTag
{
  public int EventId { get; set; }
  public Event Event { get; set; }

  public int TagId { get; set; }
  public Tag Tag { get; set; }

  public EventTag()
  {
  }
}
```
2. Add the new `Model` to the `DbContext`
```csharp
public class EventDbContext : DbContext
 {
     // ... The other Props
     public DbSet<EventTag> EventTags { get; set; }

     // ... The Constructor
 }
```
3. Within the `DbContext` class add an `Overridden OnModelCreating()`:
```csharp
public class EventDbContext : DbContext
 {
     // ... The Props

     // ... The Constructor

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTag>().HasKey(et => new { et.EventId, et.TagId });
    }
 }
```
   * This method allows us to define what is called `Composite Primary Key`
4. Run `Database Migrations`:
   1. `dotnet ef migrations add AddsEventTag`
   2. `dotnet ef database update`

## Adding a Tag to an Event
1. Create a `AddEventTagViewModel.cs` file
```csharp
public class AddEventTagViewModel
{
  public int EventId { get; set; }
  public Event Event { get; set; }

  public List<SelectListItem> Tags{ get; set; }

  public int TagId { get; set; }

  public AddEventTagViewModel(){}

  public AddEventTagViewModel(Event theEvent, List<Tag> possibleTags)
  {
      this.Tags = new List<SelectListItem>();

      foreach(var tag in possibleTags)
      {
          this.Tags.Add(new SelectListItem
          {
              Value = tag.Id.ToString(),
              Text = tag.Name
          });
      }

      this.Event = theEvent;
  }
}
```
2. Create a new View within the `Tag` directory called `AddEvent.cshtml`
```html
@model CodingEvents.ViewModels.AddEventTagViewModel

<h1>Add Tag to Event: @Model.Event.Name</h1>

<form asp-controller="Tag" asp-action="AddEvent" method="post">
    <input type="hidden" value="@Model.Event.Id" name="EventId" />
    <div class="form-group">
        <label asp-for="TagId">Tag</label>
        <select asp-for="TagId" asp-items="Model.Tags"></select>
        <span asp-validation-for="TagId"></span>
    </div>
    <input type="submit" value="Add Tag" />
</form>
```
3. Create an `Get: AddEvent()` Action in the `TagController.cs` file
```csharp
public IActionResult AddEvent(int id)
{
   Event theEvent = _context.Events.Find(id);

   List<Tag> possibleTags = _context.Tags.ToList();

   AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);

   return View(viewModel);
}
```
4. Create a `Post: AddEvent()` Action in the `TagController.cs` file
```csharp
 [HttpPost]
public IActionResult AddEvent(AddEventTagViewModel viewModel)
{
   if(ModelState.IsValid)
   {
       int eventId = viewModel.EventId;
       int tagId = viewModel.TagId;

       EventTag eventTag = new EventTag
       {
           EventId = eventId,
           TagId = tagId
       };

       _context.EventTags.Add(eventTag);
       _context.SaveChanges();

       return Redirect($"/Events/Detail/{eventId}");
   }

   return View(viewModel);
}
```