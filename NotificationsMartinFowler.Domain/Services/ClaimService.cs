using NotificationsMartinFowler.Domain.Commands;
using NotificationsMartinFowler.Domain.Dto;

namespace NotificationsMartinFowler.Domain.Services
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