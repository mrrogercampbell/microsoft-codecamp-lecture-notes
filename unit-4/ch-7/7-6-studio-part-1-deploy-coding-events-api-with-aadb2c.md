## 7.6 Studio Part 1: Deploy Coding Events API with AADB2C
### Setup
#### Set Up Local MySQL
1. Open MysQL Workbench by searching in your taskbar
2. Log into your local server instance
3. in the script area paste in the setup script:
```sql
DROP database IF EXISTS coding_events;
DROP USER IF EXISTS 'coding_events'@'localhost';
CREATE DATABASE coding_events;
CREATE USER 'coding_events'@'localhost' IDENTIFIED BY 'launchcode';
GRANT ALL PRIVILEGES ON coding_events.* TO 'coding_events'@'localhost';
FLUSH PRIVILEGES;
```
4. run the script with the lightning icon or with `ctrl+shift+enter` in windows. For mac it is `cmd+enter`
   * Visualize that the script ran at the bottom
   * if you get any error/warning about not being able to drop a `coding_events` database or user with this script, that is okay.
#### Set Up Local Secrets Manager
 * **Note**: Be sure to run the following commands in `Bash`
1. Use the following commands to create a secret store:
```sh
# This updates your CodingEventsAPI.csproj so that it stores the name of your secret store
$ dotnet user-secrets init --id coding-events-secret-store-id
```
2. Create the local `Connection String` secret:
```sh
dotnet user-secrets set ConnectionStrings:Default "server=localhost;port=3306;database=coding_events;user=coding_events;password=launchcode;"
```
3. Run The application
#### Update the Coding Events API
1. In git bash, Make sure that you are working on your forked `coding-events-api` and in the `3-aadb2c` branch
   * There are some new fields that you will notice in `appsettings.json`, it will look like the following
     * Specifically `ServerOrigin`, `Audience`, and `MetadataAddress`
```json
{
   "Logging": {
      "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
      }
   },
   "AllowedHosts": "*",
   "ServerOrigin": "",
   "KeyVaultName": "",
   "JWTOptions": {
      "Audience": "",
      "MetadataAddress": "",
      "RequireHttpsMetadata": true,
      "TokenValidationParameters": {
         "ValidateIssuer": true,
         "ValidateAudience": true,
         "ValidateLifetime": true,
         "ValidateIssuerSigningKey": true
      }
   }
}
```
#### ServerOrigin
The ServerOrigin field is used to define the _origin_ of a server. The API has been configured to use this origin for creating resource links (for actions or relations to other resources). The term origin is defined by _where the server is hosted_ and is comprised of:

* The protocol (`http` or `https`)
* The [Fully Qualified Domain Name (FQDN)](https://networkencyclopedia.com/fully-qualified-domain-name-fqdn/)
* The port (if it differs from the implicit port derived from the protocol)

Locally, your API `ServerOrigin` will be:
  * `https://localhost:5001` (as seen in the `appsettings.Development.json` file).

However, _after you deploy the API_ the `ServerOrigin` will _need to be updated_ to reference the new location it is hosted from (the host VM’s public IP address):

  * `https://<public IP>` (where port `443` is implied by the `https` protocol in the origin)

#### JWTOptions
* The `JWTOptions` are used to configure the [JWT authentication middleware](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer?view=aspnetcore-3.0) used by the API to validate the access tokens it receives. The nested `TokenValidationParameters` object set the boolean flags for controlling which claims in the token should be validated:
   * The issuer is your AADB2C tenant
   * The audience is the client ID for the correct registered application
   * The token is not expired
   * The token was signed using your AADB2C tenant signing key (which it automatically retrieves from the metadata document)
* The two fields within the `JWTOptions` object entry that you will need to update are:
   * `MetadataAddress`: the URL of the JSON metadata document that describes the OIDC capabilities and endpoints for your AADB2C service
   * `Audience`: the application ID (client ID) of the _intended audience_ for the token.
* You may need to refer to your notes or previous walkthroughs to get these values.
### Run Locally
#### Checklist
#### Viewing Documentation
#### Make Requests to Protected Endpoints
Open postman, and Make requests to the following endpoints

1. `POST /api/events`
2. `POST /api/tags`
3. `PUT /api/events/{codingEventId}/tags/{tagId}`
4. `DELETE /api/events/{codingEventId}`
### Limited Guidance: API Deployment
you will create scripts that will be responsible for the following:
1. `configure-vm.sh`: configures the runtime environment for the API, nearly identical to the script you wrote in your previous deployment
2. `configure-ssl.sh`: installs and configures the NGINX web server and provisions a self-signed certificate for serving the API over a secure connection
3. `deliver-deploy.sh`: delivers and deploys Coding Events API as a background service running in the VM
#### Provision Resources
### Solutions
#### Local Deployment
#### Production/Remote Deployment
1. Access your VM via your terminal
     * Need a refresher check <Provide Link to past walkthrough>
2. Remove all pre-existing files:
   * Make **SURE** you are in the right directory before you run the `rm -rf` command below!
   * `rm -rf coding-events-api mysql-apt-config_0.8.15-1_all.deb project_build_script.sh deploy_project_script.sh packages-microsoft-prod.deb setup.sql`
3. Create a `configure-vm.sh` script: `touch configure-ssl.sh`
4. Open the `configure-vm.sh` script in nano and paste in the following code:
```sh
#!/bin/bash

set -ex

# -- env vars --

export DEBIAN_FRONTEND=noninteractive

# -- end env vars --

# dotnet dependencies

wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update && \
sudo apt-get install -y sudo apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-3.1

# mysql dependencies

wget https://dev.mysql.com/get/mysql-apt-config_0.8.15-1_all.deb

sudo dpkg -i mysql-apt-config_0.8.15-1_all.deb

# set environment variables that are necessary for MySQL installation
sudo debconf-set-selections <<< "mysql-community-server mysql-community-server/root-pass password lc-password"
sudo debconf-set-selections <<< "mysql-community-server mysql-community-server/re-root-pass password lc-password"

# install MySQL in a noninteractive way since the environment variables set the necessary information for setup
sudo apt-get update && sudo apt-get install mysql-server -y

### MySQL section START ###

# create a setup.sql file which will create our database, our user, and grant our user privileges to the database
cat >> setup.sql << EOF
CREATE DATABASE coding_events;
CREATE USER 'coding_events'@'localhost' IDENTIFIED BY 'launchcode';
GRANT ALL PRIVILEGES ON coding_events.* TO 'coding_events'@'localhost';
FLUSH PRIVILEGES;
EOF

# using the mysql CLI to run the setup.sql file as the root user in the mysql database
mysql -u root --password=lc-password mysql < setup.sql

# END CONFIGURE
```
5. Create a `configure-ssl.sh` script: `touch configure-ssl.sh`
6. Open the `configure-ssl.sh` script in nano and paste in the following code:
```sh
#!/bin/bash

set -ex

# -- env vars --

export DEBIAN_FRONTEND=noninteractive
HOME=/home/student

# dir where nginx will look for the SSL cert and key
nginx_ssl_dir=/etc/nginx/external

# ssl
tls_key_path="${nginx_ssl_dir}/key.pem"
tls_cert_path="${nginx_ssl_dir}/cert.pem"

# -- install dependencies --

sudo apt-get update && sudo apt-get install nginx -y

# -- end install dependencies --

# -- generate self signed cert --

# create random generator file
sudo touch /tmp/.rnd

# create certs dir
# sudo mkdir "$nginx_ssl_dir"

sudo openssl req -x509 -newkey rsa:4086 \
-subj "/C=US/ST=Missouri/L=St. Louis/O=The LaunchCode Foundation/CN=localhost" \
-keyout "$tls_key_path" \
-out "$tls_cert_path" \
-days 3650 -nodes -sha256 \
-rand /tmp/.rnd

# -- end self signed cert --

# -- configure nginx --
sudo touch /etc/nginx/nginx.conf

nginx_conf=/etc/nginx/nginx.conf

# save default conf as a backup
sudo mv "$nginx_conf" "${nginx_conf}.bak"

cat << EOF >> "$nginx_conf"
events {}
http {
  # proxy settings
  proxy_redirect          off;
  proxy_set_header        Host \$host;
  proxy_set_header        X-Real-IP \$remote_addr;
  proxy_set_header        X-Forwarded-For \$proxy_add_x_forwarded_for;
  proxy_set_header        X-Forwarded-Proto \$scheme;
  client_max_body_size    10m;
  client_body_buffer_size 128k;
  proxy_connect_timeout   90;
  proxy_send_timeout      90;
  proxy_read_timeout      90;
  proxy_buffers           32 4k;

  limit_req_zone \$binary_remote_addr zone=one:10m rate=5r/s;
  server_tokens  off;

  sendfile on;
  keepalive_timeout   29; # Adjust to the lowest possible value that makes sense for your use case.
  client_body_timeout 10; client_header_timeout 10; send_timeout 10;

  upstream api{
    server localhost:5000;
  }

  server {
    listen     *:80;
    add_header Strict-Transport-Security max-age=15768000;
    return     301 https://\$host\$request_uri;
  }

  server {
    listen                    *:443 ssl;
    server_name               codeeventsapi.com;
    ssl_certificate           $tls_cert_path;
    ssl_certificate_key       $tls_key_path;
    ssl_protocols             TLSv1.1 TLSv1.2;
    ssl_prefer_server_ciphers on;
    ssl_ciphers               "EECDH+AESGCM:EDH+AESGCM:AES256+EECDH:AES256+EDH";
    ssl_ecdh_curve            secp384r1;
    ssl_session_cache         shared:SSL:10m;
    ssl_session_tickets       off;
    ssl_stapling              on; #ensure your cert is capable
    ssl_stapling_verify       on; #ensure your cert is capable

    add_header Strict-Transport-Security "max-age=63072000; includeSubdomains; preload";
    add_header X-Frame-Options DENY;
    add_header X-Content-Type-Options nosniff;

    #Redirects all traffic
    location / {
      proxy_pass http://api;
      limit_req  zone=one burst=10 nodelay;
    }
  }
}
EOF

# reload nginx to use this new conf file
sudo nginx -s reload
```
5. Run the `bash configure-ssl.sh` script
6. Create a `deliver-deploy.sh` script: `touch deliver-deploy.sh`
7. Open the `deliver-deploy.sh` script in nano and paste in the following code
8. Make sure to put your `github_username` and `solution_branch` in the `# TODO` sections below

```sh
#! /usr/bin/env bash

set -ex

# -- env vars --

# for cloning in delivery

# TODO: enter your GitHub user name
github_username=mrrogercampbell

# TODO: enter the name of your project branch that has your updated code
solution_branch=3-aadb2c

# api
api_service_user=api-user
api_working_dir=/opt/coding-events-api

# needed to use dotnet from within RunCommand
export HOME=/home/student
export DOTNET_CLI_HOME=/home/student

# -- end env vars --

# -- set up API service --

# create API service user and dirs
useradd -M "$api_service_user" -N
sudo mkdir "$api_working_dir"

chmod 700 /opt/coding-events-api/
chown $api_service_user /opt/coding-events-api/

# generate API unit file
cat << EOF > /etc/systemd/system/coding-events-api.service
[Unit]
Description=Coding Events API

[Install]
WantedBy=multi-user.target

[Service]
User=$api_service_user
WorkingDirectory=$api_working_dir
ExecStart=/usr/bin/dotnet ${api_working_dir}/CodingEventsAPI.dll
Restart=always
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=coding-events-api
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false
Environment=DOTNET_HOME=$api_working_dir
EOF

# -- end setup API service --

# -- deliver --

# deliver source code

git clone https://github.com/$github_username/coding-events-api /tmp/coding-events-api

cd /tmp/coding-events-api/CodingEventsAPI

# checkout branch that has the appsettings.json we need to connect to the KV
git checkout $solution_branch

dotnet publish -c Release -r linux-x64 -o "$api_working_dir"

# -- end deliver --

# -- deploy --

# start API service
service coding-events-api start

# -- end deploy --
```
### Deliverable