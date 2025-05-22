Tax Calculator Frontend
The TaxCalculatorFrontend is an Angular 18 application that allows users to input their gross annual salary and receive a detailed tax calculation via a backend API. It features responsive design, modular components, and unit testing.
________________________________________
 Features
•	Input for gross annual salary
•	Live API call to .NET backend
•	Displays tax breakdown (gross/net salary, tax paid monthly and annually)
•	Dark/light theme toggle for accessibility
•	Clean UI with standalone component structure
________________________________________
 Technologies Used
•	Angular v18 with standalone components
•	TypeScript
•	SCSS / CSS3
•	HttpClientModule (for API communication)
•	Jasmine & Karma for testing
________________________________________
 Setup Instructions
 Prerequisites
•	Node.js (v18 or higher recommended)
•	Angular CLI v18:
•	npm install -g @angular/cli

 How to Run
1.	Navigate to the frontend folder:
2.	cd income-tax-calculator-frontend
3.	Install dependencies:
4.	npm install
5.	Start the development server:
6.	ng serve
7.	Open your browser and go to:
8.	http://localhost:4200
 Ensure your backend is running at https://localhost:7056 to enable full functionality.
________________________________________
 Features in Detail
•	Form Validation: Salary must be > 0 to enable submission.
•	Live HTTP Integration: Sends POST request to the backend and maps the tax breakdown.
•	Standalone Angular Components: Each feature is modular and independently testable.
•	Dark Mode Toggle: UI can be toggled to dark/light themes for accessibility.
________________________________________
 Running Unit Tests
Run all frontend tests with:
ng test
________________________________________
 Known Issues
•	Must match backend port in tax-calculator.component.ts
•	localhost CORS error if backend not running
________________________________________
 Recommended Tools
•	Visual Studio Code

________________________________________
 API Endpoint
POST https://localhost:7056/api/taxcalculator/calculate
