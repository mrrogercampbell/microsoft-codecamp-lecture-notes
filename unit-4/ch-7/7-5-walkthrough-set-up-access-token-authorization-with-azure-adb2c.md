## 7.5. Walkthrough: Set Up Access Token Authorization with Azure ADB2C
### Checklist
### Set Up Postman
#### Import the Coding Events API Collection
1. Open a `bash` terminal and cd in the `Coding Events API` project
2. Switch to the `3-aadb2c` branch:
   * `git checkout 3-aadb2c`
3. Open `Postman`
4. Select the orange `Import` button
5. Click the `Upload Files` button
6. Navigate to the `Coding Events API` project
7. Select and double Click the `Postman_AADB2C-CodingEventsAPI-Collection.json`
8. Press the orange `Import` button
9. Once it finishes uploading:
   1. Hover your mouse over the collection name
   2. Click the three dots
   3. Select `Edit`
10. Click the `Authorization` tab
#### Configure the Access Token Request Form
**NOTE:**:
    * Once inside the authorization tab scroll down to the `Configure New Token` section.
    * In here you will be able to edit the fields listed.
1. Update the `Token Name`: `access token`
### Protect the Coding Events API
#### Expose a user_impersonation Scope for the API
1. In Azure search for the tenant you created
2. Then open up the `Open B2C Tenant`like below {insert tenant screenshot here}
3. Click on `App registrations` {insert screenshot here}.
4. Then select your app {insert screenshot here}.
5. Click `Expose an API` on the left-hand side.
7. Press `Add scope and` then Click `Save and continue`.
8. Then fill out the form and put in the following values:
   * `Scope name`: `user_impersonation`
   * `Admin consent display`: `User impersonation access to API`
   * `Admin consent description`: `Allows the Client application to access the API on behalf of the authenticated user`
9. Click `Add scope`
10. Click the blue copy button to copy the URL
11. Go back to postman, replace the `Scope` field with your copied value.
### Register & Configure the Postman Client Application
#### Register the Postman Client Application
1. Click on `Azure AD B2C` breadcrumb
2. Click `App registrations`
3. Click on  `New registration`
4. Fill out the form with the following information:
   * Name: Postman
   * Redirect URI: https://jwt.ms
5. Click `Register` after that
6. Copy the `Application (client) id` to the clipboard
7. In postman paste that into the `Client ID` field
### Configure authentication
#### Configure the Redirect URI
1. In Postman Uncheck the `Authorize using browser` checkbox
   * Replace the `Callback URL` with:
   * `https://www.postman.com/oauth2/callback`
#### Configure Implicit Flow
1. In Azure Click on `Authentication` under the `Manage` section
2. Click/enable `Access tokens` and `ID tokens`
3. Click `save`
4. Click on `Add URI` under the `Redirect URI's` section and add the following:
    * `https://www.postman.com/oauth2/callback`
5. Click `Save` again
6. In postman, just double check that `Grant Type` is selected as `Implicit`
#### Grant Admin Permissions for Using the Scope
1. In Azure, Click on `API permissions` on the left hand sidebar
2. Click on `Add a permission`
3. Click on `My APIs` tab on the right {insert screenshot here}.
4. Click on `Coding Events API`
5. Enable the `user_impersonation` scope
6. Click on the check mark `Grant admin consent for <Name> ADB2C`
   1. It's located next to the `Add permissions` button
7. Select `Yes` for the confirmation popup
### Test the User Flow for Access Tokens
1. Click the `Azure AD B2C` breadcrumb
2. Click `User flows`
   * Located under the `Policies` section on the left side,
3. Select the SUSI flow we configured in the previous walkthrough
#### Get the Authorization URL
1. Click `Run user flow`, this will open up a sidebar
2. Make sure the `Application` dropdown has `Postman` selected
3. Click the `metadata document` link
   * This is the blue link directly under the `Run user flow` title at the top
   * A new page should open
4. Copy the `authorization_endpoint` url
   * Copy *just* the url, not the quotations
5. Switch back to postman
6. Replace `Auth URL` with the `authorization_endpoint` you just copied
#### Explore the Access Token
1. Back in Azure click on `Reply URL` and select `https://jwt.ms`
   * You should still be on the `Run user flow` page
2. Click on the `Access Tokens` section
3. Select the `Resource` as `Coding Events API`
4. Click on `Scopes`, only `user_impersonation` should be selected
   * make sure the others are deselected and matches this image: {insert screenshot here}
5. Click `Run user flow`
   * A separate window should open
   * Login with whatever username you created
     * Suggested Password was: `Launchcode-@zure1`
   * If that username or pw doesn't work, Click on `signup`
   * jwt.ms should load and you should see your access token
     * For more info, see section [7.5.6.2 Explore The Access Token](https://education.launchcode.org/azure/chapters/intro-oauth-with-aadb2c/walkthrough_aadb2c-access.html#explore-the-access-token)
### Get the Postman Access Token
1. Switch back to postman
2. Put in any random character string into `State`
3. Click on `Get New Access Token`
   * A new window will popup
   * Sign in with your username and pw you created
     * Suggested Password was: `Launchcode-@zure1`
   * Once signed in you should see a popup that says `Authentication Complete`
4. In the `Manage Access Tokens` window that pops up, Click on `Use Token`
   * You should back at the authorization window, and should see your access token
5. Save all your setting by pressing `ctr + s` (Windows) or `cmd + s` Mac
#### If You Want To Test With Postman
As of right now, if you were to:
1. Open the `Collections` tab
2. Select the `Public Access` directory
3. You will see a request called `Retrieve all Coding Events`
4. Open the `Retrieve all Coding Events` request
5. Inside you will see that it uses a variable called `{{baseUrl}}`
  * We need to configure this
  * Before we configure this we need to start up our VM again
  * Follow the next few section below
##### Start Up Your VM And Deploy Application
1. Go to Azure
2. Navigate to your VM
3. Start your VM
4. Copy the `public ip address`
5. Go to your terminal and provide the following command:
   * `ssh student@<Your VMs Public IP Address>`
   * Login with the correct password: `LaunchCode-@zure1`
6. Run the `deploy_project_script.sh` file to deploy your project

##### Request API Data Via Postman
1. Navigate back to Postman
2. Click the three does to the left of `Coding events API` on the left sidebar
3. Select `Edit`
4. Select the `Variables` tab
5. Update the `baseUrl` values (INITIAL and CURRENT) with your VMs public IP address
6. Click back on the `Retrieve all Coding Events` request and Click the `Send` button
   * It should return an empty array: `[]`
     * This is due to the fact that we have not added any data to the database

#### Replacing an Expired Access Token
If you need a new access token after 1 hour. Do the following steps
1. open the collection settings (three dots next to the collection name)
2. switch to the Authorization tab and select Get New Access Token
3. select Request Token to re-authorize and receive a new one
4. select Use Token (and discard any expired ones)
5. select Update to save the changes to the collection