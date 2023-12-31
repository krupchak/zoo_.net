using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ZooAnimals.Dtos;

namespace ZooAnimals.SyncDataClient.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendAnimalsToCommand(AnimalsReadDto animals)
        {
            var httpClient = new StringContent(
                JsonSerializer.Serialize(animals),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpClient);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
            }
        }
    }
} 