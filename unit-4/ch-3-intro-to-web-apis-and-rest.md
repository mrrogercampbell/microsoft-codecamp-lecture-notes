# Chapter 3: Introduction to Web APIs & REST

## Web APIs
### JSON
* Here they talk about JSON and provide a [link](https://education.launchcode.org/intro-to-professional-web-dev/chapters/fetch-json/data-formats-json.html#json) to the LC JS textbook.
* I will need to provide a detail explanation of what JSON is here

## Walkthrough: Setup Your Development Machine
* For `Window Users`: Please follow instruction provided in the [textbook](https://education.launchcode.org/azure/chapters/web-apis/walkthrough_setup-powershell.html)

* `Mac User`: Will use [Homebrew](https://brew.sh/) (AKA: Brew) instead of [Chocolaty Package Manager](https://chocolatey.org/)

### Walkthrough: Mac Users Brew Installation:
1. Open your terminal
2. Input the following command in your terminal
```sh
$ /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```
3. Once the installation is completed, verify it installed properly:
```sh
$ brew -v

# Outputs:
Homebrew 3.2.0 # You might have a newer version
Homebrew/homebrew-core (git revision 9d20636855; last commit 2021-06-29) # You might not see this
Homebrew/homebrew-cask (git revision 1572962f5f; last commit 2021-06-29) # You might not see this
```
### Course Tools Installation
* Before any user try installing these be sure to check that they are not already installed:
* To check run the following commands _individually_:
* Check to see if `dotnetcore-sdk` is installed:
```sh
$ dotnet --version
```
* Check to see if `Git` is installed:
```sh
$ git --version
```
* If you receive a version output then you do not need to install
* If you do not receive a version output then follow the steps provided [here](https://education.launchcode.org/azure/chapters/web-apis/walkthrough_setup-powershell.html#course-tools-installation)

## Walkthrough: Consuming the CodingEventsAPI With Postman
### Setup
#### Installing Postman
* [Textbook instructions](https://education.launchcode.org/azure/chapters/web-apis/walkthrough_postman-rest.html#installing-postman)

#### Fork and Clone the CodingEventsAPI Source Code
* Then students need to Fork and Clone down the [coding-events-api repo](https://github.com/LaunchCodeEducation/coding-events-api/tree/1-sqlite)
  * They can then skip the fork and clone step in [chapter 4](https://education.launchcode.org/azure/chapters/hosting/walkthrough.html#clone-the-forked-repo)
* Then change to the `1-sqlite` branch
```bash
git checkout 1-sqlite
```

#### Coding Events APIs
* This is the point where he does a crappy job of walking them through the code base. Mainly the controllers and actions
  * Write up a more detailed explanation of the code

### Making Request to the CodingEventsAPI
* Be sure you are `cd`d into the `CodingEventsAPI project` directory and then run:
```sh
$ dotnet run
```