using log4net;
using Logandcosmodb.Concrete;
using Logandcosmodb.Interface;
using Logandcosmodb.Service;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Logandcosmodb.Startup))]

namespace Logandcosmodb
{
    public class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var path = System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.FullName;
            builder.Services.AddSingleton<ILog>(new Azure4NetLogger(path));

            var config = new ConfigurationBuilder()
                                .SetBasePath(path)
                                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables()
                                .Build();

            var ConfigurationContext = config.GetSection("CosmosDb");


            var TaskCosmosDbService = InitializeCosmosClientInstanceAsync(ConfigurationContext).GetAwaiter().GetResult();
            builder.Services.AddSingleton<ICosmosDbService>(TaskCosmosDbService);
        }




        private static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection section)
        {
            string databaseName = section.GetSection("DatabaseName").Value;
            string containerName = section.GetSection("ContainerName").Value;
            string account = section.GetSection("Account").Value;
            string key = section.GetSection("Key").Value;
            string partionId = section.GetSection("PartionId").Value;
            CosmosClient client = new CosmosClient(account, key, new CosmosClientOptions() { ApplicationName = "Autino" });

            CosmosDbService cosmosDbService = new CosmosDbService(client, databaseName, containerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, partionId);

            return cosmosDbService;
        }
    }

}
