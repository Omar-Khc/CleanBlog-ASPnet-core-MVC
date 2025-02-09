# CleanBlog - ASP.NET Core MVC

## Overview

CleanBlog is a simple and clean blogging platform built using **ASP.NET Core MVC**. It provides a well-structured and modular design, allowing users to create, manage, and display blog posts efficiently.

## Features

- 📝 **Create, Edit, and Delete Blog Posts**
- 🖼️ **Upload and Manage Images**
- 🔍 **Search and Filter Posts**
- 👤 **User Authentication & Authorization** (Login/Register)
- 🎨 **Responsive UI Design**
- 📜 **Rich Text Editor for Blog Content**
- 📊 **Admin Dashboard for Blog Management**

## Technologies Used

- **ASP.NET Core MVC** - Backend framework
- **Entity Framework Core** - Database management
- **SQL Server** - Relational database
- **Bootstrap** - Frontend styling
- **CKEditor** - Rich text editor for posts
- **Identity Framework** - User authentication & roles

## Installation
### 1️⃣ Clone the Repository

```sh
git clone https://github.com/Omar-Khc/CleanBlog-ASPnet-core-MVC.git
cd CleanBlog-ASPnet-core-MVC
```

### 2️⃣ Install Required Packages

Before running the project, you need to install the required NuGet packages to enable database functionality. Ensure the following packages are installed:

- **Microsoft.AspNetCore.Identity.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.Design**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Tools**
- **SixLabors.ImageSharp**

These packages can be installed via **NuGet Package Manager** in Visual Studio or using the command line.

### 3️⃣ Configure the Database

1. Update **appsettings.json** with your SQL Server connection string:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=CleanBlogDB;Trusted_Connection=True;"
}
```

## Usage

- **Admin Panel**: Manage users, blog posts, and categories.
- **Public Blog**: Users can read and comment on blog posts.
- **Authentication**: Secure login and registration system.

## Contribution

Contributions are welcome! Feel free to submit a pull request or open an issue.

## Contact

📧 **Omar Khc** - [GitHub Profile](https://github.com/Omar-Khc)

---

🚀 **Happy Coding!**

