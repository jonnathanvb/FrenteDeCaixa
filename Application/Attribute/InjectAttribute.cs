using Microsoft.Extensions.DependencyInjection;

namespace Application.Attribute;


[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class InjectAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped) : System.Attribute
{
    public ServiceLifetime Lifetime { get; } = lifetime;
}