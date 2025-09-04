# Kyrenia

Kyrenia is a full-stack web application for discovering and exploring media such as movies and TV series.
It began as a technical exercise focused on movie search alone, but has since evolved into a personal project where I experiment with clean architecture, different frameworks across both frontend and backend, and feature extensions.

## Table Of Contents

ToDo

## Technical Exercise Description

Using [OMDb API](http://www.omdbapi.com) web service, create a web application with the following functionality:
- Movie search by title
- Saving 5 latest search queries
- Showing search results
- Show extended movie information when a particular movie is selected (poster, description, IMDb score, etc.)
- Use .NET as a backend and Blazor as a frontend framework
- Include unit tests

## Tech Stack

- Frontend: Blazor Server + Mud Blazor
- Backend: ASP.NET Core Web API MVC
- Database: In-memory
- Architecture: Modular monolith with Clean Architecture principles

## Roadmap

- Re-make API into RESTful Minimal API
- Transform solution according to Clean Architecture
- Move database into docker container
- To be added

## Omdb API Key Setup

This app requires an OMDb API key, which is stored securely using **.NET User Secrets** in development.

> ❌ **Do NOT commit your API key to source control.**

### Setup Steps

1. Make sure you have the .NET SDK installed (8.0 or higher).

2. From the `Kyrenia.Api` project directory, run:

```bash
dotnet user-secrets set "TitleProvider:ApiKey" "your_api_key"
```

## Following will be updated and expanded as time comes

## 🏗️ Architecture

Kyrenia follows a **modular monolithic** architecture using two separate projects:

### 🔹 Kyrenia.Api (`ASP.NET Core Web API`)
- Acts as the backend
- Responsible for:
  - Communicating with OMDb API
  - Managing latest search queries (stored in-memory for now)
  - Returning DTOs to the frontend

### 🔹 Kyrenia.Client (`Blazor Web App`, interactive server mode)
- Acts as the frontend
- Responsible for:
  - Displaying search input and results
  - Calling the API via HTTP
  - Showing movie details
