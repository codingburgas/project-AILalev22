# FitnessTracker - Workouts & Calories Tracker

An ASP.NET Core MVC web application for tracking workouts, exercises, and calorie burn.  
The system allows users to log workouts, assign exercises, and visualize their activity through a statistics dashboard.

---

## Features

### User Features
- User registration and authentication (ASP.NET Core Identity)
- Create, edit, and delete workouts
- Add exercises to workouts (many-to-many relationship)
- Track sets, reps, duration, and intensity
- View workout details with calculated calories burned

### Statistics Dashboard
- Daily activity tracking
- Weekly and monthly summaries
- Total calories burned calculation (using LINQ aggregation)
- Interactive charts using Chart.js

### Exercise Management
- Create and manage exercises (Admin/User access based on roles)
- Define exercise type and calories per minute

---

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core (Code First)
- ASP.NET Core Identity
- SQLite (development database)
- LINQ for data aggregation
- Bootstrap for UI styling
- Chart.js for data visualization

---

## Architecture

The project follows a layered architecture:

- **Presentation Layer (WebHost)**
  - MVC Controllers
  - Razor Views

- **Application Layer**
  - DTOs
  - Service Interfaces
  - Services implementation

- **Infrastructure Layer**
  - Database context (EF Core)

- **Domain Layer**
  - Entities and core models

---

## Database Design

Main relationships:

- User → Workouts (One-to-Many)
- Workout → Exercises (Many-to-Many via WorkoutExercise)
- Exercises store calorie burn rates used for calculations

---

## Role-Based Access

The application includes two roles:

- **User**
  - Can manage personal workouts and view statistics

- **Admin**
  - Can manage exercises and system-level data

---

## Setup Instructions

1. Clone the repository
```bash
git clone https://github.com/codingburgas/project-AILalev22.git
```

2. Go into the project folder
```bash
cd project-AILalev22
```

3. Restore dependencies (NuGet packages)
```bash
dotnet restore
```

4. Build the solution (checks for compile errors)
```bash
dotnet build
```

5. Apply database migrations
```bash
dotnet ef database update --project FitnessTracker.Infrastructure --startup-project FitnessTracker.WebHost
```
6. Initialize User Secrets
```bash
dotnet user-secrets init --project FitnessTracker.WebHost
```

7. Configure Admin Credentials (User Secrets)

```bash
dotnet user-secrets set "Other:adminEmail" "your-admin-email" --project FitnessTracker.WebHost
```
```bash
dotnet user-secrets set "Other:adminPassword" "your-secure-password" --project FitnessTracker.WebHost
```

8. Run the application
```bash
dotnet run --project FitnessTracker.WebHost
```
