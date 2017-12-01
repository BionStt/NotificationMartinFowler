using System;
using NotificationMartinFowler.Domain.Dto;
using NotificationMartinFowler.Domain.Notifications;
using NotificationMartinFowler.Domain.Services;

namespace NotificationMartinFowler.Prompt
{
    internal class Program
    {
        private static RegisterClaimDto _claim;
        private static string _policyNumber;
        private static DateTime _incidentDate;
        private static string _policyType;
        private static ClaimService _claimService;

        private static void Main()
        {
            Console.WriteLine("Type policy ID");
            _policyNumber = Console.ReadLine();
            Console.WriteLine("Type incident type");
            _policyType = Console.ReadLine();
            Console.WriteLine("Type incident date");
            if (!DateTime.TryParse(Console.ReadLine(), out _incidentDate))
                _incidentDate = DateTime.Now;
            _claimService = new ClaimService();
            Submit();
            Console.ReadKey();
        }

        private static void Submit()
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Registration Succeeded");
            }
        }

        private static void SaveToClaim()
        {
            _claim = new RegisterClaimDto(_policyNumber, _policyType, _incidentDate);
        }

        private static void IndicateErrors()
        {
            CheckError(RegisterClaimDto.MissingPolicyNumber, _policyNumber);
            CheckError(RegisterClaimDto.MissingIncidentType, _policyType);
            CheckError(RegisterClaimDto.DateBeforePolicyStart, _incidentDate);
            CheckError(RegisterClaimDto.MissingIncidentDate, _incidentDate);
        }

        private static void CheckError(Error error, object value)
        {
            if (_claim.Notification.IncludesError(error))
                ShowError(error + " | " + value);
        }

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}
