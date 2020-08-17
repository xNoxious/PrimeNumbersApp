# PrimeNumbersApp
Small microservice app to check whether a number is prime and get the next prime number after a given one.

**Important note**: This is a project that is implemented for the sake of showcasing a microservices oriented application. This project can easily be extended to serve one's purpose, should they need to use it. 

**Assumptions**: Even though it has not been explicitly requested, I have added a mongodb to showcase knowledge of how this microservice can have a database layer, as well as show knowledge of Repository and Service patterns, dependency injection, deployment of database alongside application in docker, usage of Api Gateway pattern, experience with unit testing and good software design in general.


This microservice app consists of the following components:
- **PrimeNumbersPlayground** - an ASP.NET Core front-end project to present the user with interactive interface to contact the WebApi.
- **PrimeNumbers.API** - the WebApi that provides services that check if a number is prime, calculate the next prime number after a given one, or fetch it from the database (only numbers from 1 to 20).
The reason the database only works with 1 to 20 is because its solely purpose is to showcase how to implement communication with a NoSQL database (mongodb) and not only provide services with logical operations.
- **APIGateway** - a project that implements the Api Gateway pattern using the Ocelot API Gateway package
- **PrimeNumbers.API.UnitTest** - an xUnit testing solution to showcase the knowledge of writing unit tests as part of the development process.
- **Swagger** documentation for the API project
- **docker-compose** that allows you to run the entire solution with a simple command locally.

# How to run:

1. Fork the project to your local machine
2. Go to the folder where the project is unzipped and run command prompt
3. Execute the following command: **docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d**
4. After everything has run correctly, docker would have fetched the necessary images and created the required containers for the application.
In order to browse the application, you can visit the following addresses:

Web App available at: **http://localhost:8001** (remember, database only fetches from 1 to 20 for the sake of example)

Swagger UI for WebApi available at: **http://localhost:8000/swagger/index.html**

Ocelot API Gateway available at: **http://localhost:7000/** but in order to test it you should provide a correct uri with some parameter, e.g. 

**http://localhost:7000/Primality/GetNumberPrimality/25**

**http://localhost:7000/Primality/GetNextPrimeNumber/29/**

**http://localhost:7000/Primality/GetNextPrimeNumberViaDb/9/**

