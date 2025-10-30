# RecipeShareApi

A simple Restful API to manage recipes. Application includes unit tetst and performance benchmarks.

## Setup Instructions
1. Clone repository: https://github.com/phiwe-saba/RecipeShareApi.git
   cd RecipeShareApi
2. Restore NuGet packages: dotnet restore
3. Seed data: Add-Migration -> Update-Databse
4. Run API: dotnet run
5. cd RecipeShare.Tests -> dotnet test
6. cd RecipeShare.Benchmarks -> dotnet run -c Release
