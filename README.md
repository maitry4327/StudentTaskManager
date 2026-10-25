# Student Task & Assignment Management System

A web-based application developed using **ASP.NET Core MVC (.NET 8)** and **MySQL** to help students organize assignments, manage deadlines, and track academic progress.

## Project Overview

The Student Task & Assignment Management System provides a centralized platform for managing academic assignments. Students can create, view, update, delete, search, and filter assignments through a user-friendly interface.

The application also includes a dashboard to monitor assignment statistics and upcoming deadlines.

## Key Features

- **Dashboard:** Displays total, pending, completed, and overdue assignments.
- **Create Assignment:** Add assignments with title, subject, description, due date, and status.
- **View Assignments:** Display all saved assignments.
- **Edit Assignment:** Update assignment information.
- **Delete Assignment:** Remove assignments with a confirmation step.
- **Search:** Find assignments by title or subject.
- **Status Filter:** Filter assignments by Pending, In Progress, or Completed.
- **Form Validation:** Validate required fields before saving.
- **Responsive Interface:** Modern design for different screen sizes.

## Technology Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC (.NET 8) | Web application framework |
| C# | Backend programming |
| Razor Views | Dynamic user interface |
| HTML, CSS | Frontend design |
| Entity Framework Core | Database operations |
| Pomelo MySQL Provider | MySQL integration |
| MySQL | Database |
| Visual Studio 2022 | Development environment |
| Git & GitHub | Version control |

## Project Architecture

The application follows the Model-View-Controller (MVC) architecture.

- **Model:** Represents assignment data and validation rules.
- **View:** Displays application pages using Razor.
- **Controller:** Processes requests and handles application logic.
- **Database:** Stores assignment information using MySQL.

## Main Modules

### 1. Dashboard Module
Displays assignment statistics and recent assignments.

### 2. Assignment Management Module
Supports Create, Read, Update, and Delete (CRUD) operations.

### 3. Search and Filter Module
Allows students to find assignments and filter them according to their status.

### 4. Database Module
Uses Entity Framework Core with MySQL for data storage and retrieval.

## Database Structure

**Database Name:** `student_task_manager`

**Main Table:** `Assignments`

Important fields:

- Id
- Title
- Subject
- Description
- DueDate
- Status
- CreatedAt

## How to Run the Project

1. Install Visual Studio 2022 with ASP.NET and web development support.
2. Install .NET 8 SDK.
3. Install XAMPP and start MySQL.
4. Create a MySQL database named `student_task_manager`.
5. Clone or download this repository.
6. Create an `appsettings.json` file in the project directory.
7. Configure the `DefaultConnection` connection string for your local MySQL database.
8. Restore NuGet packages.
9. Apply the Entity Framework Core migrations using `Update-Database` in the Package Manager Console.
10. Run the project using Visual Studio.

**Note:** Local database credentials and configuration files are excluded from the repository.

## Project Screenshots

Screenshots of the Home, Dashboard, and Assignment Management pages will be added.

## Future Enhancements

- Student registration and login
- Email reminders for assignment deadlines
- Assignment priority levels
- File attachments
- Advanced reports and analytics

## Developer

**Thakor Maitry Jashvantsinh**  
B.Tech — Information Technology  
Uka Tarsadia University

## Project Purpose

Developed as an academic mini-project to demonstrate ASP.NET Core MVC, C#, Entity Framework Core, MySQL integration, CRUD operations, and responsive web application development.
