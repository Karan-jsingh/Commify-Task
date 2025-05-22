Jaskaran's Income Tax Calculator

The TaxCalculator is a full-stack tax calculator application that allows users to input their gross salary and view a detailed tax breakdown. It consists of:

1.	Backend: Built with ASP.NET Core 9 and C#, responsible for tax calculation logic and API.
2.	Frontend: Developed in Angular 18 with a modern standalone component architecture.
________________________________________
Backend: Income Tax Calculator Backend
 Purpose
The backend calculates income tax based on hardcoded tax bands and exposes an API endpoint for clients.
 Technologies Used
•	ASP.NET Core 9
•	Entity Framework Core with In-Memory Database
•	C#
•	NUnit: Unit testing framework
•	Moq: Mocking framework for unit tests
 Key Components
•	CalculateIncomeTax: Service containing the tax logic
•	TaxCalculatorController: API controller exposing the /api/taxcalculator/calculate endpoint
•	IncomeTaxBand: Entity used for tax bands
•	SalaryDto & IncomeTaxCalculatorResultDto: DTOs for request/response
 How to Set Up and Run
Prerequisites
•	.NET 9
•	Visual Studio 2022+ for backend and VS Code for frontend
Steps
1.	Clone the Repository
2.	Open the Solution (or navigate to the project folder in terminal)
3.	Run the API:
4.	dotnet run
5.	The API will be available at:
6.	https://localhost:7056
7.	Visit:
8.	https://localhost:7056/swagger
to test the endpoint using Swagger UI.
 Running Backend Tests
Run from the test project directory or solution root:
dotnet test
Tests include:
•	Tax calculation service logic
•	Edge cases
•	API controller behavior using integration tests
________________________________________
Frontend: Income Tax Calculator Frontend
 Purpose
The Angular frontend offers a responsive and interactive UI to:
•	Input gross annual salary
•	Calculate taxes via backend
•	Display breakdown (monthly & annual, net & gross)
•	Toggle between dark/light themes
 Technologies Used
•	Angular 18 with standalone components
•	TypeScript
•	HTML & CSS (SCSS optional)
•	HttpClient for API integration
•	Karma & Jasmine for unit testing
 How to Set Up and Run
Prerequisites
•	Node.js
•	Angular CLI v18:
•	npm install -g @angular/cli
•	VS Code

Steps
1.	Navigate to Frontend Folder
2.	Install Dependencies:
3.	npm install
4.	Run the App:
5.	ng serve
6.	Open in browser:
7.	http://localhost:4200
 Running Frontend Tests
ng test
________________________________________

