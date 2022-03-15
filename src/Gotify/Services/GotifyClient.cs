using Microsoft.Extensions.Options;
using pdbme.pdbInfrastructure.Gotify.Interfaces;
using pdbme.pdbInfrastructure.Gotify.Options;
using System.Text;
using System.Text.Json;

namespace pdbme.pdbInfrastructure.Gotify.Services;

public class GotifyClient : IGotifyClient
{
    private readonly HttpClient httpClient;
    private readonly GotifyOptions options;

    public GotifyClient(HttpClient httpClient, IOptions<GotifyOptions> options)
    {
        this.httpClient = httpClient;
        this.options = options.Value;
    }

    public void SendMessage(string title, string message, int priority)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, options.BaseUrl + $"/message?token={options.ApiKey}");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "pdbUploader");

        string jsonString = JsonSerializer.Serialize(new { title, message, priority });
        request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = httpClient.Send(request);
        response.EnsureSuccessStatusCode();

        /*
        var content = new StringContent(payload, Encoding.UTF8, "application/json");


        var person = new Person("John Doe", "gardener");

        var json = JsonConvert.SerializeObject(person);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var url = "https://httpbin.org/post";
        using var client = new HttpClient();

        var response = await client.PostAsync(url, data);

        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

        record Person(string Name, string Occupation);




        throw new NotImplementedException();
        */
    }
}
