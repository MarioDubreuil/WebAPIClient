﻿using System.Net.Http.Headers;
using System.Text.Json;

namespace WebAPIClient
{
    internal class Program
    {
        private static readonly HttpClient client = new();
        static async Task Main()
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            foreach (var repository in repositories)
            {
                Console.WriteLine(repository.Name);
            }
        }
    }
}