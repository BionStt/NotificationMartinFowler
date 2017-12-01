using System.Linq;
using NotificationsMartinFowler.Domain.Dto;
using NotificationsMartinFowler.Domain.Mocks;
using NotificationsMartinFowler.Domain.Notifications;

namespace NotificationsMartinFowler.Domain.Commands
{
    public class RegisterClaim : ServerCommand
    {
        public RegisterClaim(DataTransferObject claim) :
            base(claim)
        {
        }

        public void Run()
        {
            Validate();
            if (!Notification.HasErrors)
                RegisterClaimInBackendSystems();
        }

        private void Validate()
        {
            var data = Data as RegisterClaimDto;
            if (data == null) return;

            FailIfNullOrBlank(data.PolicyId, RegisterClaimDto.MissingPolicyNumber);
            FailIfNullOrBlank(data.Type, RegisterClaimDto.MissingIncidentType);
            Fail(data.IncidentDate == null, RegisterClaimDto.MissingIncidentDate);
            if (string.IsNullOrWhiteSpace(data.PolicyId)) return;
            var policy = Db.Policies.FirstOrDefault(x => x.PolicyId == data.PolicyId);
            if (policy == null)
            {
                Notification.Errors.Add(RegisterClaimDto.UnknownPolicyNumber);
            }
            else
            {
                if (data.IncidentDate != null)
                    Fail((data.IncidentDate.Value.CompareTo(policy.InceptionDate) < 0), RegisterClaimDto.DateBeforePolicyStart);
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