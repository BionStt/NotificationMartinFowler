using NotificationMartinFowler.Domain.Commands;
using NotificationMartinFowler.Domain.Dto;

namespace NotificationMartinFowler.Domain.Services
{
    public class ClaimService
    {
        public void RegisterClaim(RegisterClaimDto claim)
        {
            var cmd = new RegisterClaim(claim);
            cmd.Run();
        }
    }
}