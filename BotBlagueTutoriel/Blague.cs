using System.Text.Json.Serialization;

namespace Tutorial.Blague;

public class Joke
{
    [JsonPropertyName("question")]
    public string Question { get; set; }

    [JsonPropertyName("answer")]
    public string Answer { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class Root
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("response")]
    public string Response { get; set; }

    [JsonPropertyName("error")]
    public bool Error { get; set; }

    [JsonPropertyName("joke")]
    public Joke Joke { get; set; }
}

