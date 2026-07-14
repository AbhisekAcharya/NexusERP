# NexusERP

> A Production-Grade Multi-Tenant ERP System built using ASP.NET Core, .NET 10, Clean Architecture, CQRS, MediatR, Entity Framework Core, and SQL Server.

---

## Overview

NexusERP is a modern Enterprise Resource Planning (ERP) system designed to demonstrate enterprise-level software architecture and development practices.

The goal of this project is not only to build an ERP application but also to showcase scalable, maintainable, and production-ready backend architecture following modern .NET development standards.

This project is being developed module-by-module while following Domain-Driven Design principles, Clean Architecture, CQRS, and SOLID principles.

---

## Technology Stack

### Backend

- ASP.NET Core (.NET 10)
- C#
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- Swagger / OpenAPI

### Architecture

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Dependency Injection
- Result Pattern
- Domain Driven Design (DDD)
- Vertical Slice Feature Organization

---

## Solution Structure

```
src
│
├── NexusERP.API
│
├── NexusERP.Application
│
├── NexusERP.Domain
│
├── NexusERP.Persistence
│
├── NexusERP.Infrastructure
│
└── NexusERP.SharedKernel
```

### Project Responsibilities

| Project | Responsibility |
|----------|----------------|
| NexusERP.API | REST API Endpoints |
| NexusERP.Application | CQRS Commands, Queries, Validation, Business Logic |
| NexusERP.Domain | Entities, Enums, Domain Logic |
| NexusERP.Persistence | EF Core, DbContext, Repository Implementation |
| NexusERP.Infrastructure | External Integrations (Future) |
| NexusERP.SharedKernel | Shared Result Pattern, Errors, Common Classes |

---

# Architecture

The project follows **Clean Architecture**.

```
Presentation (API)
        │
        ▼
Application
        │
        ▼
Domain
        ▲
        │
Persistence
```

### Request Flow

```
HTTP Request
      │
      ▼
Controller
      │
      ▼
MediatR
      │
      ▼
Validation Pipeline
      │
      ▼
Command / Query Handler
      │
      ▼
Repository
      │
      ▼
Entity Framework Core
      │
      ▼
SQL Server
```

---

# CQRS Implementation

Commands are responsible for modifying data.

Examples:

- CreateEmployeeCommand
- UpdateEmployeeCommand

Queries are responsible for reading data.

Examples:

- GetEmployeeQuery
- GetAllEmployeesQuery

This separation keeps the codebase scalable and easy to maintain.

---

# Completed Features

## Employee Module

### Create Employee

- Create Employee API
- Fluent Validation
- Duplicate Employee Code Validation
- Duplicate Email Validation
- Result Pattern
- CQRS Command
- MediatR Handler

---

### Get Employee

- Get Employee By Id API
- CQRS Query
- Employee DTO
- Repository Pattern

---

### Get All Employees

- Retrieve all employees
- CQRS Query
- DTO Mapping
- Read-only queries using AsNoTracking()

---

### Update Employee

- Update Employee API
- Duplicate Employee Code Validation
- Duplicate Email Validation
- Domain Update Method
- Automatic ModifiedOnUtc update

---

## Database

Implemented

- SQL Server
- Entity Framework Core
- Code First
- EF Core Migrations
- Unique Index on EmployeeCode
- Unique Index on Email

---

## Validation

Implemented using FluentValidation.

Current validations include:

- Required fields
- Email format validation
- Maximum length validation
- Duplicate Employee Code validation
- Duplicate Email validation

---

## Shared Components

- Result Pattern
- Generic Result<T>
- Error Model
- Dependency Injection
- Validation Pipeline Behavior

---

# Current APIs

| Method | Endpoint | Status |
|----------|-------------------------|--------|
| POST | /api/employees | Completed |
| GET | /api/employees | Completed |
| GET | /api/employees/{id} | Completed |
| PUT | /api/employees/{id} | Completed |

---

# Upcoming Features

Employee Module

- Soft Delete
- Restore Employee
- Pagination
- Searching
- Sorting
- Filtering

Master Modules

- Department Management
- Designation Management
- Company Management
- Branch Management
- Role Management

Authentication

- JWT Authentication
- Refresh Tokens
- Role Based Authorization
- Permission Based Authorization

Advanced Features

- Dapper for Read Queries
- Redis Caching
- Serilog Logging
- Global Exception Middleware
- API Versioning
- Background Jobs (Hangfire)
- Audit Logging
- File Uploads
- Email Service
- Unit Testing
- Integration Testing

---

# Future Vision

The long-term goal of NexusERP is to evolve into a complete production-grade ERP platform supporting:

- Multi-Tenant Architecture
- Human Resource Management (HRMS)
- Payroll
- Inventory Management
- Sales & Purchase
- Finance
- Customer Relationship Management (CRM)
- Reporting & Dashboards
- Mobile Applications (.NET MAUI)
- Cloud Deployment (Azure)

---

# Development Status

Current Progress

```
Employee Module

✔ Create Employee

✔ Get Employee

✔ Get All Employees

✔ Update Employee

⬜ Soft Delete

⬜ Pagination

⬜ Search

⬜ Sorting

⬜ Filtering
```

---

# Author

**Abhisek Acharya**

Senior Software Developer

Building a production-grade ERP system using modern .NET technologies and enterprise architecture principles.

---