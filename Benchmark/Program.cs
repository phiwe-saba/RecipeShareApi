using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput)]
[Config(typeof(InProcessConfig))]
public class RecipeApiBenchmark
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://localhost:7062") 
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

    private class InProcessConfig : ManualConfig
    {
        public InProcessConfig()
        {
            AddJob(Job.Default.WithToolchain(BenchmarkDotNet.Toolchains.InProcess.NoEmit.InProcessNoEmitToolchain.Instance));
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