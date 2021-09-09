export HOME=/home/student
sudo apt-get update
wget https://dev.mysql.com/get/mysql-apt-config_0.8.15-1_all.deb
sudo dpkg -i mysql-apt-config_0.8.15-1_all.deb
sudo apt-get update
sudo apt-get install debconf-doc
sudo apt-get update
sudo debconf-set-selections <<< "mysql-community-server mysql-community-server/root-pass password lc-password"
sudo debconf-set-selections <<< "mysql-community-server mysql-community-server/re-root-pass password lc-password"
sudo DEBIAN_FRONTEND=noninteractive apt-get -y install mysql-server
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
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
export DOTNET_CLI_HOME=$HOME

git clone <Your GitHub Repo Clone Link Goes Here>

cd /home/student/coding-events-api
git checkout 2-mysql-solution
cd /home/student/coding-events-api/CodingEventsAPI
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/coding-events-api/CodingEventsAPI
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true