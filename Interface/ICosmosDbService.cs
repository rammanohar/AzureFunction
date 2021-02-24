using Logandcosmodb.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logandcosmodb.Interface
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<AddOnCampaignJobModel>> GetItemsAsync(string query);
        Task<AddOnCampaignJobModel> GetItemAsync(string id);
        Task AddItemAsync(AddOnCampaignJobModel item);
        Task UpdateItemAsync(string id, AddOnCampaignJobModel item);
        Task DeleteItemAsync(string id);
    }
}
