Income Tax Calculator Backend
The Tax Calculator Backend is an ASP.NET Core 9 Web API project designed to calculate tax based on configurable tax bands. It serves as the data and logic layer for the Angular frontend.
________________________________________
 Features
�	RESTful API to calculate income tax
�	In-memory database using Entity Framework Core
�	Clean, testable architecture
�	Seed data for tax bands on startup
�	Integration with Angular frontend
________________________________________
 Technologies Used
�	ASP.NET Core 9
�	C#
�	Entity Framework Core (InMemory)
�	NUnit (Unit testing framework)
�	Moq (Mocking framework)
�	Swagger (API documentation)
________________________________________
 Setup Instructions

 Prerequisites
�	.NET 9
�	Visual Studio 2022 
 Running the Backend
1.	Clone the repository
2.	Open the project folder in your IDE
3.	Restore dependencies (if needed):
4.	dotnet restore
5.	Run the application:
6.	dotnet run
7.	Backend should be available at:
8.	https://localhost:7056
9.	Test the API at:
10.	https://localhost:7056/swagger
	Swagger is automatically enabled in Development mode and provides an interface to test your API endpoints.
Note: CORS is enabled for http://localhost:4200 for Angular frontend integration.
________________________________________
 API Endpoint
POST /api/taxcalculator/calculate
Host: https://localhost:7056
____________________________________
 Running Unit & Integration Tests
Unit Tests
dotnet test


