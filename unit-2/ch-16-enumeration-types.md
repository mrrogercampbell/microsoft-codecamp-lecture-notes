# Chapter 16: Enumeration Types
- [Chapter 16: Enumeration Types](#chapter-16-enumeration-types)
  - [What is an Enum?!](#what-is-an-enum)
  - [Enums in Model Classes](#enums-in-model-classes)
    - [Create an Enum Class](#create-an-enum-class)
    - [Add an Enum Property to a Model Class](#add-an-enum-property-to-a-model-class)
    - [Add an Enum Property to a ViewModel](#add-an-enum-property-to-a-viewmodel)
    - [Add the Enum Values Through the Controller](#add-the-enum-values-through-the-controller)
    - [Update the Add.cshtml View](#update-the-addcshtml-view)
    - [Update the Index.cshtml View](#update-the-indexcshtml-view)
## What is an Enum?!
* Enums are a new data type
* They are similar to a class in structure but are utilized to help you declare fixed data
  * A great use-case if for accepting days of the week

```csharp
using System;
namespace Enums
{
    public enum Day
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
```

```csharp
// Creating a variable called dayOfTheWeek which we set to the value of the enum Day and its value Monday
Day dayOfTheWeek = Day.Monday;

// This doesn't work due to Day being a data type we can not store a string inside of it
Day weekend = "Monday";

// We can get the value from an Enum by doing this
Console.WriteLine(Day.Friday);

Console.Read();
```


## Enums in Model Classes

### Create an Enum Class
1. Inside the `Model` directory create a `Enum` called `EventType`
   * Be sure to use the `enum` template not the `class`
2. Then give it some default values:
```csharp
using System;
namespace CodingEvents.Models
{
    public enum EventType
    {
        Conference,
        Meetup,
        Workshop,
        Social
    }
}
```

### Add an Enum Property to a Model Class
1. Open the `Event` model `~/Models/Event.cs`
2. Add the new created `EventType` enum to the Model as a property
```csharp
using System;
namespace CodingEvents.Models
{
    public class Event
    {
        private static int _nextId = 1;

        // .. The other properties

        public EventType Type { get; set; }

        // ... Rest of the code...
    }
}
```

### Add an Enum Property to a ViewModel
1. Open the `AddEventViewModel`
   * `~/ViewModels/AddEventViewModel.cs`
2. Add the `EventType` property

```csharp
// All the using statements

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        // ... All the other properties

        public EventType Type { get; set; }
    }
}
```
3. Then add **below** the `EventType` property add the following code:

```csharp
// All the using statements

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        // ... All the other properties

        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
            new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString()),
            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString())
        };

    }
}
```
5. Be sure to import the `SelectListItem` from its proper namespace:

```csharp
using Microsoft.AspNetCore.Mvc.Rendering;
```

### Add the Enum Values Through the Controller
1. Open the `EventsController.cs` file and locate the `POST ADD()` action
2. Then add the new model property `Type` to the new event that is created
```csharp
        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if(ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                   // .. The other value initializations
                    Type = addEventViewModel.Type
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }
```

### Update the Add.cshtml View
1. Open the `Add.cshtml` view
2. Add the following tags to the form
```html
<form asp-controller="Events" asp-action="Add" method="post">

    <!-- All the other tags -->

    <div class="form-group">
        <label asp-for="Type">Event Types</label>
        <select asp-for="Type" asp-items="Model.EventTypes"></select>
    </div>

    <input type="submit" value="Add Event" />
</form>
```

### Update the Index.cshtml View
1. Open the `Index.cshtml` view
2. Add the following code
```html
<table class="table">
  <thead>
      <tr>
          <!-- All the other headers -->
          <th scope="col">Event Type</th>
      </tr>
  </thead>
  <tbody>
      @foreach (Event evt in Model)
      {
          <tr>
              <!-- All the other row items -->
              <td scope="row">@evt.Type</td>
          </tr>
      }
  </tbody>
</table>
```