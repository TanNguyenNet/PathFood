using CV.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CV.Data.EF
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly CVContext _context;

        public Bootstrapper(CVContext context)
        {
            _context = context;
        }

        public Task InitialAsync(CancellationToken cancellationToken = default)
        {
            return _context.Database.MigrateAsync(cancellationToken);
        }

        public Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
