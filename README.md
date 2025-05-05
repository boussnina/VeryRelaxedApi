# VeryRelaxedApi 😌

This is a small project I built to practice working with a classic 3-layer architecture in C#. The name is a fun reference to RESTful APIs — this one’s just a bit more... relaxed.

## What it does

It’s a basic API for managing football-related data — coaches, players, referees — with functionality like:

- Adding and removing coaches
- Searching across fields
- Getting lists of entries

## Tech stack

- ASP.NET Core (C#)
- Entity Framework Core
- React (frontend, not included here)
- MSSQL

## Structure

The project follows a simple separation of concerns:
- Controllers (handle HTTP)
- Business logic (processes data)
- Repository (talks to the database)

## Why I made it

Mainly to show how I work with:
- Entity Framework Core
- Dependency injection
- Async database operations
- Structuring a C# backend clearly

It's not a full production app, just a clean example.

## How to run it

- Clone the repo
- Make sure you have .NET and SQL Server (or localdb) set up
- Run `dotnet ef database update` to create the DB
- Launch with `dotnet run`

---

Thanks for checking it out!
