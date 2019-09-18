using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CV.Service.Interface
{
    public interface IBootstrapperService
    {
        Task InitialAsync(CancellationToken cancellationToken = default);
    }
}
