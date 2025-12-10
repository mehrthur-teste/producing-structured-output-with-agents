# producing-structured-output-with-agents
This tutorial step shows you how to produce structured output with an agent, where the agent is built on the Azure OpenAI Chat Completion service

First you need to install these Nugets Packages:
dotnet new web -n AzureOpenAIAgentApi 
dotnet add package Azure.AI.OpenAI --prerelease
dotnet add package Azure.Identity
dotnet add package Microsoft.Agents.AI.OpenAI --prerelease

Then use :
dotnet run
