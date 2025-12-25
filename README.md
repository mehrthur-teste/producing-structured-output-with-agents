# Producing Structured Output With Agents
This tutorial shows you how to produce structured output with an agent, using the Azure OpenAI Chat Completion service.

## API Endpoints

| Endpoint URL | Method | Purpose | Payload (JSON) |
|--------------|--------|---------|----------------|
| `/health-check` | GET | Check if the API is running | None |
| `/agent-run` | POST | Run an agent to provide structured information about a person | `{ "Prompt1": "...", "Prompt2": "...", "NameAssistant": "...", "Description": "...", "schemaName":"...", "schemaDescription":"...", "Intructions":"...", "Go": "..." }` |
| `/sql-agent-run` | POST | Run an SQL assistant to generate PostgreSQL queries | `{ "Prompt1": "...", "NameAssistant": "...", "schemaName":"...", "schemaDescription":"...", "Description": "...", "Intructions":"...", "Go": "..." }` |

### Request Examples

**Health Check:**
```bash
curl -X GET http://localhost:5099/health-check
```

**Agent Run:**
```bash
curl -X POST http://localhost:5099/agent-run \
-H "Content-Type: application/json" \
-d '{
    "Prompt1": "Cristiano Ronaldo",
    "Prompt2": "Software Engineer",
    "NameAssistant": "HelpfulAssistant",
    "Description" : "An AI assistant that provides structured information about people.",
    "schemaName": "PersonInfo",
    "schemaDescription": "Information about a person including their name, age, and occupation",
    "Intructions" : "You are a helpful assistant that provides structured information about people.",
    "Go" : "Please provide information about {chatConfig.Prompt1} see on the internet, is he {chatConfig.Prompt2} or not?"
}'
```

**Employees:**
```bash
curl -X POST http://localhost:5099/sql-agent-run \
-H "Content-Type: application/json" \
-d '{
    "Prompt1": "Table is employee built as Name VARCHAR(100), Age INT, Occupation VARCHAR(100)",
    "NameAssistant": "SQLHelpfulAssistant",
    "Description" : "An AI assistant that query to inject sql postgres client.",
    "schemaName": "PersonInfo",
    "schemaDescription": "Information about a person including their name, age, and occupation becoming data base",
    "Intructions" : "You are a helpful SQL assistant that provides structured information about people.",
    "Go" : "Please provide a quickly and sample query -  select all employe who is not software enginner remember that - {chatConfig.Prompt1} ?"
}'
```

## Response Examples
**Health Check:**
```json
{
    "status": "Hello World"
}
```
**Agent Run:**
```json
{
    "name": "Cristiano Ronaldo",
    "age": 39,
    "occupation": "Software Engineer"
}
```
**SQL Agent Run:**
```json
[
    {
        "name": "Jane Smith",
        "age": 28,
        "occupation": "Data Analyst"
    },
    {
        "name": "Alice Johnson",
        "age": 35,
        "occupation": "Product Manager"
    }
]
```
## Prerequisites
- An Azure OpenAI resource with access to the Chat Completion service.
- .NET 10.0 SDK or later installed on your machine.
## Setup Instructions
1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Open the `appsettings.json` file and configure your Azure OpenAI settings:
```json
 "AzureOpenAI": {
    "Endpoint": "",
    "ApiKey": "",
    "DeploymentName": "gpt-4.1-mini"
  },
  ```
4. Restore the project dependencies by running:
   ```bash
   dotnet restore
   ```
5. Build the project using:
```bash
dotnet build
```
6. Run the application with:
```bash
dotnet run
```
7. The API will be accessible at `http://localhost:5099`.

## Review of the input models
The input models for the `/agent-run` and `/sql-agent-run` endpoints are defined as follows:
```csharp
public class AgentRequest
{
    public string Prompt1 { get; set; }
    public string Prompt2 { get; set; }
    public string NameAssistant { get; set; }
    public string Description { get; set; }
    public string schemaName { get; set; }
    public string schemaDescription { get; set; }
    public string Intructions { get; set; }
    public string Go { get; set; }
}
public class SqlAgentRequest
{
    public string Prompt1 { get; set; }
    public string NameAssistant { get; set; }
    public string Description { get; set; }
    public string schemaName { get; set; }
    public string schemaDescription { get; set; }
    public string Intructions { get; set; }
    public string Go { get; set; }
}
```
These models capture the necessary information to configure and run the agents for structured output generation.

## Describing each one fields
- `Prompt1`: The primary input prompt for the agent.
- `Prompt2`: An additional input prompt for the agent (used only in `/agent-run`).
- `NameAssistant`: The name of the assistant to be used.
- `Description`: A brief description of the assistant's purpose.
- `schemaName`: The name of the schema for the structured output.
- `schemaDescription`: A description of the schema for the structured output.
- `Intructions`: Instructions for the agent on how to process the input prompts.
- `Go`: The main instruction or query for the agent to execute.

## Note for Prompt's fields
We can use the Prompt1 field in to Prompt2 as dynamic variable
## Note for schemaName fields
schemaName area the models wich we want that the agent kowns to processing the data.

