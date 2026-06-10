# 🧾 Sale Stored Procedure

A professional **ASP.NET Core MVC** project for managing sale stored evidence, records, models, controllers, migrations, and web assets in a clean structured way.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Programming-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-68217A?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

---

## 📌 Project Overview

**Sale Stored Evidence** is a web-based application built with **ASP.NET Core MVC**. The project is designed to organize and manage sales-related stored evidence through a structured MVC architecture.

This project includes separate folders for **Controllers**, **Models**, **Views**, **Migrations**, and **Static Files**, making the codebase clean, scalable, and easy to maintain.

---

## ✨ Features

- ✅ ASP.NET Core MVC architecture
- ✅ Clean controller, model, and view structure
- ✅ Entity Framework Core migration support
- ✅ SQL Server database integration
- ✅ Static asset management using `wwwroot`
- ✅ Environment-based configuration
- ✅ Scalable and beginner-friendly project structure

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC | Backend web framework |
| C# | Main programming language |
| Entity Framework Core | ORM and database migration |
| SQL Server | Database management |
| HTML / CSS / JavaScript | Frontend UI |
| Visual Studio | Development environment |
| Git & GitHub | Version control |

---

## 📁 Project Structure

```bash
SaleStoredEvidence/
│
├── Controllers/              # Application controllers
├── Models/                   # Data models and business entities
├── Views/                    # Razor views / UI pages
├── Migrations/               # Entity Framework migrations
├── Properties/               # Project launch settings
├── wwwroot/                  # Static files: CSS, JS, images
├── Program.cs                # Application startup file
├── appsettings.json          # Main configuration file
├── appsettings.Development.json
├── SaleStoredEvidence.csproj # Project file
└── SaleStoredEvidence.sln    # Solution file
```

---

## ⚙️ Installation & Setup

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/didar-code/StoreProcedureSale.git
```

### 2️⃣ Open the Project

Open the solution file in Visual Studio:

```bash
SaleStoredEvidence.sln
```

### 3️⃣ Configure Database

Open `appsettings.json` and update your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SaleStoredEvidenceDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4️⃣ Run Migration

Open **Package Manager Console** and run:

```bash
Update-Database
```

Or using .NET CLI:

```bash
dotnet ef database update
```

### 5️⃣ Run the Application

```bash
dotnet run
```

Then open the browser:

```bash
https://localhost:5001
```

---

## 🚀 How to Use

1. Start the project from Visual Studio or terminal.
2. Open the application in your browser.
3. Navigate through the available pages.
4. Add, update, view, or manage sale stored evidence data.
5. Database changes can be handled using Entity Framework migrations.

---

## 🔐 Configuration Files

| File | Description |
|---|---|
| `appsettings.json` | Main project configuration |
| `appsettings.Development.json` | Development environment settings |
| `Program.cs` | Service registration and middleware pipeline |

---

## 📸 Screenshot

Add your project screenshot here:

```markdown
![Project Screenshot](screenshot.png)
```

---

## 🤝 Contribution

Contributions are welcome. To contribute:

1. Fork the repository
2. Create a new branch
3. Make your changes
4. Commit your work
5. Submit a pull request

```bash
git checkout -b feature/new-feature
git commit -m "Add new feature"
git push origin feature/new-feature
```

---

## 👨‍💻 Author

**Developer:** didar-code  
**GitHub:** [https://github.com/didar-code](https://github.com/didar-code)

---

## 📄 License

This project is licensed under the **MIT License**.  
You can modify and use it for personal or commercial projects.

---

## ⭐ Support

If this project helps you, please give it a ⭐ on GitHub.
