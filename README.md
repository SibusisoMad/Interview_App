InterviewApp is a .NET Core console application dynamically greeting users based on the time of the day in different languages via configuration settings.

<img width="595" height="81" alt="image" src="https://github.com/user-attachments/assets/de8dfdce-13ab-4a9c-8b6f-c0622950c549" />


**Project setup:**
run gitbash commands:
git clone
Cd InterviewApp
Restore Dependencies: dotnet restore
Build Project: dotnet build
Run the Application: dotnet run

Altenative: after clonining  navigate to project directory solution "InterviewApp.sln" open with visual studio and build solution and run the InterviewApp.

**Usage Notes**
To add a new language, update appsettings.json under Messages and TimeMessages. No code changes required.
All greetings are handled dynamically using MediatR and services.
If configuration is invalid, errors are logged and the app will exits gracefully.

**Overview**
The application:

Reads greeting messages and languages from appsettings.json.
Generates time-based greetings (Morning, Afternoon, Evening) via nested dictionary time greeting.
Supports multiple languages (English, Afrikaans, Zulu) dynamically.
Uses MediatR commands and queries for decoupled logic.
Validates configuration to prevent runtime errors.
