# Developer Technical Test - Pet Store

## Summary
This repository contains the technical test done for the following requirements :  https://github.com/rimaz523/unify-pet-store/blob/master/Developer_Technical_Test.pdf

## Tech Stack & Patterns Used
* .net core 6.0
* Clean Architecture Pattern with Mediatr. Solution Template Used : https://www.nuget.org/packages/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/
* XUnit
* Automapper
* Swagger
  
## Getting Started
* Clone the app to your dev machine. `git clone https://github.com/rimaz523/unify-pet-store.git`
* When running the console app, change directory to the console app :  `cd <sln-name>\src\ConsoleApp\` and then execute command `dotnet run`.
* If running the web api app, change directory to the WebApi app :  `cd <sln-name>\src\WebApi\` and then execute command `dotnet run`.

## TODO : 
* Implement code formatting using dotnet format and an editorconfig file. Read more : https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-format
* Improve Unit test coverage
* Implement end to end tests
* Implement a standard response for web api which should also handle how errors are surfaced
* Implement logging for Console App
* Implement CI/CD pipeline if solution is to be deployed to a web app service in Azure. This includes necessary infrastructure as code for the web app.
* Improve swagger documentation for the web api

## ChatGPT Transcripts
* When writing unit tests : https://chat.openai.com/share/ff61ea88-a102-43f1-9aa3-68a25dfce967