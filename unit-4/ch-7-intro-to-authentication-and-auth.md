# Chapter 7: Introduction to Authentication & Authorization with Azure AD B2C


## Walkthrough: Set Up Azure ADB2C Tenant & Identity Tokens
### Checklist
### Set Up AADB2C Tenant Directory
### Create Tenant Directory
### Link tenant directory to your Subscription
* this section is not needed
* When you create the tenant the subscription is linked
### Register & Configure an AADB2C Application
### Register the Coding Events API application
* Search for your tenant: example: `roger0821`
![alt](https://link)
**Note**
Be sure to take new screenshots some of the UI has changed
### Configure the Coding Events API application registration
### Set Up the SUSI Flow
### Create a SUSI flow
* Be sure to tell students that they must click `show more` to see the claims
  * Provide a screenshot of how the completed form looks
![alt](https://link)
### Test the User Flow
### Run the SUSI flow
### Register a user account
### Inspect the identity token

## Walkthrough: Set Up Access Token Authorization with Azure ADB2C
### Checklist
### The Final Coding Events API Version
### Set Up Postman
### Import the Coding Events API Collection
### Configure the Access Token Request Form
### Protect the Coding Events API
### Expose a user_impersonation Scope for the API
### Register & Configure the Postman Client Application
### Register the Postman Client Application
### Configure Authentication
### Grant Admin Permissions for Using the Scope
### Test the User Flow for Access Tokens
### Get the Authorization URL
### Explore the Access Token
### Get the Postman Access Token
### Replacing an Expired Access Token



* Here we are creating a connection string for the api to connect to the local instance of our database
```csharp
// Startup.cs
var connectionString = "SERVER=" + Configuration["server"] + ";" + "DATABASE=" + Configuration["database"] + ";"
+ "UID=" + Configuration["uid"] + ";" + "PASSWORD=" + Configuration["password"];
```
* To create env variable
```sh
dotnet user-secrets set server localhost
dotnet user-secrets set database <Name_of_DB>
dotnet user-secrets set uid <User_of_the_db> # The username that they create when they made the db
dotnet user-secrets set password <User_Password> # Password for the user referenced above



dotnet set name server localhost
server = localhost
```
