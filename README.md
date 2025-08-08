Task Management Application ===========================
■ Overview
-----------
This is a simple Task Management System built using ASP.NET Core MVC and SQL Serv er. It allows users to: - Create, Read, Update, Delete tasks
- Search tasks by title - Maintain task metadata like status, due date, created/updated by etc.
■ Technologies Used
---------------------
| Layer      | Tech                       |
|------------|----------------------------|
| Backend    | ASP.NET Core MVC           |
| Frontend   | Razor Pages + Bootstrap    | | Database   | SQL Server (Code First)    |
| ORM        | Entity Framework Core      | | Versioning | Git + GitHub               |


■ ER Diagram
--------------
Task
-----
TaskId (PK)
TaskTitle
TaskDescription
TaskDueDate
TaskStatus
TaskRemarks
CreatedOn
LastUpdatedOn
CreatedById
CreatedByName
UpdatedById
UpdatedByName

■■ Data Dictionary
-------------------
| Column Name      | Type        | Description                       |
|------------------|-------------|------------------------------------|
| TaskId           | int         | Primary Key                        | | TaskTitle        | string      | Title of the task                  |
| TaskDescription  | string      | Detailed description               |
| TaskDueDate      | DateTime    | Deadline of the task               |
| TaskStatus       | string      | Pending / Completed / InProgress   |
| TaskRemarks      | string      | Any additional notes               | | CreatedOn        | DateTime    | Task creation timestamp            |
| LastUpdatedOn    | DateTime    | Last modification timestamp        |
| CreatedById      | string      | User who created the task          |
| CreatedByName    | string      | Name of creator                    |
| UpdatedById      | string      | User who last updated the task     | | UpdatedByName    | string      | Name of last updater               |

■■ Features Implemented
------------------------
-	■ Create Task
-	■ Read Task list
-	■ Update Task
-	■ Delete Task
-	■ Search by Task Title
-	■ Indexing on frequently filtered columns

■■ Architecture
---------------MVC Pattern:
-	Model: TaskModel, ApplicationUser
-	View: Razor Pages using Bootstrap- Controller: TaskController handles all CRUD operations
■ Setup Instructions
--------------------1. Clone the repo:    git clone https://github.com/yourusername/TaskManagementApp.git 2. Update your SQL connection string in appsettings.json
3.	Apply migrations:
   dotnet ef database update
4.	Run the application:    dotnet run
■ Code First Approach
-----------------------
Code First approach has been used because it allows better control over model cla sses and easier versioning of database using EF Core migrations.
■ Author
----------
Your Name
Email: alkasingh1404@email.com
GitHub: https://github.com/Alka-singh1404
