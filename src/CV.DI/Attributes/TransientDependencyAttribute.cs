using Microsoft.Extensions.DependencyInjection;

namespace CV.DI.Attributes
{
    public class TransientDependencyAttribute : DependencyAttribute
    {
        public TransientDependencyAttribute() : base(ServiceLifetime.Transient)
        {
        }
    }
}