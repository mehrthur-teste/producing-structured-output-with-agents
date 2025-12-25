# producing-structured-output-with-agents
This tutorial step shows you how to produce structured output with an agent, where the agent is built on the Azure OpenAI Chat Completion service

Install
chmod +x setup_sqlite.sh
./setup_sqlite.sh

First you need to install these Nugets Packages:
dotnet new web -n AzureOpenAIAgentApi 
dotnet add package Azure.AI.OpenAI --prerelease
dotnet add package Azure.Identity
dotnet add package Microsoft.Agents.AI.OpenAI --prerelease
dotnet add package Dapper
dotnet add package Npgsql

DataConnections?
"DefaultConnection": "Host=localhost;Port=5432;Database=yourdatabase;Username=postgres;Password=yourpassword;"
"DefaultConnection": "Data Source=database/app.db;"

Then use :
dotnet build
dotnet clean
dotnet run
