## 7.4. Walkthrough: Explore OAuth & OIDC
- [7.4. Walkthrough: Explore OAuth & OIDC](#74-walkthrough-explore-oauth--oidc)
  - [Checklist](#checklist)
- [Setup tenant directory and link to an active azure subscription](#setup-tenant-directory-and-link-to-an-active-azure-subscription)
- [Register Coding Events API Application](#register-coding-events-api-application)
- [Setup SUSI Flow](#setup-susi-flow)
- [Test user flow](#test-user-flow)

### Checklist
Setting up our AADB2C service will involve the following steps:
1. create an AADB2C tenant directory
2. link the tenant directory to an active Azure Subscription
3. register our Coding Events API application
4. configure a Sign Up and Sign In (SUSI) flow using an Email provider.
After we have completed these steps we will register an identity using the SUSI flow and inspect the resulting JWT (identity token). We will be using the Microsoft JWT decoder tool to inspect the claims within the identity token.

## Setup tenant directory and link to an active azure subscription
1. Navigate to the [azure portal](https://portal.azure.com/#home), and Click on `create a resource`
2. Search for `Azure Active Directory B2C`A
   * Click create.
3. Click `Create a new Azure AD B2C Tenant`.
4. Enter following information:
  + `Organization name`: `<yourname> ADB2C`
  + `Initial domain name`: `<yourname>0921tenant`
    + 0921 is just the month and year in the format of <MMYY>
5. In Resource group, Click `Create new` to create a new resource group
6. Enter it in the format of `yourname-aadb2c-walkthrough`
7. Click `Review + create`
8. Click `Create`
  + it will take a few minutes to create the tenant and spin everything up.

## Register Coding Events API Application
1. in the search bar, search for `<yourname>0921` and select the B2C tenant that pops up.
2. Click the blue `Open B2C Tenant` link
   * It can be found under `Azure AD B2C Settings` at the bottom of the page
3. On left side, Click `App registrations`.
4. Click on `New registration`
5. fill out form information as follows:
  + `Name`: `Coding Events API`
  + `Redirect URI`: `https://jwt.ms`
    + Keep the dropdown as `Web`
6. Click `Register`
7. On the Coding Events API dashboard that just popped up, Click on `Authentication` on the left
8. Scroll down, under the `Implicit grant and hybrid flows` section, enable/check both `Access tokens` and `ID tokens` checkboxes
9. Click `Save`
10. Click on `Azure AD B2C` breadcrumb link at the top.

## Setup SUSI Flow
You should be back at the Azure AD B2C dashboard, like as follows.
![SUSI Flow Image 1](../assets/ch-7/7-4-set-up-azure-adb2c-tenant-identity-tokens/setup-susi-flow-1.PNG)

1. On the left side, under `Policies`, Click `User flows`.
2. Click on `New user flow`
3. Click on the `Sign up and sign in` flow type.
  + leave version as `Recommended`
4. Click `Create` at the bottom.
5. Enter following information for the form:
  + `Name`: `susi-flow`
  + `Identity Providers`: select `Email signup`
  + `Multifactor authentication`: leave `MFA enforcement` as `Off` and `Type of method` as `email`
6. Under `User attributes and token claims`, Click `Show more...`
7. select the following and hit `Ok` when done:
![SUSI Flow Image 1](../assets/ch-7/7-4-set-up-azure-adb2c-tenant-identity-tokens/setup-susi-flow-7.PNG)
8. Click `Create`

## Test user flow
Now we just need to test the flow.
1. Click on `B2C_1_susi-flow`
2. Click `Run user flow`
3. Click on `Run user flow` with the panel that just popped up on the right side.
4. a new window should open. Click on `Sign up now`
  + NOTE: if you get an internal services error, it might take upwards of 30 minutes for azure to load everything. go get some lunch and come back and try again.
5. submit a new email address and Click `Send verification code`
6. check your email and input the verifcation code in the app
7. fill out a new password as `Launchcode-@zure1` and your `Display Name` as `<yourname>`
8. Click `Create`
9. A new page should load via jwt.ms and you should be able to see the identity token, you should be able to look through  `Decoded Token` and `Claims` tabs