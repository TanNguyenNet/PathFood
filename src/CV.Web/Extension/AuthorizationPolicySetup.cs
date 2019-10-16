using CV.Core.Authorization;
using CV.Data.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Extension
{
    public static class AuthorizationPolicySetup
    {
        public static void AddAuthorizationPolicySetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(ContantPolicy.Admin.ManageAdminData), policy => policy.Requirements.Add(new ClaimRequirement(nameof(ContantPolicy.Admin), ContantPolicy.Admin.ManageAdminData)));
            });
        }
    }
}
