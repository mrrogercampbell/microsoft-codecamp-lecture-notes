# Chapter 7: Introduction to Authentication & Authorization with Azure AD B2C

## 7.2. Walkthrough: Explore OAuth & OIDC
### Clone Down The Visual OAuth App
1. Navigate to the [Visual OAuth](https://github.com/LaunchCodeEducation/visual-oauth) repo
2. Clone down a copy of the Repo
```sh
# clone into current directory
$ git clone https://github.com/LaunchCodeEducation/visual-oauth
```
### Register Your Own GitHub OAuth App
1. Click your github profile (top right corner) and go to `settings`
2. Scroll down to `Developer settings` in the _sidebar_
3. Select `OAuth Apps`
4. Select `New OAuth App`
5. Provide the following details:
   1. `Application name`: `YOUR_NAME Visual OAuth`
   2. `Homepage URL`: `http://localhost:3000/`
   3. `Authorization callback URL`: `http://localhost:3000/`
6. Click `Register application`

> Leave this tab open to copy over the Client ID and Secret you will be prompted to provide these via the CLI in the next section

### Setup Visual OAuth
* Go back to your `terminal` and navigate into the `visual-oauth` application your cloned down in the [Clone Down The Visual OAuth App](#clone-down-the-visual-oauth-app) section
```sh
cd visual-oauth/
# Your path may be different depending on where you are located within your terminal
```
#### Linux and MacOs
```sh
# Run this from the root directory of the repo
$ npm run setup

# You will be prompted for [GitHub Client ID] and [GitHub Client Secret] from when you registered your GitHub oauth app
```
#### Windows
* Run this command in `PowerShell`
```sh
# Run this from the root directory of the repo
> npm run setup:windows

# You will be prompted for [GitHub Client ID] and [GitHub Client Secret] from when you registered your GitHub oauth app
```
### Run Visual OAuth
* The client startup script will automatically open your default browser to `http://localhost:3000` after it is done loading.

> NOTE: it may take up to 30 seconds for the client application to start up

If your browser doesn't open automatically click this link http://localhost:3000/

> you can stop the app using `ctrl+C` in the terminal
#### Linux and MacOs
* When running Linux and or MacOs you only need to run one command which will launch both applications:
```sh
# Run this from the root directory of the repo
$ npm run start
```
#### Windows
* In Windows you will _need to start both the API and Client separately in two different PowerShell terminals_:
1. In your first PowerShell terminal:
```sh
# Run this from the root directory of the repo
> npm run start:api
```
2. In your second PowerShell terminal:

```sh
# Run this from the root directory of the repo
> npm run start:client
```
### WARNING: Windows Browsers
* This _example will not work in_**Microsoft Edge**, or **Microsoft Internet Explorer**.
* If **Edge**, or **IE** are your default browser you will need to open a browser like Firefox and manually navigate to http://localhost:3000

## OAuth Grant Types
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
