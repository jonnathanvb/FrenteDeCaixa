using System.Reflection;
using Application.Attribute;

namespace API.IoC;

public static class InjectDependency
{
    public static IServiceCollection Inject(this IServiceCollection services)
    {
        
        var typesWithInjectAttribute = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(type => type.IsClass && type.GetCustomAttribute<InjectAttribute>() != null);

        foreach (var type in typesWithInjectAttribute)
        {
            var injectAttribute = type.GetCustomAttribute<InjectAttribute>();
            var interfaces = type.GetInterfaces();
            
            if (interfaces.Length > 0)
            {
                foreach (var inter in interfaces)
                {
                    if (injectAttribute != null)
                        services.Add(new ServiceDescriptor(inter, type, injectAttribute.Lifetime));
                }
            }
            else
            {
                if (injectAttribute != null) services.Add(new ServiceDescriptor(type, type, injectAttribute.Lifetime));
            }
        }

        return services;
    }
}