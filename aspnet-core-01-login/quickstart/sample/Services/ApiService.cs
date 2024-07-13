using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetDataAsync()
    {
        try
        {
            string url = "http://localhost:3000/api/data/get-data";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            // Manejar o registrar el error
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }
}
