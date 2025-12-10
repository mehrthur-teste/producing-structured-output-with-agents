using Azure;
using Azure.AI.OpenAI;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using System.Text.Json;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Read configuration values for Azure OpenAI
string endpoint = builder.Configuration["AzureOpenAI:Endpoint"] ?? throw new InvalidOperationException("AzureOpenAI:Endpoint configuration is missing");
string apiKey = builder.Configuration["AzureOpenAI:ApiKey"] ?? throw new InvalidOperationException("AzureOpenAI:ApiKey configuration is missing");
string deploymentName = builder.Configuration["AzureOpenAI:DeploymentName"] ?? throw new InvalidOperationException("AzureOpenAI:DeploymentName configuration is missing");

var app = builder.Build();


app.MapGet("/", async (HttpContext context) => {
    JsonElement schema = AIJsonUtilities.CreateJsonSchema(typeof(PersonInfo));

    ChatOptions chatOptions = new()
    {
        Instructions = "You are a helpful assistant that provides structured information about people.",
        ResponseFormat = ChatResponseFormat.ForJsonSchema(
            schema: schema,
            schemaName: "PersonInfo",
            schemaDescription: "Information about a person including their name, age, and occupation")
    };


    AIAgent agent = new AzureOpenAIClient(
            new Uri(endpoint),
            new AzureKeyCredential(apiKey))
                .GetChatClient(deploymentName)
                .CreateAIAgent(new ChatClientAgentOptions()
                {
                    Name = "HelpfulAssistant",
                    Description = "An AI assistant that provides structured information about people.",
                    ChatOptions = chatOptions
                });
    
    var response = await agent.RunAsync("Please provide information about John Smith, who is a 35-year-old software engineer.");
    var personInfo = response.Deserialize<PersonInfo>(JsonSerializerOptions.Web);
    Console.WriteLine($"Name: {personInfo.Name}, Age: {personInfo.Age}, Occupation: {personInfo.Occupation}");
    return Results.Ok(personInfo);
    });

app.Run();
