using CV.Core.Data;
using CV.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CV.Service
{
    public class BootstrapperService : IBootstrapperService
    {
        private readonly IBootstrapper _bootstrapper;
        public BootstrapperService(IBootstrapper bootstrapper)
        {
            _bootstrapper = bootstrapper;
        }
        public async Task InitialAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.InitialAsync(cancellationToken).ConfigureAwait(true);
            
        }
    }
}
