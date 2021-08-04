# Chapter 25: How the Internet Works
- [Chapter 25: How the Internet Works](#chapter-25-how-the-internet-works)
  - [Client-Server Model](#client-server-model)
  - [Protocols](#protocols)
  - [HTTP: Hypertext Transfer Protocol](#http-hypertext-transfer-protocol)
  - [TCP/IP: Transmission Control Protocol/ Internet Protocol](#tcpip-transmission-control-protocol-internet-protocol)
  - [DNS: Domain Name Service](#dns-domain-name-service)
  - [Web Addresses](#web-addresses)
## Client-Server Model 
* The `client-server model` is a distributed application structure which allows `clients` and `server` (ie: computers) talk to each other
  * `Client` is an browser that runs computer, laptop, and or mobile device
  * `Server` is a computer somewhere in the world that processes your client's request for data and returns it
* When working on a development project on your own computer you are actually using a the client-server model, but the server that you are accessing is your own computer
  * We call this working in a local environment
  * We will talk about this more later

## Protocols
* Protocols in the context of the internet are a construct of rules for how data is routed from one computer to another
* In this lesson we will focus on the following web protocols:
  1. Hypertext Transfer Protocol (HTTP): High-level web communication for transferring files and information
  2. Transmission Control Protocol/ Internet Protocol (TCP/IP): Low-level web communication for transferring small chunks of raw data known as packets
  3. Domain Name Service (DNS): Translates human-friendly names into server addresses

## HTTP: Hypertext Transfer Protocol
* `HTTP` is the most important protocol for engineers to understand and will be the main focus of this lesson
* It is a communication protocol between `clients` and `servers` which allows the fetching of resources such as: HTML, CSS, JS, Images, etc.
* `Clients` and `servers` are able to to communicate by exchanging individual messages
  * `Request`: Is the message sent by a client to a server
  * `Response`: Is the message sent by a server to a client after receiving a request
* `HTTPS` is a version of HTTP protocols dictates that the server should encrypts any data before sending it and in turn the client then decrypts it once received

## TCP/IP: Transmission Control Protocol/ Internet Protocol
* `TCP/IP` is a low-level protocol
* For the sake of simplicity and to keep these notes short; all that you need to know for the moment is that TCP/IP allows `raw data` to be sent from one place to another on the internet
* When a server sends a file back to a client, a few things happen to that data:
  * The file is physically sent across a series of network components, including cables, routers, and switches
  * Files are broken down into packets—small chunks of a standard size—that are individually sent from one location to the next
  * Once they arrive at their final destination they are then reassembled

## DNS: Domain Name Service
* It is the phone-book of the internet
* When you type `www.google.com` and press enter you are actually using an alias; ie: a domain name
  * www.google.com =  142.251.33.197
* Every `domain name` has a corresponding `IP Address` which is a digital address where the resources for a site you are try to access live
* When you send a request via your browser it will attempt to resolve the domain name by looking it up via a `nameserver`
* `nameserver` is a directory of domains and IP addresses

## Web Addresses
* 