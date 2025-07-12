# 🎬 Kyrenia - OMDb Movie Search Application

Kyrenia is a web application built for a technical task as part of a hiring process at Jean Edwards. It provides a simple interface to search for movies using the [OMDb API](http://www.omdbapi.com), view search results, and see detailed movie information.

---

## 📋 Technical Task Description

> Using [http://www.omdbapi.com](http://www.omdbapi.com) service API, create a web application with the following functionality:
>
> - Movie search by title  
> - Saving 5 latest search queries  
> - Showing search results  
> - Show extended movie information when a particular movie is selected (poster, description, IMDb score, etc.)  
> - Use .NET Core as a backend and Blazor as a frontend framework  
> - Include unit tests

---

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

---

## 🔐 API Key Setup

This app requires an OMDb API key, which is stored securely using **.NET User Secrets** in development.

> 💡 **Do NOT commit your API key to source control.**

### Step-by-Step

1. Make sure you have the .NET SDK installed (8.0 or higher).

2. From the `Kyrenia.Api` project directory, run:

```bash
dotnet user-secrets set "OmdbApi:ApiKey" "your_api_key_here"
