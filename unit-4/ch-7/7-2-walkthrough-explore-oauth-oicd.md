## 7.2. Walkthrough: Explore OAuth & OIDC
- [7.2. Walkthrough: Explore OAuth & OIDC](#72-walkthrough-explore-oauth--oidc)
  - [Clone Down The Visual OAuth App](#clone-down-the-visual-oauth-app)
  - [Register Your Own GitHub OAuth App](#register-your-own-github-oauth-app)
  - [Setup Visual OAuth](#setup-visual-oauth)
    - [Linux and MacOs](#linux-and-macos)
    - [Windows](#windows)
  - [Run Visual OAuth](#run-visual-oauth)
    - [Linux and MacOs](#linux-and-macos-1)
    - [Windows](#windows-1)
  - [WARNING: Windows Browsers](#warning-windows-browsers)
- [Step through OAuth Application](#step-through-oauth-application)
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

If your browser doesn't open automatically with the commands below, Click this link http://localhost:3000/

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
1. After the application has loaded at http://localhost:3000, input your GitHub User Name and Click `Request Public User Data`. 
2. You should see your public user data as follows: {insert screenshot}
3. Go through Step 1 and Click `View Instructions`. Read through the instructions. Click `Authenticate and Authorize with Provider`
4. You should see an authorization page pop up. Click `Authorize`.
5. Read through Step 2 by Clicking on `View Instructions` and Click `Check for Authorization Code`. You should receive an authorization code that you can hover over to see.
6. Read through step 2.5 by Clicking on `View Instructions` and Click on `Send Authorization Code to Back-end`. 
7. Read through step 3 by Clicking on `View Instructions` and Click on `Exchange Authorization Codefor Access Token`. 
8. Complete the last step, `After OAuth Flow: Client Uses the Access Token`