using System.Reflection;

namespace APIv2
{
    public class ConfigureService
    {
        public static void RegisterRepositories(IServiceCollection servicesCollection)
        {
            List<Type> repoAssemblyTypes = Assembly.Load("Repositories").ExportedTypes.Where(a => a.Name.ToLower().EndsWith("repository")).ToList();
            List<Type> repoInterfaces = repoAssemblyTypes.Where(a => a.IsInterface).ToList();
            List<Type> repoImplementations = repoAssemblyTypes.Where(a => a.IsClass).ToList();
            RegisterTypes(servicesCollection, repoInterfaces, repoImplementations);
        }

        public static void RegisterServices(IServiceCollection servicesCollection)
        {
            List<Type> serviceAssemblyTypes = Assembly.Load("Services").ExportedTypes.Where(a => a.Name.ToLower().EndsWith("service")).ToList();
            List<Type> serviceInterfaces = serviceAssemblyTypes.Where(a => a.IsInterface).ToList();
            List<Type> serviceImplementations = serviceAssemblyTypes.Where(a => a.IsClass).ToList();
            RegisterTypes(servicesCollection, serviceInterfaces, serviceImplementations);
        }

        public static void RegisterMappers(IServiceCollection servicesCollection)
        {
            List<Type> serviceAssemblyTypes = Assembly.Load("Mappers").ExportedTypes.Where(a => a.Name.ToLower().EndsWith("mapper")).ToList();
            List<Type> serviceInterfaces = serviceAssemblyTypes.Where(a => a.IsInterface).ToList();
            List<Type> serviceImplementations = serviceAssemblyTypes.Where(a => a.IsClass).ToList();
            RegisterTypes(servicesCollection, serviceInterfaces, serviceImplementations);
        }

        private static void RegisterTypes(IServiceCollection servicesCollection, List<Type> interfaces, List<Type> implementations)
        {
            foreach (Type interfaceType in interfaces)
            {
                Type? serviceType = implementations.FirstOrDefault(imp => interfaceType.IsAssignableFrom(imp));
                if (serviceType != null)
                {
                    servicesCollection.AddScoped(interfaceType, serviceType);
                }
            }
        }
    }
}
