using System;
using NotificationMartinFowler.Domain.Notifications;

namespace NotificationMartinFowler.Domain.Dto
{
    public class RegisterClaimDto : DataTransferObject
    {
        public string PolicyId { get; set; }

        public string Type { get; set; }

        public DateTime IncidentDate { get; set; } = BlankDate;

        public static DateTime BlankDate => DateTime.MinValue;

        public static Error MissingPolicyNumber = new Error("Policy number is missing");
        public static Error UnknownPolicyNumber = new Error("This policy number is unknown");
        public static Error MissingIncidentType = new Error("Incident type is missing");
        public static Error MissingIncidentDate = new Error("Incident Date is missing");
        public static Error DateBeforePolicyStart = new Error("Incident Date is before we started doing this business");
    }
}