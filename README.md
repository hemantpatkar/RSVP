# Registration Application
Registration List Application using ASP.NET Core Web API 3.1

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Prerequisite](#prerequisite)
* [Setup](#setup)

## General info
This is a project to create a Rest API service which is build upon solid principle and design patterns. You will be easly able to run this application and just by making few changes in the config you will be able to run it on your local machine.


## Technologies
* Web API/Rest API .Net Core 3.1
* MVC Web Application to Consum the API
* Bootstrap for responsive layout
* Swagger for browsing API

## Prerequisite
* Visual Studio with .Net Core 3.1
* SQL Server 2008 or later

## Setup
1) Git clone https://github.com/hemantpatkar/RSVP.git
2) Open the project in visual studio and open solution properties to select multiple startup project
3) Restore the nuget packages
4) Set Up Database First
    check database.sql file in the repository and run that file on your sql server
    update your server details and credentital in the below connection string in the solution
5) Update Connectionstring in appsettings.json file from Registration.API project
  "ConnectionStrings": {
    "MasterConnection": "Server={Your server address};Initial Catalog=Registration;Persist Security Info=False;User ID={put your userid};Password={put your password };MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
6) Once you run the Registration.API project, it will open your browser, you can copy the url from browser and update RestAPIBaseUrl in appsettings.json file from Registration.Web project. "RestAPIBaseUrl": "https://localhost:44339/api/"
7) Thats it, your application is ready to run.



