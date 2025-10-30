# RecipeShareApi

A simple Restful API to manage recipes using C#, Angular and MS SQL Server. Application includes unit tetst and performance benchmarks.

## Setup Instructions
1. Clone repository: 
   git clone https://github.com/phiwe-saba/RecipeShareApi.git
   cd RecipeShareApi
   
2. Restore NuGet packages: 
   dotnet restore
   
3. Seed data: 
   Update-Databse
   
5. Run API: 
   dotnet run
6. Run Tests: 
   cd RecipeShare.Tests -> dotnet test
   
7. Run Benchmarks: 
   cd RecipeShare.Benchmarks -> dotnet run -c Release

## Architecture Diagram
<img width="1417" height="502" alt="image" src="https://github.com/user-attachments/assets/35c07373-4cc9-4e55-9931-00292a7942be" />

