using log4net;
using log4net.Config;
using log4net.Repository;
using Logandcosmodb.Interface;
using Logandcosmodb.Model;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Logandcosmodb
{
    public class CustomFunction
    {
        private ILog log;
        private ICosmosDbService cosmosDbService;

        public CustomFunction(ILog log, ICosmosDbService cosmosDbService)
        {
            this.log = log;
            this.cosmosDbService = cosmosDbService;
        }

        [FunctionName("CustomFunction")]
        public void Run([TimerTrigger("0 */2 * * * *")] TimerInfo myTimer)
        {
            
            this.log.Info("Greetings, earthling.");

            this.log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            List<AddOnCampaignJobModel> jobs = new List<AddOnCampaignJobModel> 
                                        {
                                            new AddOnCampaignJobModel
                                            {   id ="1",
                                                JobId =124,
                                                JobNumber = "one",
                                                GarageName= "BMW",
                                                GarageId = 1,
                                                CommunicationId = Guid.NewGuid(),
                                                ContactRef = Guid.NewGuid(),
                                                GarageRef = Guid.NewGuid(),
                                                JobStatus = "Actvie",
                                                Make = "BMW",
                                                Model = "Series 1",
                                                Name = "Jaya",
                                            },
                                            new AddOnCampaignJobModel
                                            {   id ="2",
                                                 JobId =134,
                                                JobNumber = "one",
                                                GarageName= "BMW",
                                                GarageId = 1,
                                                CommunicationId = Guid.NewGuid(),
                                                ContactRef = Guid.NewGuid(),
                                                GarageRef = Guid.NewGuid(),
                                                JobStatus = "Actvie",
                                                Make = "BMW",
                                                Model = "Series 1",
                                                Name = "Jaya",
                                            },

            };

            foreach(var job in jobs)
            { 
            //Check to see a job with Id 1 is present in cosmos db.
            if ((ReadCosmos(job.id).Result == null))
            {
                InsertCosmos(job);
            }
            }




        }



        public async Task<AddOnCampaignJobModel> ReadCosmos(string id)
        {
            return await this.cosmosDbService.GetItemAsync(id);
        }


        public async void InsertCosmos(AddOnCampaignJobModel job)
        {
            await this.cosmosDbService.AddItemAsync(job);
        }
    }
}
