# producing-structured-output-with-agents
This tutorial step shows you how to produce structured output with an agent, where the agent is built on the Azure OpenAI Chat Completion service
## API Endpoints

| Endpoint URL | Método | Objetivo | Payload (JSON) |
|--------------|--------|----------|----------------|
| `http://localhost:5099/health-check` | GET | Verificar se a API está funcionando corretamente | Nenhum |
| `http://localhost:5099/agent-run` | POST | Executar um agente que fornece informações estruturadas sobre uma pessoa | ```json { "Prompt1": "Cristiano Ronaldo", "Prompt2": "Software Engineer", "NameAssistant": "HelpfulAssistant", "Description": "An AI assistant that provides structured information about people.", "schemaName": "PersonInfo", "schemaDescription": "Information about a person including their name, age, and occupation", "Intructions": "You are a helpful assistant that provides structured information about people.", "Go": "Please provide information about {chatConfig.Prompt1} see on the internet, is he {chatConfig.Prompt2} or not?" } ``` |

### Exemplos de Requisição

**Health Check:**
```bash
curl -X GET http://localhost:5099/health-check



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
