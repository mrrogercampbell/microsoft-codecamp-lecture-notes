# Chapter 5: Introduction to Azure and Virtual Machines
## Objectives
* In this chapter we will be cover a few topics:
1. Something
2. Something else

* These three topics will give us a surface level understanding of these concepts so that you as engineer can:
  * Understand Something
  * Be able to explain some topic/concept

## Section Title
### Subsections Title
### Sub-Subsections Title

## Walkthrough: Linux Starter App Deployment
Give a brief description of what students should accomplish in this walkthrough

### Login To Azure Portal
1. Navigate to [Azure Portal](https://portal.azure.com/)
2. Use your _Outlook credentials_ to login
   * If you do not remember your _Outlook credentials_ please reach out to me our your TA
3. Once successfully logged in you should see the following dashboard:
![Azure Dashboard](./assets/ch-5/1-login-azure/login-azure-1.png)
### Create a Resource Group
1. Search for `resource group` in the search bar
   * You should see `Resource groups` pop up
![Create a Resource Group Image 1](./assets/ch-5/2-create-resource-group/create-resource-group-1.png)
2. Add a resource group by clicking `Create`
![Create a Resource Group Image 2](./assets/ch-5/2-create-resource-group/create-resource-group-2.png)
3. Fill out the Resource group name in the format of `your-name-lc-rg-web-api` and then click `Review + Create`
![Create a Resource Group Image 3](./assets/ch-5/2-create-resource-group/create-resource-group-3.png)
4. Review your `Resource Group` details and if everything looks good click `Create`
![Create a Resource Group Image 4](./assets/ch-5/2-create-resource-group/create-resource-group-4.png)
5. You will then be directed back to the _resource group home page_
   * You should be able to verify that your new `resource` has been created
  * Do note that it will take several minutes to create the new resource group
![Create a Resource Group Image 5](./assets/ch-5/2-create-resource-group/create-resource-group-5.png)

### Provision the VM
For provisioning the VM we're going to create i.e: `spin up` a new Virtual Machine
1. Search for `Virtual Machines` and click on it
![Provision the VM Image 1](./assets/ch-5/3-provision-vm/provision-vm-1.png)
2. Click on create in the top left corner
![Provision the VM Image 2](./assets/ch-5/3-provision-vm/provision-vm-2.png)
3. Select `Virtual Machine` in the dropdown window
![Provision the VM Image 3](./assets/ch-5/3-provision-vm/provision-vm-3.png)
4. Fill out the form with the following Information
  * `Resource Group`: your-name-lc-rg-web-api
  * `Virtual machine name`: your-name-lc-vm-web-api
  * `Region`: East US
  * `Image`: Ubuntu Server 18.04 LTS
  * `Size`: Standard_B2s - 2 vcpus, 4 GiB memory
![Provision the VM Image 4](./assets/ch-5/3-provision-vm/provision-vm-4.png)
  * `Authentication type`: Password
  * `Username`: student
  * `Password`: LaunchCode-@zure1
  * `Public inbound ports`: Allow selected ports
  * `Select inbound ports`: SSH(22)
5. Click `Review + create`
![Provision the VM Image 5](./assets/ch-5/3-provision-vm/provision-vm-5.png)
6. Review your `VM` then click `Create`
![Provision the VM Image 6](./assets/ch-5/3-provision-vm/provision-vm-6.png)
7. It will take a few minutes to spin up the azure server once complete you will see this window
![Provision the VM Image 7](./assets/ch-5/3-provision-vm/provision-vm-7.png)


### Configure the VM
Now we're going to configure our VM that is live. To do this:
1. Navigate back to the `Virtual Machines` tab
![Configure the VM Image 1](./assets/ch-5/4-configure-vm/configure-vm-1.png)
2. Click on the name of your VM
![Configure the VM Image 2](./assets/ch-5/4-configure-vm/configure-vm-2.png)
3. On the left side, navigate to the `Run command`
![Configure the VM Image 3](./assets/ch-5/4-configure-vm/configure-vm-3.png)
4. Click `RunShellScript`
![Configure the VM Image 4](./assets/ch-5/4-configure-vm/configure-vm-4.png)
5. Copy and paste the following commands into the `Linux Shell Script` area:
``` sh
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1
```
![Configure the VM Image 5](./assets/ch-5/4-configure-vm/configure-vm-5.png)
6. Click on `Run`
  * you should see some output in the bottom on the screen in the black box after a minute or two (it takes a little bit of time to run).
![Configure the VM Image 6](./assets/ch-5/4-configure-vm/configure-vm-6.png)
7. Scroll up a bit in the terminal output so that you see _Please visit_
![Configure the VM Image 7](./assets/ch-5/4-configure-vm/configure-vm-7.png)


### Create the Project
Since we have our server all setup and ready to go, our next step is to just create a new dotnet project in our Azure VM.
1. Copy and paste the following commands into the `Linux Shell Script` area:
  * Again, this might also take a minute to run and return output to you in the black area below the `Run` button
``` sh
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student
dotnet new mvc -n hello-world
```
![Create the Project Image 1](./assets/ch-5/5-create-project/create-project-1.png)
2. Remove all prior existing code
3. Copy and paste the following commands into the `Linux Shell Script` area:
``` sh
cd /home/student/hello-world
pwd
ls
```
![Create the Project Image 2](./assets/ch-5/5-create-project/create-project-2.png)

### Publish the Project
Now, we're going to publish the project on the server, to do this:
1. Remove all prior existing code
2. Copy and paste the following code into the `Linux Shell Script` are
``` sh
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/hello-world
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true
```
![Publish the Project Image 1](./assets/ch-5/6-publish-project/publish-project-1.png)
1. Next, we will verify that the project was built by running the following command:
``` sh
ls /home/student/hello-world/bin/Release/netcoreapp3.1/linux-x64/publish/
```
![Publish the Project Image 2](./assets/ch-5/6-publish-project/publish-project-2.png)

### Open Network Security Groups
Holy crap, you did it. azure is up and running, you've built your project. But now we need to setup some security group rules. We're doing this because we need to allow traffic to the VM. We're going to do this by opening port 80 on our VM. To do this:
1. Search for the `Networking` tab
![Open Network Security Groups Image 1](./assets/ch-5/7-network-security-groups/network-security-groups-1.png)
2. Click on `Add inbound port rule`
![Open Network Security Groups Image 2](./assets/ch-5/7-network-security-groups/network-security-groups-2.png)
1. Fill out the form with the following information:
  * `Source`: Any
  * `Source port ranges`: *
  * `Destination`: Any
  * `Service`: Custom
  * `Destination port ranges`: 80
  * `Protocol`: Any
  * `Action`: Allow
  * `Priority`: 310
  * `Name`: web-app-inbound
  * `Description`: (you can leave this blank)
5. Click `Add`
![Open Network Security Groups Image 3](./assets/ch-5/7-network-security-groups/network-security-groups-3.png)
6. Next, we need to create an `outbound rule`
7. Click on the `Outbound port rule`
![Open Network Security Groups Image 4](./assets/ch-5/7-network-security-groups/network-security-groups-4.png)
8. Then click the `Add outbound port rule`
![Open Network Security Groups Image 5](./assets/ch-5/7-network-security-groups/network-security-groups-5.png)
9.  Fill out the form with the following information:
  * `Source`: Any
  * `Source port ranges`: *
  * `Destination`: Any
  * `Service`: Custom
  * `Destination port ranges`: 80
  * `Protocol`: Any
  * `Action`: Allow
  * `Priority`: 100
  * `Name`: web-app-outbound
  * `Description`: (you can leave this blank)
![Open Network Security Groups Image 6](./assets/ch-5/7-network-security-groups/network-security-groups-6.png)
10. Click `Add`
### Deploy The Project
1. Navigate back to `Operations` and click on `Run command`
![Deploy The Site Image 1](./assets/ch-5/8-deploy-project-pt-1/deploy-project-1.png)
2. Click on `RunShellScript` and Run these commands:
``` sh
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/hello-world
ASPNETCORE_URLS="http://*:80" ./bin/Release/netcoreapp3.1/linux-x64/publish/hello-world
```
  * You should _not_ see any output here.
![Deploy The Site Image 2](./assets/ch-5/8-deploy-project-pt-2/deploy-project-1.png)
### Connect To App
Now is the final step, seeing what we just deployed :)
1. Click on `Overview`
![Connect To App Image 1](./assets/ch-5/9-connect-to-app/connect-to-app-1.png)
1. You should see your `Public IP address`
![Connect To App Image 2](./assets/ch-5/9-connect-to-app/connect-to-app-2.png)
3. Open a new tab and type in:`{public IP address}:80`
![Connect To App Image 3](./assets/ch-5/9-connect-to-app/connect-to-app-3.png)
4. View your beautiful creation, you should see a welcome page pop up
![Connect To App Image 4](./assets/ch-5/9-connect-to-app/connect-to-app-4.png)

### Cleaning Up
Once you see your welcome page for the app pop up, you will need to get rid of your resource group. to do this:
1. Navigate back to the `Microsoft Azure Portal`
![Cleaning Up Image 1](./assets/ch-5/1-login-azure/login-azure-1.png)
1. Search for and navigate to `Resource groups`
![Cleaning Up Image 2](./assets/ch-5/1-login-azure/login-azure-2.png)
1. Click on the name of your `resource group`
![Cleaning Up Image 3](./assets/ch-5/1-login-azure/login-azure-3.png)
1. Click on `Delete resource group` 
![Cleaning Up Image 4](./assets/ch-5/1-login-azure/login-azure-4.png)
4. Then type the entire name of your `resource group` in the form and click `Delete`
  * This will take several minutes to delete, do not refresh the page, you can see the status of the deletion in your `notifications` button. This is at the top right and looks like a bell button
![Cleaning Up Image 5](./assets/ch-5/1-login-azure/login-azure-5.png)
## Closing Summary
### Index
* Provide definitions to keywords that were provided throughout the lesson

### Summing It Up
* Provide a short summarization/explanation for each lecture objective

### Resources
* Provide any helpful links that you used to write the lesson
* Or any link you think would be helpful for students to read through
  * Even if you place the link in the text somewhere you should still provide it here
