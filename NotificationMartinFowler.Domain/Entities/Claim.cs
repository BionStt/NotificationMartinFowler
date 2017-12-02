using System;

namespace NotificationMartinFowler.Domain.Entities
{
    public class Claim
    {
        public Claim(string policyId, string type, DateTime incidentDate)
        {
            PolicyId = policyId;
            Type = type;
            IncidentDate = incidentDate;
        }

        public string PolicyId { get; }
        public string Type { get; }
        public DateTime IncidentDate { get; }
    }
}
