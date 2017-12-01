using System;
using System.Collections.Generic;

namespace NotificationMartinFowler.Domain.Mocks
{
    public class Policy
    {
        public Policy(string policyId, DateTime? inceptionDate)
        {
            PolicyId = policyId;
            InceptionDate = inceptionDate;
        }

        public string PolicyId { get; }
        public DateTime? InceptionDate { get; }
    }
}
