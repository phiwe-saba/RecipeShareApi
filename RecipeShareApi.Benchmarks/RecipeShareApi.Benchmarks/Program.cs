/*using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

private readonly HttpClient _client = new()
{
    BaseAddress = new Uri("")
};

[Benchmark]
public async Task GetAllRecipes_500SequentialRequests()
{
    for (int i = 0; i < 500; i++)
    {
        var response = await _client.GetAsync();
        response.EnsureSuccessStatusCode();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<RecipeApiBenchmark>();
    }
}*/

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace RecipeShareApi.Benchmarks
{
    public class RecipeApiBenchmark
    {
        private readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://localhost:7062") // Update port if different
        };

        [Benchmark]
        public async Task GetAllRecipes_500SequentialRequests()
        {
            for (int i = 0; i < 500; i++)
            {
                var response = await _client.GetAsync("/api/recipe");
                response.EnsureSuccessStatusCode();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<RecipeApiBenchmark>();
        }
    }
}
