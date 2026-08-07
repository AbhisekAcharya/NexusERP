# NexusERP

> A Production-Grade Multi-Tenant ERP System built using **ASP.NET Core (.NET 10)**, **Angular 20**, **Clean Architecture**, **CQRS**, **MediatR**, **Entity Framework Core**, and **SQL Server**.

---

# Overview

NexusERP is a modern Enterprise Resource Planning (ERP) system designed to demonstrate enterprise-level software architecture, scalable software development practices, and modern UI/UX principles.

The project is being developed module-by-module following **Clean Architecture**, **Domain-Driven Design (DDD)**, **CQRS**, **SOLID Principles**, and modern enterprise frontend architecture using Angular.

The objective is to build a complete production-grade ERP platform while showcasing enterprise software engineering best practices.

---

# Technology Stack

## Backend

- ASP.NET Core (.NET 10)
- C#
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- Swagger / OpenAPI

## Frontend

- Angular 20
- TypeScript
- HTML5
- CSS3
- Angular Router
- Angular Standalone Components
- Reactive Forms
- RxJS
- Angular HTTP Client

---

# Architecture

## Backend Architecture

- Clean Architecture
- Domain Driven Design (DDD)
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Dependency Injection
- Result Pattern
- Vertical Slice Architecture
- SOLID Principles

## Frontend Architecture

- Feature-Based Folder Structure
- Standalone Components
- Shared Components
- Core Module
- Lazy Loading Ready
- Reusable UI Components
- Responsive Design

---

# Solution Structure

```
NexusERP

backend/
│
├── NexusERP.API
├── NexusERP.Application
├── NexusERP.Domain
├── NexusERP.Persistence
├── NexusERP.Infrastructure
└── NexusERP.SharedKernel

frontend/
│
├── src
│
├── app
│   ├── core
│   ├── shared
│   ├── layouts
│   ├── features
│   │     ├── auth
│   │     ├── dashboard
│   │     ├── employee
│   │     ├── department
│   │     └── ...
│   │
│   ├── services
│   ├── models
│   ├── guards
│   └── interceptors
│
├── assets
└── environments
```

---

# Project Responsibilities

| Project | Responsibility |
|----------|---------------|
| NexusERP.API | REST API Endpoints |
| NexusERP.Application | CQRS Commands, Queries, Validation, Business Logic |
| NexusERP.Domain | Domain Entities & Business Rules |
| NexusERP.Persistence | Entity Framework Core, Repository Layer |
| NexusERP.Infrastructure | External Services & Integrations |
| NexusERP.SharedKernel | Result Pattern, Common Utilities |
| Angular Frontend | Enterprise User Interface |

---

# System Architecture

```
Angular Frontend
        │
        ▼
REST API
        │
        ▼
ASP.NET Core
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

# Request Flow

```
HTTP Request
      │
      ▼
Angular UI
      │
      ▼
ASP.NET Core API
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
SQL Server
```

---

# CQRS Implementation

Commands are responsible for modifying data.

Examples

- CreateEmployeeCommand
- UpdateEmployeeCommand

Queries are responsible for retrieving data.

Examples

- GetEmployeeQuery
- GetAllEmployeesQuery

This separation provides a scalable, maintainable, and testable architecture.

---

# Completed Backend Features

## Employee Module

### Create Employee

- Create Employee API
- FluentValidation
- Duplicate Employee Code Validation
- Duplicate Email Validation
- CQRS Command
- MediatR Handler
- Result Pattern

---

### Get Employee

- Get Employee By Id
- Repository Pattern
- DTO Mapping
- CQRS Query

---

### Get All Employees

- Retrieve All Employees
- AsNoTracking()
- DTO Mapping
- CQRS Query

---

### Update Employee

- Update Employee API
- Domain Update Method
- Duplicate Validation
- Automatic ModifiedOnUtc Update

---

# Database

Implemented

- SQL Server
- Entity Framework Core
- Code First Approach
- EF Core Migrations
- Unique EmployeeCode
- Unique Email
- Automatic Timestamps

---

# Validation

Implemented using FluentValidation.

Current validations

- Required Fields
- Email Format
- Maximum Length
- Duplicate Employee Code
- Duplicate Email

---

# Shared Components

- Result Pattern
- Generic Result
- Error Model
- Dependency Injection
- Validation Pipeline
- Repository Pattern

---

# Completed Frontend Features

## Authentication Module

Completed

- Modern Enterprise Login Screen
- Responsive Login Layout
- Enterprise Branding Panel
- Gradient Typography
- Animated Wave Footer
- Language Selector
- Login Card
- Email Input
- Password Input
- Password Visibility Icon
- Remember Me Checkbox
- Forgot Password Link
- Gradient Sign In Button
- Google Login Button
- Microsoft Login Button
- Contact Administrator Section
- Enterprise Footer

---

## UI Features

Completed

- Responsive Design
- Modern Enterprise UI
- Glassmorphism Inspired Login Card
- Reusable Form Controls
- Gradient Buttons
- Custom SVG Icons
- Enterprise Branding
- Modern Typography
- Professional Color Palette

---

# Current APIs

| Method | Endpoint | Status |
|---------|----------|--------|
| POST | /api/employees | ✅ Completed |
| GET | /api/employees | ✅ Completed |
| GET | /api/employees/{id} | ✅ Completed |
| PUT | /api/employees/{id} | ✅ Completed |

---

# Development Status

## Backend

```
✔ Clean Architecture

✔ CQRS

✔ MediatR

✔ Repository Pattern

✔ Fluent Validation

✔ Result Pattern

✔ Employee Module

✔ SQL Server

✔ Entity Framework Core
```

---

## Frontend

```
✔ Angular Project Setup

✔ Enterprise Login Screen

✔ Responsive Layout

✔ Authentication UI

✔ Gradient Branding

✔ Wave Background

✔ Language Selector

✔ Google Login Button

✔ Microsoft Login Button

✔ Contact Administrator

✔ Enterprise Footer
```

---

# Upcoming Features

## Authentication

- JWT Authentication
- Refresh Tokens
- ASP.NET Core Identity
- Role Based Authorization
- Permission Based Authorization
- Secure Login
- Remember Me Functionality

---

## Dashboard

- Dashboard Layout
- Sidebar Navigation
- Top Navigation
- Dashboard Widgets
- Charts
- Analytics
- Notifications

---

## Employee Module

- Employee Management UI
- Create Employee Screen
- Edit Employee
- Delete Employee
- Search
- Pagination
- Sorting
- Filtering
- Export to Excel
- Export to PDF

---

## Master Modules

- Department Management
- Designation Management
- Company Management
- Branch Management
- Role Management
- User Management

---

## Advanced Backend Features

- Global Exception Middleware
- Serilog Logging
- Redis Caching
- Dapper Read Models
- Background Jobs (Hangfire)
- Audit Logging
- File Upload
- Email Service
- Unit Testing
- Integration Testing
- API Versioning

---

## Advanced Frontend Features

- Dashboard Charts
- Dynamic Sidebar
- Breadcrumb Navigation
- Theme Support (Light/Dark)
- Localization (i18n)
- Reusable Component Library
- Skeleton Loaders
- Toast Notifications
- Data Tables
- Form Validation
- Route Guards

---

# Future Vision

The long-term goal is to evolve NexusERP into a complete enterprise platform supporting

- Multi-Tenant Architecture
- Human Resource Management (HRMS)
- Payroll
- Inventory Management
- Sales & Purchase
- Finance
- CRM
- Reporting
- Business Intelligence
- Mobile Applications (.NET MAUI)
- Azure Cloud Deployment

---

# UI Preview

Current Screens Completed

- Enterprise Login Screen
- Authentication UI

Upcoming

- Dashboard
- Employee Management
- Master Modules
- Reports
- Settings

---

# Coding Standards

- SOLID Principles
- Clean Architecture
- Domain Driven Design
- CQRS
- Repository Pattern
- Dependency Injection
- Fluent Validation
- MediatR
- Async/Await
- Nullable Reference Types
- REST API Best Practices

---

# Development Progress

```
Backend Progress
████████████████████░░░░ 80%

Frontend Progress
██████████░░░░░░░░░░░░░░ 40%

Overall ERP Progress
███████████░░░░░░░░░░░░░ 50%
```

---

# Author

## Abhisek Acharya

**Senior Software Developer**

Building a production-grade ERP platform using modern .NET technologies, Angular, Clean Architecture, CQRS, and enterprise software engineering practices.