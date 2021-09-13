# Deploys your applcations to the VMs Public IP Address
export DOTNET_CLI_HOME=/home/student
export HOME=/home/student
cd /home/student/coding-events-api/CodingEventsAPI
sudo ASPNETCORE_URLS="http://*:80" ./bin/Release/netcoreapp3.1/linux-x64/publish/CodingEventsAPI