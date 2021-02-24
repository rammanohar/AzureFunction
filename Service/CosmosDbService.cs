using Logandcosmodb.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Logandcosmodb.Model;

namespace Logandcosmodb.Service
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(AddOnCampaignJobModel item)
        {
            await this._container.CreateItemAsync<AddOnCampaignJobModel>(item, new PartitionKey(item.id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<AddOnCampaignJobModel>(id, new PartitionKey(id));
        }

        public async Task<AddOnCampaignJobModel> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<AddOnCampaignJobModel> response = await this._container.ReadItemAsync<AddOnCampaignJobModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<AddOnCampaignJobModel>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<AddOnCampaignJobModel>(new QueryDefinition(queryString));
            List<AddOnCampaignJobModel> results = new List<AddOnCampaignJobModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, AddOnCampaignJobModel item)
        {
            await this._container.UpsertItemAsync<AddOnCampaignJobModel>(item, new PartitionKey(id));
        }
    }
}

