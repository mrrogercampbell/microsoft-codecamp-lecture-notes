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
7. Click on `Generate a new client secret`
> NOTE: **DO NOT** lose this client secret, this is the ONLY time you will be able to copy the information. 
8. Leave this tab open to copy over the Client ID and Secret. You will be prompted to provide these via the CLI in the next section

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

# You will be prompted for [GitHub Client ID] and [GitHub Client Secret] from when you registered your GitHub oauth app. Make sure you enter both EXACTLY as they appeared when we registered the application.
```
### Run Visual OAuth
* It will take several minutes for the application to build. Once done, you now need to start up the application.

> NOTE: it may take up to 30 seconds for the client application to start up

If your browser doesn't open automatically with the commands below, click this link http://localhost:3000/

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


## Step through OAuth Application
1. After the application has loaded at http://localhost:3000, input your GitHub User Name and click `Request Public User Data`. 
2. You should see your public user data as follows: {insert screenshot}
3. Go through Step 1 and click `View Instructions`. Read through the instructions. Click `Authenticate and Authorize with Provider`
4. You should see an authorization page pop up. Click `Authorize`.
5. Read through Step 2 by clicking on `View Instructions` and click `Check for Authorization Code`. You should receive an authorization code that you can hover over to see.
6. Read through step 2.5 by clicking on `View Instructions` and click on `Send Authorization Code to Back-end`. 
7. Read through step 3 by clicking on `View Instructions` and click on `Exchange Authorization Codefor Access Token`. 
8. Complete the last step, `After OAuth Flow: Client Uses the Access Token`


## 7.4. Walkthrough: Explore OAuth & OIDC
### Checklist
Setting up our AADB2C service will involve the following steps:
1. create an AADB2C tenant directory
2. link the tenant directory to an active Azure Subscription
3. register our Coding Events API application
4. configure a Sign Up and Sign In (SUSI) flow using an Email provider.
After we have completed these steps we will register an identity using the SUSI flow and inspect the resulting JWT (identity token). We will be using the Microsoft JWT decoder tool to inspect the claims within the identity token.

## Setup tenant directory and link to an active azure subscription
1. Navigate to the [azure portal](https://portal.azure.com/#home), and click on `create a resource`
2. search for `Azure Active Directory B2C`A. click create.
3. Click `Create a new Azure AD B2C Tenant`.
4. Enter following information:
  + `Organization name`: `<yourname> ADB2C`
  + `Initial domain name`: `<yourname>0921tenant`
    + 0921 is just the month and year in the format of <MMYY>
5. In Resource group, click `Create new` to create a new resource group
6. Enter it in the format of `yourname-aadb2c-walkthrough`
7. Click `Review + create`
8. Click `Create`
  + it will take a few minutes to create the tenant and spin everything up.

## Register Coding Events API Application
1. in the search bar, search for `<yourname>0921` and select the B2C tenant that pops up.
2. Click `Azure AD B2C Settings` at the bottom
3. On left side, click `App registrations`.
4. Click on `New registration`
5. fill out form information as follows:
  + `Name`: `Coding Events API`
  + `Redirect URI`: `https://jwt.ms`
    + Keep the dropdown as `Web`
6. Click `Register`
7. On the Coding Events API dashboard that just popped up, click on `Authentication` on the left
8. Scroll down, under the `Implicit grant and hybrid flows` section, enable/check both `Access tokens` and `ID tokens` checkboxes
9. Click `Save`
10. click on `Azure AD B2C` breadcrumb link at the top.

## Setup SUSI Flow
You should be back at the Azure AD B2C dashboard, like as follows. {insert setup-susi-flow-1 screenshot}
1. On the left side, under `Policies`, click `User flows`.
2. Click on `New user flow`
3. Click on the `Sign up and sign in` flow type.
  + leave version as `Recommended`
4. click `Create` at the bottom.
5. Enter following information for the form:
  + `Name`: `susi-flow`
  + `Identity Providers`: select `Email signup`
  + `Multifactor authentication`: leave `MFA enforcement` as `Off` and `Type of method` as `email`
6. Under `User attributes and token claims`, click `Show more...`
7. select the following and hit `Ok` when done:
  {insert screenshot susi-flow-7}
8. click `Create`

## Test user flow
Now we just need to test the flow. 
1. click on `B2C_1_susi-flow`
2. click `Run user flow`
3. click on `Run user flow` with the panel that just popped up on the right side. 
4. a new window should open. Click on `Sign up now`
  + NOTE: if you get an internal services error, it might take upwards of 30 minutes for azure to load everything. go get some lunch and come back and try again.
5. submit a new email address and click `Send verification code`
6. check your email and input the verifcation code in the app
7. fill out a new password as `Launchcode-@zure1` and your `Display Name` as `<yourname>`
8. Click `Create`
9. A new page should load via jwt.ms and you should be able to see the identity token, you should be able to look through  `Decoded Token` and `Claims` tabs

  
