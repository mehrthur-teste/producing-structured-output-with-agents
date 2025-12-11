using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.AI;


public class PersonInfo
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Occupation { get; set; }
    public string? AIresponse { get; set; }
}

// Top-level statement
// JsonElement schema = AIJsonUtilities.CreateJsonSchema(typeof(PersonInfo));

