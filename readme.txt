AnimalShelterAPI Readme
This API is a project that implements the Domain Driven Design (DDD) approach, using the Command Query Responsibility Segregation (CQRS) pattern, vertical sliced controllers, rich domain models and the repository pattern.

The main goal of this project is to provide a robust and scalable API for managing an animal shelter. The project is organized into different layers, each one with a specific responsibility:

The Application layer is responsible for defining the API endpoints and the business logic for each request. It also contains the Command and Query objects that are used to interact with the domain layer.

The Domain layer is the core of the application, where the business rules and the domain models are defined. It contains the aggregate roots, entities, value objects and services that make up the domain.

The Infrastructure layer is responsible for the persistence of the data, as well as the communication with external services. It contains the repositories, data access objects, and other infrastructure-related classes.

Features
This API provides the following features:

Creating, updating, and deleting animals,users,clients in the shelter.
Searching for animals by different criteria, such as species and healthcondition.
Adopting animals from the shelter.
Giving animals to shelter.
Checking if clients are responsible enough to adopt pets.

Technologies Used
This project was built using the following technologies:

REST
.NET Core 3.1
Entity Framework Core
MSTest
MediatR
Swagger

How to Run the Project
To run this project locally, you will need to have .NET Core 3.1 installed on your machine. Once you have installed .NET Core, you can follow these steps:

Clone the repository to your local machine.
Open a terminal or command prompt and navigate to the root directory of the project.
Run the command dotnet run to start the application.
Once the application is running, you can access the Swagger documentation by navigating to https://localhost:5001/swagger.
How to Run the Tests
To run the tests for this project, you can follow these steps:

Open a terminal or command prompt and navigate to the root directory of the project.
Run the command dotnet test to run all the tests in the project.

Contributing

If you want to contribute to this project, feel free to create a pull request. Please make sure that your changes are well-documented and that all tests pass before submitting the pull request.

License
This project is licensed under the MIT License. See the LICENSE file for more details.