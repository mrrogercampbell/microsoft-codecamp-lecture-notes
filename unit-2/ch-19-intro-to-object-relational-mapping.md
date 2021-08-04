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
5. Search for and install the `Pomelo.EntityFrameworkCore.MySql` package

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
