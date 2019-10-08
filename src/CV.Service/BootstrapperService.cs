using CV.Core.Data;
using CV.Data.Entities.Identity;
using CV.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CV.Service
{
    public class BootstrapperService : IBootstrapperService
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly UserManager<AppUser> _userManager;

        public BootstrapperService(IBootstrapper bootstrapper, UserManager<AppUser> userManager)
        {
            _bootstrapper = bootstrapper;
            _userManager = userManager;
        }

        public async Task InitialAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.InitialAsync(cancellationToken).ConfigureAwait(true);
            await InitialUser(cancellationToken).ConfigureAwait(true);
        }

        protected async Task InitialUser(CancellationToken cancellationToken = default)
        {
            if (_userManager.Users.Count() == 0)
            {
                var newUser = new AppUser()
                {
                    UserName = "admin",
                    Email = "itnbtan@gmail.com",
                    FirstName = "Tan",
                    LastName = "Nguyen"
                };
                await _userManager.CreateAsync(newUser, "123456");
            }
        }
    }
}