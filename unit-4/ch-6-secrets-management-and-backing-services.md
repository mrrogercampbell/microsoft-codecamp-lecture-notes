# Chapter 6: Secrets Management & Backing Services

## Walkthrough: Local & Remote Secrets Management
### Explore Concepts
### Get the Source Code
### Local: How it Works
### Remote: How it Works
### Bringing it Together
### Create Resource Group
### Provision a VM
### Create Key Vault
### Update Code to Access Key Vault
### Grant VM Access to Key Vault
### Add Secret to Key Vault
### Install Dependencies to VM
### Deliver the Code
### Publish
### Deploy
### VM Security Groups
### Test Your Deployment


## Studio: Deploy CodingEventsAPI with KeyVault
### Create Resource Group
   * Name it: `<Your Name>-rg-coding-events-secrets`
### Create VM
1. Select the Resource Group you created in the [Create Resource Group](#create-resource-group) section
2. Name it: `<Your Name>-vm-coding-events-secrets`
   * For `Authentication type` select `Password`
   * Username: `student`
   * Password `LaunchCode-@zure1`
3. Set the Management Tab
   * Under the `Identity` section click the checkbox for `System assigned managed identity`
### Create Key Vault
1. Select the Resource Group you created in the [Create Resource Group](#create-resource-group) section
2. Name it: `<Your Name>-kv-ce-secrets`
3. Then click `Create`
4. Once it finishes deploying click `Go to resource`

### Grant VM Access to the Key Vault
1. Click `Access Policies`
   * Located on the left-hand side under `Settings`
2. Click `Add Access Policy`
   1. Click the dropdown under `Configure from template (optional)`
      * Select `Secret Management`
   2. Under the `Select principal *`
      * Click `None selected`
   3. Search for your VM's name and select it
   4. Click `Add`
3. Click `Save`
#### Create Secrets
1. Click `Secrets`
   * It is located under the `Settings` section on the left-hand side
2. Click `Generate/Import`
   1. Provide the following:
   2. Name = `ConnectionStrings--Default`
   3. Value = `server=localhost;port=3306;database=coding_events;user=coding_events;password=launchcode`
### Configure local project
1. Locate your `coding-events-api` project on your local machine
   * If you are unable to find it feel free to [fork and clone it](https://github.com/LaunchCodeEducation/coding-events-api)
2. Change to the `2-mysql-solution` branch
```sh
git checkout 2-mysql-solution
```
3. Open the `appsettings.json` file in `Visual Studio`
   1. Add the name of the `Key Vault` you created as the value for `KeyValutName:`
```csharp
// appsettings.json
  "KeyVaultName": "<Your Name>-kv-ce-secrets",
```
4. Stage, Commit, and Push up the project to GitHub
   * Be sure that you forked and cloned or the push won’t work
   * Double check on GitHub and make sure your changes were pushed up correctly

## Configure And Deploy Project
## Final Configuration Sets
1. Go back to the VM in Azure
   1. Click the `Networking`
      * Under `Settings` on the let-hand side
   2. Under the `Inbound port rules` click `Add inbound port rule`
      1. Change the `Destination port ranges *`: `80`
      2. Change the `Name`: `Port_80_IN`
      3. Then press `Add`
   3. Under the `Outbound port rules` click `Add outbound port rule`
      1. Change the `Destination port ranges *`: `80`
      2. Change the `Name`: `Port_80_OUT
      3. Then press `Add`
### SSH Into Your Azure VM Via Local Terminal
1. In Azure open your VM
2. Click the Connect button
3. Select SSH
4. Copy the command in step 4
   * It will look like the following: `ssh -i <private key path> student@52.186.141.156`
5. Open a terminal on your local machine
   1. Paste the command you copied into the terminal
   2. Be for hitting enter remove the `-i <private key path>` from the command and hit enter
      * Your command should look similar to this: `ssh student@52.186.141.156`
> **Note**: _Window users _ be sure to open `PowerShell as an administrator`
6. When prompted type `yes`
7. Provide the password: `LaunchCode-@zure1`
   * You will now be connected to your VM via your local machine's terminal
### Install Dependencies to VM & Deploy Application
1. Create a `script.sh` file
```sh
touch script.sh
```
2. Open the file in `nano`
```sh
nano script.sh
```
3. Copy all the code from this [script.sh](./assets/ch-6/script.sh) file
4. Paste all the code into `Nano`
5. Locate within the script the `git clone <Your GitHub Repo Clone Link Goes Here>` statement and update it so that it will clone down your `GitHub` repo
   * Be sure to use the `https` clone link
6. Exit by typing `Ctr + X`
7. Save by pressing `y`
8. Then press `enter`
9.  Verify that the changes were made by typing: `cat script.sh`
   * This will print the entire file to the terminal
11. Run the script
```sh
bash script.sh
```
   1. After the script runs for a bit you will be presented with a screen titled: `Configuring mysql-apt-config`
      1. On the first window it will ask you `Which MySQL product do you wish to configure`
         *  Select `MySQL Server & Cluster (Currently selected: mysql-8.0)` by clicking the enter key
      2. On the second window it will ask you `Which server version do you wish to receive?` by clicking the enter key
         * Select `mysql-8.0`
      3. On the third screen hit the down arrow key until you are selecting `Ok` and then press the enter key
12.  Then the script will run for awhile more, wait for it to complete
13. On Completion your application will be deployed to your VMs `public IP` address