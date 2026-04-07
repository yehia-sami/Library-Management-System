# Library Management System

A robust, full-stack web application built with **ASP.NET Core 8**, designed to streamline library operations, manage book inventories, and handle user registrations with secure authentication.

## 🚀 Technical Stack

* **Framework:** .NET 8 (ASP.NET Core MVC)
* **Database:** SQL Server
* **ORM:** Entity Framework Core (Code First)
* **Security:** ASP.NET Core Identity (Authentication & Authorization)
* **UI:** Razor Pages, Bootstrap 5, and FontAwesome

## ✨ Key Features

* **Book Management:** Full CRUD (Create, Read, Update, Delete) functionality for the library catalog.
* **User Authentication:** Secure Login and Registration system using Identity.
* **Role-Based Access:** Differential access for Librarians (Admins) and Members.
* **Search & Filter:** Efficiently find books by title, author, or category.
* **Responsive Design:** Optimized for both desktop and mobile viewing.

## 🛠️ Project Structure

The project follows a clean architectural pattern to ensure separation of concerns:
* **Models:** Data structures and Database Entities.
* **Repositories:** Abstraction layer for data access logic.
* **Controllers:** Handling HTTP requests and coordinating between models and views.
* **Views:** Dynamic Razor templates for the frontend.

## ⚙️ Setup & Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yehia-sami/Library-Management-System.git](https://github.com/yehia-sami/Library-Management-System.git)
    ```
2.  **Configure the Database:**
    Open `appsettings.json` and update the `DefaultConnection` string with your local SQL Server instance:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=LibraryDb;Trusted_Connection=True;"
    }
    ```
3.  **Apply Migrations:**
    Run the following command in the Package Manager Console:
    ```powershell
    Update-Database
    ```
4.  **Run the application:**
    Press `F5` in Visual Studio or use `dotnet run`.

## 📝 License
This project is for learning purposes. Feel free to use the code for learning and development.
