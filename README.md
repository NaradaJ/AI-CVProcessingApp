# AI CV Processing App

## Overview
This project automates CV summarization, relevance assessment, and tech stack highlighting.

## Setup Instructions
1. Clone the repository.
2. Navigate to the `src/AIProcessingService` directory.
3. Run `dotnet build` to restore dependencies.
4. Configure your `appsettings.json` with the correct database connection.
5. Run the service using `dotnet run`.

## Usage
- Use the `/api/cv/upload` endpoint to upload CVs.
- Use the `/api/cv/summarize` endpoint to summarize a CV.
- Use the `/api/cv/relevance` endpoint to check CV relevance.
