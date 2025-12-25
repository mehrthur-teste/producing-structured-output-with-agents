# producing-structured-output-with-agents
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

