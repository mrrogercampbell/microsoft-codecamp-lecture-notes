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
1. Go back to the Virtual Machines, either by searching for `Virtual Machines` in the search bar OR Clicking on `Microsoft Azure` next to the search bar and then clicking on `Virtual machines`
2. click on the name of your VM, this should open up a new tab that looks like this: (insert screenshot here)
3. On the left side, navigate to down to Operations, and click on `Run command`
4. Click on RunShellScript
5. paste the following commands into the linux shell script area:
``` sh
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1
```
6. Click on `Run`
  * you should see some output in the bottom on the screen in the black box after a minute or two (it takes a little bit of time to run).

### Create the Project
Since we have our server all setup and ready to go, our next step is to just create a new dotnet project in our Azure VM.
1. Make sure you are still in the Run Command Script area, get rid of anything in the `Linux Shell Script` area. Paste the following code and then click `Run`:
``` sh
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student
dotnet new mvc -n hello-world
```
  * Again, this might also take a minute to run and return output to you in the black area below the `Run` button
2. Next, erase any prior code in the Linux Shell Script area. Paste this code this code, and click the `Run` button:
``` sh 
cd /home/student/hello-world
pwd
ls
```
  * you should see some output that looks like this (insert image here):

### Publish the Project
Now, we're going to publish the project on the server, to do this:
1. copy and paste the following code into the `Linux Shell Script` are
``` sh
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/hello-world
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true
```
2. To verify that the command ran and build our files for publishing properly, we're going to run another command:
``` sh
ls /home/student/hello-world/bin/Release/netcoreapp3.1/linux-x64/publish/
```
  * You should see some output here. This is listing the files in the `/home/student/hello-world/bin/Release/netcoreapp3.1/linux-x64/publish/` directory
  
### Open Network Security Groups
Holy crap, you did it. azure is up and running, you've built your project. But now we need to setup some security group rules. We're doing this because we need to allow traffic to the VM. We're going to do this by opening port 80 on our VM. To do this:
1. Exit out of the `Run Shell Script` area.
2. Scroll up in the virtual machine area under `Settings` and click on `Networking` 
3. Click on `Add inbound port rule`
4. a new tab called `Add inbound security rule` should pop up. Fill out the form with the following information:
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
6. Next, we need to do the same and create an outbound rule. To do this Click `Outbound port rules` and then click on `Add outbound port rule`
7. Fill out the form with the following information:
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
### Deploy the Project
1. Navigate back to `Operations` and click on `Run command`
2. Click on `RunShellScript`
3. Run these commands:
``` sh
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/hello-world
ASPNETCORE_URLS="http://*:80" ./bin/Release/netcoreapp3.1/linux-x64/publish/hello-world
```
  * You should _not_ see any output here.
  
### Connect to App
Now is the final step, seeing what we just deployed and are running.
1. 
### Troubleshooting
### Cleaning Up
## Closing Summary
### Index
* Provide definitions to keywords that were provided throughout the lesson

### Summing It Up
* Provide a short summarization/explanation for each lecture objective

### Resources
* Provide any helpful links that you used to write the lesson
* Or any link you think would be helpful for students to read through
  * Even if you place the link in the text somewhere you should still provide it here
