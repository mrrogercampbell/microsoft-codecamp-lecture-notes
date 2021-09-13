# Sets an enviornmental variable so that you can install the needed dependiences on your VM
export HOME=/home/student
# Begins the process of installing mysql and dotnet dependecies
sudo apt-get update
wget https://dev.mysql.com/get/mysql-apt-config_0.8.15-1_all.deb
sudo dpkg -i mysql-apt-config_0.8.15-1_all.deb
sudo apt-get update
sudo apt-get install debconf-doc
sudo apt-get update

# Configures yoru mysql server instance
sudo debconf-set-selections <<< "mysql-community-server mysql-community-server/root-pass password lc-password"
sudo debconf-set-selections <<< "mysql-community-server mysql-community-server/re-root-pass password lc-password"
sudo DEBIAN_FRONTEND=noninteractive apt-get -y install mysql-server

# Creates a file called setup.sql and write configuration setting inside of it to create a database, user, and set the users privileges
cat >> setup.sql << EOF
CREATE DATABASE coding_events;
CREATE USER 'coding_events'@'localhost' IDENTIFIED BY 'launchcode';
GRANT ALL PRIVILEGES ON coding_events.* TO 'coding_events'@'localhost';
FLUSH PRIVILEGES;
EOF
sudo mysql -u root --password=lc-password mysql < setup.sql
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1

# Setting enviornmental variables so that you can clone down your Coding Events API application
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
export DOTNET_CLI_HOME=$HOME

# Clones down your Coding Events API application
git clone <Your GitHub Repo Clone Link Goes Here>

# Navigates into the Coding Events API directory you just cloned down
cd /home/student/coding-events-api
# Switches to the branch where you made changes and added the name of your Key Vault
git checkout 2-mysql-solution

# Utilize DOTNET to build a release version of your application on the VM
cd /home/student/coding-events-api/CodingEventsAPI
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/coding-events-api/CodingEventsAPI
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true

# Deploys your applcations to the VMs Public IP Address
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/coding-events-api/CodingEventsAPI
sudo ASPNETCORE_URLS="http://*:80" ./bin/Release/netcoreapp3.1/linux-x64/publish/CodingEventsAPI