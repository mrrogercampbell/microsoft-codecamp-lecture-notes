# Chapter 15: ViewModels and Model Validation
## Update Event Model
1. Add the `events List` to the `Index()`  action
```csharp
[HttpGet]
public IActionResult Index()
{
    List<Event> events = new List<Event>(EventData.GetAll());

    return View(events);
}
```
   * We due this to prepare the `Action` to utilize the ViewModel
2. Update the `AddNewEvent()`
	1. Change its name to `Add()`
	2. Update its `HttpPost` attribute by removing the custom route
```csharp
// POST: /<controller>/
[HttpPost]
public IActionResult Add(Event newEvent)
{
    EventData.Add(newEvent);

    return Redirect("/Events");
}
```

## Update the Event Index View
1. Add a `using` statement to the top of the file
   * This allows us to utilize the newly created `ViewModel`
2. Import the the Model that we will be using with `@model List<Event>`
   * Be sure to explain that we are importing the model as shorthand to just show that it is possible to import things into our RazorView
   * The next step will be to import the actual `ViewModel` we will create

```csharp
@using CodingEvents.Models
@model List<Event>

```

3. Update the `if`  and  `foreach` statements utilize the `Model` instead of `ViewBag.events`
```csharp
@if (Model.Count == 0)
{
    //....... all the code
}
else
{
    //.... Some code

   <tbody>
    @foreach (Event evt in Model)
    {
        //... Code
    }
}

```
## Adding a ViewModel Class
1. Create a `ViewModels` directory  in the root of the project
2. Add a new class called `AddEventViewModel`
3. Inside the class create two properties: `Name` and `Description`

```csharp
using System;
namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
```

### Update the Event Controller’s Add Action (GET)
4. Now Go back and create a new instance of the `AddEventViewModel` class inside the `Add()` action
5. Then return the new instance of the `AddEventViewModel` class via the `View()`

```csharp
[HttpGet]
public IActionResult Add()
{
    AddEventViewModel addEventViewModel = new AddEventViewModel();

    return View(addEventViewModel);
}
```

## Update the Views/Event/Add.cshtml
1. Import the `Event ViewModel` into the `Index.cshtml` file utilizing the `@using CodingEvents.ViewModels`  syntax
2. Next add the `@model AddEventViewModel` syntax to make the `AddEventViewModels`  accessible to the file

```csharp
@using CodingEvents.ViewModels
@model AddEventViewModel
```

3. Update the `form` to utilize the `asp-controller` and  `asp-action` attributes
```html
<form asp-controller="Events" asp-action="Add" method="post">
```
5. Next Update the `form labels and inputs` to utilize the `asp-for` attributes
   * Be sure to use the `capitalize` version of each `name ` attribute
     * ie: They should match the `property names` in the `AddEventViewModel` class 
   * You can also remove the `type` attribute from the `input` tag
     * `ASP.NET` is smart enough to infer the data types for you based on the `ViewModel` 
   * You also can remove the text inside the `label` tags
     * `ASP.NET` will automatically add the `name` attribute’s value in it place
```html
<form asp-controller="Events" asp-action="Add" method="post">
    <div class="form-group">
        <label asp-for="Name"></label>
        <input asp-for="Name" type="text" />
    </div>

    <div class="form-group">
        <label asp-for="Description"></label>
        <input asp-for="Description" />
    </div>

    <input type="submit" value="Add Event" />
</form>
```


## Update the Event Controller’s Add Action (POST) 
1. Update the action’s `parameter list` to accept an `AddEventViewModel` as it only argument
2. Then create a new instance of an `Event` class (ie: the actually model) 
   * Then  initialize it with the expected `form data`
3. Finally utilize the `EventData.Add()` to add the newly created object to the mock DB

```csharp
[HttpPost]
public IActionResult Add(AddEventViewModel addEventViewModel)
{
    Event newEvent = new Event
    {
        Name = addEventViewModel.Name,
        Description = addEventViewModel.Description,
    };

    EventData.Add(newEvent);

    return Redirect("/Events");
}
```


## Add Validation Attributes to the AddEventViewModel
1. `Validation Attributes` allow you to define requirements for your expected data via the `ViewModel`
2. Import the
3. Update the `AddEventViewModel` with the following code:
   * Add the `[Required]` validation attribute above the `Name` and `Description` properties
   * Add the `[StringLength]` validation attribute to the `Name` and `Description` properties
3. Create a new property called `ContactEmail`
   * Also place above it the `[EmailAddress]` validation attribute 

```csharp
[Required(ErrorMessage ="Name is Required")]
[StringLength(50, MinimumLength = 3, ErrorMessage = "Name must ne between 3 and 50 characters")]
public string Name { get; set; }

[Required(ErrorMessage = "Please enter a description for your event.")]
[StringLength(500, ErrorMessage = "Description is too long")]
public string Description { get; set; }

[EmailAddress]
public string ContactEmail { get; set; }
```


## Update the Event Model with the New ContactEmail Property
1. Update the `Event Model` so that it expects the `ContactEmail` Property that was added to the `AddEventViewModel`
   * Be sure to update the `overloaded constructor` to set its value

```csharp
public class Event
{
   private static int _nextId = 1;

   public int Id { get; }
   public string Name { get; set; }
   public string Description { get; set; }
   public string ContactEmail { get; set; }

   public Event()
   {
       this.Id = _nextId;

       _nextId++;
   }

   public Event(string name, string description, string contactEmail)
       : this()
   {
       this.Name = name;
       this.Description = description;
       this.ContactEmail = contactEmail;
   }
    //..... More code
}
```


## Update the Add.cshtml Form
1. Update the `form` so that it has a `label` and corresponding `input` tag that accepts the users `ContactEmail`
   * Be sure to give it `asp-for` attributes
   * (Optional): You can also add a better naming convention for the `innerHTML` of the `ContactEmail`  `label tag`
     * If you do not do this then `ASP.NET` will default and place `ContactEmail` as the `label’s InnerHTML`
```html
<form asp-controller="Events" asp-action="Add" method="post">
    <div class="form-group">
        <label asp-for="Name"></label>
        <input asp-for="Name" type="text" />
    </div>

    <div class="form-group">
        <label asp-for="Description"></label>
        <input asp-for="Description" />
    </div>
    <div class="form-group">
        <label asp-for="ContactEmail">Email</label>
        <input asp-for="ContactEmail" />
    </div>

    <input type="submit" value="Add Event" />
</form>
```
* **Gotcha:
  * ** In the Chapter Video the demonstrator adds the `asp-action` and `asp-controller` to the `div` tag and not the `form` tag as I have done above.
  * The way it was don in the video is incorrect.
  * The way the code is written above is correct
    * ASP.NET even though the syntax was incorrect with how the demonstrator did it in the video ASP.NET was able to interpret the code and correct the error.
  * Long and short be sure your code is structured how I have it above.


## Update the Event Controller’s Add Action (POST)
1. Be sure to update the action so that the `newEvent` being created also sets the `ContactEmail` property’s value
```csharp
[HttpPost]
public IActionResult Add(AddEventViewModel addEventViewModel)
{
    Event newEvent = new Event
    {
       // .... the other two props
        ContactEmail = addEventViewModel.ContactEmail
    };
}
```

## Update the Event Index.cshtml View
1. Add `th tag` that displays the Header:  `Contact Email`
2. Add `td tag` that displays the user `Contact Email`

```csharp 
else
{
    <table class="table">
        <thead>
            <tr>
                //... The other headers
                <th scope="col">Event Owners Email</th>
            </tr>
        </thead>
        <tbody>
            @foreach (Event evt in Model)
            {
                <tr>
                    //... The other rows
                    <td scope="row">@evt.ContactEmail</td>
                </tr>
            }
        </tbody>
    </table>
}
```

## Add Validation to the Event Add (POST) Action
1. You need to add a `if statement` that checks to see if the `ModelState.IsValid`
   * `ModelState`:  gets the state of the ModelView that is passed in as an argument; ie: `addEventViewModel`
   * `.IsValid`: returns wether any of the `validation attributes` listed in the `ViewModel` class has been triggered
     * If so this returns false
     * else it return true
   * This if statement allows us to check and see if the form’s validation (which is dictated in the `ViewModel`) are trigger then we do not add the data and return the invalid form back to the user
     * And in turn are able to provide the `error message` defined in the `ViewModel`
   * If none of the validations are triggered then we are able to create a new instance of the `Event class` and store it in our mock db
```csharp
[HttpPost]
public IActionResult Add(AddEventViewModel addEventViewModel)
{
    if(ModelState.IsValid)
    {
        Event newEvent = new Event
        {
            Name = addEventViewModel.Name,
            Description = addEventViewModel.Description,
            ContactEmail = addEventViewModel.ContactEmail
        };

        EventData.Add(newEvent);

        return Redirect("/Events");
    }

    return View(addEventViewModel);
}
```

## Update the Event/Index.cshtml View to Render the Error Message
1. Next we have to add another set of `tags` and corresponding `attributes`  to our `form`
2. For each set of `label` and `input` tags we must add a `span` tag that contains a `asp-validation-for` attribute
   * We could use any tag we would like, meaning it does not have to be a `span` tag
3. The `asp-validation-for` tell `ASP.NET` that if it sees a `EventModel` passed into the view that was flagged as `invalid` to in turn render its `Validation Error Messages`

```csharp
<form asp-controller="Events" asp-action="Add" method="post">
    <div class="form-group">
        //... Label and Input tag
        <span asp-validation-for="Name"></span>
    </div>

    <div class="form-group">
        //... Label and Input tag
        <span asp-validation-for="Description"></span>
    </div>
    <div class="form-group">
        //... Label and Input tag
        <span asp-validation-for="ContactEmail"></span>
    </div>

    <input type="submit" value="Add Event" />
</form>
```

## Add Custom CSS to Change the Color of Span Tags
1. Submit a `Form` so that it triggers the `asp-validation-for` `span tags`
2. Open the inspector and show the students that by default `ASP.NET` give assigns a `className`  of `field-validation-error` to any tag with that is rendered with a  `asp-validation-for`
3. Update the `site.css` file so that it selects the `span tags` by their `className` `asp-validation-error` and changes the text `color` to `red`

``` css
.field-validation-error{
	color: red;
}
```

