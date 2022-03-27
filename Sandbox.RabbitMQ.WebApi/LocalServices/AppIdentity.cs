using OLT.Core;
using System.Security.Claims;
using System.Security.Principal;

namespace Sandbox.RabbitMQ.WebApi.LocalServices
{
    public class AppIdentity : OltIdentity
    {
        public override ClaimsPrincipal Identity
        {
            get
            {
                var roles = new List<string>();
                return new GenericPrincipal(new GenericIdentity(nameof(AppIdentity)), roles.ToArray());
            }
        }

        public override string Username => nameof(AppIdentity);
        public override string UserPrincipalName => $"{nameof(AppIdentity)}@fake.com";
        public override string Email => $"{nameof(AppIdentity)}@fake.com";

        public override bool HasRole(string claimName)
        {
            return true;
        }

    }
}
