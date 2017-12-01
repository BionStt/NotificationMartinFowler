using System;
using NotificationMartinFowler.Domain.Notifications;

namespace NotificationMartinFowler.Domain.Dto
{
    public class RegisterClaimDto : DataTransferObject
    {
        public RegisterClaimDto(string policyId, string type, DateTime? incidentDate = null)
        {
            PolicyId = policyId;
            Type = type;
            IncidentDate = incidentDate;
        }

        public string PolicyId { get; }
        public string Type { get; }
        public DateTime? IncidentDate { get; }

        public static Error MissingPolicyNumber = new Error("Policy number is missing");
        public static Error UnknownPolicyNumber = new Error("This policy number is unknown");
        public static Error MissingIncidentType = new Error("Incident type is missing");
        public static Error MissingIncidentDate = new Error("Incident date is missing");
        public static Error DateBeforePolicyStart = new Error("Incident date is before we started doing this business");
    }
}