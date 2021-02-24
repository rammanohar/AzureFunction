using System;
using System.Collections.Generic;
using System.Text;

namespace Logandcosmodb.Model
{
    public class AddOnCampaignJobModel
    {
        public int GarageId { get; set; }
        public string GarageName { get; set; }
        public Guid GarageRef { get; set; }
        public string id { get; set; }
        public int JobId { get; set; }
        public string JobNumber { get; set; }
        public Guid CommunicationId { get; set; }
        public string JobStatus { get; set; }
        public string Name { get; set; }
        public Guid ContactRef { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
