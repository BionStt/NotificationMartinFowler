using System;
using NotificationsMartinFowler.Domain.Dto;
using NotificationsMartinFowler.Domain.Notifications;
using NotificationsMartinFowler.Domain.Services;

namespace NotificationMartinFowler.Prompt
{
    internal class Program
    {
        private RegisterClaimDto _claim;
        private static string _policyNumber;
        private static DateTime _incidentDate;
        private static string _policyType;
        private static ClaimService _claimService;

        private static void Main()
        {
            Console.WriteLine("Type policy ID");
            _policyNumber = Console.ReadLine();
            Console.WriteLine("Type incident type");
            _incidentDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Type incident date");
            _policyType = Console.ReadLine();
            _claimService = new ClaimService();
        }

        public void Submit()
        {
            SaveToClaim();
            _claimService.RegisterClaim(_claim);
            if (_claim.Notification.HasErrors)
            {
                Console.WriteLine("Not registered, see errors");
                IndicateErrors();
            }
            else
            {
                Console.WriteLine("Registration Succeeded");
            }
        }

        private void SaveToClaim()
        {
            _claim = new RegisterClaimDto(_policyNumber, _policyType, _incidentDate);
        }

        private void IndicateErrors()
        {
            CheckError(RegisterClaimDto.MissingPolicyNumber);
            CheckError(RegisterClaimDto.MissingIncidentType);
            CheckError(RegisterClaimDto.DateBeforePolicyStart);
            CheckError(RegisterClaimDto.MissingIncidentDate);
        }

        private void CheckError(Error error)
        {
            if (_claim.Notification.IncludesError(error))
                ShowError(error.ToString());
        }

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}
