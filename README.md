# Mercadonna Website Project

A robust web application built using the ASP.net core 7, MVC architecture, Entity Framework and Identity.
The PostgreSQL database was imposed for the project, if it were not I would have choose Microsoft MySQL.

This project is tailored for those looking to understand the intricacies of modern web development while taking advantage of the Microsoft technology stack.

## Getting Started

These instructions will help you set up the project on your local machine for development and testing purposes.

## Prerequisites

Before you get started, make sure you have the following installed:

- [.NET Core SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)

## Installing

1. **Clone the repository:**
    ```bash
    git clone https://github.com/Jamryl749/Mercadona_MVC.git
    ```

2. **Navigate to the project directory:**
    ```bash
    cd Mercadonna-Website-Project
    ```

3. **Restore the .NET Packages:**
    ```bash
    dotnet restore
    ```

4. **Update the connection string:** 
    - Open `appsettings.json` and modify the `ConnectionStrings` section with your PostgreSQL credentials.
    - If you wish to further develop/debug the project, modify the `ConnectionStrings` section in the `appsettings.Development.json` located under the `appsettings.json` file.
    - If you wish to deploy for production your project, modify the `ConnectionStrings` section in the `appsettings.Production.json` located under the `appsettings.json` file.

5. **Run the DbInitializer:**
    - The first time you run the application, the `DbInitializer.cs` will automatically handle migrations and set up an admin account for you.
    - If you change the another database (MySql), you will need to update the `Program.cs` file.
    - Change ```builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));```
    - To ```builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));``` for MySql

6. **Run the application:**
    ```bash
    dotnet run
    ```

## Running the tests

Tests are crucial for ensuring the stability of our application. Here's how to run them:

1. **Open the project in Visual Studio 2022.**
2. **Navigate to `Test > Run All Tests` in the main menu.**

You will find tests under the following directories:
- Mercadona.Tests
- Mercadona.DataAccess.Tests
- Mercadona.Models.Tests

## Deployment

While this is primarily a student project, if you wish to deploy it to a live system, consider using services like [Azure](https://azure.microsoft.com/) or [AWS](https://aws.amazon.com/). Ensure you follow best practices, especially concerning database security and configurations.

## Built With

- [ASP.net core 7](https://dotnet.microsoft.com/)
- [Entity Framework](https://docs.microsoft.com/ef/)
- [Identity](https://docs.microsoft.com/aspnet/core/security/authentication/identity)
- [JQuery](https://jquery.com/)
- [DataTables](https://datatables.net/)
- [Tinysort](http://tinysort.sjeiti.com/)
- [Notiflix](https://www.notiflix.com/)

## Contributing

While this is a student project, contributions are always welcome! Please create a pull request to propose changes.

## Versioning

The current version of the project is 1.0.

## Authors

- **Jeremie Godard**

## License

This project is licensed under the MIT License.
