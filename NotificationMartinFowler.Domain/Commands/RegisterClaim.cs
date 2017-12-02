using System;
using NotificationMartinFowler.Domain.Dto;
using NotificationMartinFowler.Domain.Mocks;
using NotificationMartinFowler.Domain.Notifications;

namespace NotificationMartinFowler.Domain.Commands
{
    public class RegisterClaim : ServerCommand
    {
        private readonly RegisterClaimDto _registerClaimDto;

        public RegisterClaim(RegisterClaimDto claim) : base(claim)
        {
            _registerClaimDto = claim;
        }

        public void Run()
        {
            Validate();
            if (!Notification.HasErrors)
                RegisterClaimInBackendSystems();
        }

        private void Validate()
        {
            FailIfNullOrBlank(_registerClaimDto.PolicyId, RegisterClaimDto.MissingPolicyNumber);
            FailIfNullOrBlank(_registerClaimDto.Type, RegisterClaimDto.MissingIncidentType);
            Fail(_registerClaimDto.IncidentDate == DateTime.MinValue, RegisterClaimDto.MissingIncidentDate);
            if (string.IsNullOrWhiteSpace(_registerClaimDto.PolicyId)) return;
            Policy policy = Db.Policies.Find(x => x.PolicyId == _registerClaimDto.PolicyId);
            if (policy == null)
            {
                Notification.Errors.Add(RegisterClaimDto.UnknownPolicyNumber);
            }
            else
            {
                Fail((_registerClaimDto.IncidentDate.CompareTo(policy.InceptionDate) < 0),
                    RegisterClaimDto.DateBeforePolicyStart);
            }
        }

        protected void FailIfNullOrBlank(string s, Error error)
        {
            Fail(string.IsNullOrWhiteSpace(s), error);
        }
        protected void Fail(bool condition, Error error)
        {
            if (condition)
                Notification.Errors.Add(error);
        }

        private static void RegisterClaimInBackendSystems()
        {
            // Save on db
        }
    }
}