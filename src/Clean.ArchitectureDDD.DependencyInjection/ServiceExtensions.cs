using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clean.ArchitectureDDD.DependencyInjection
{
    public static class ServiceExtensions
    {
        //public static void ConfigureService(this IServiceCollection services)
        //{
        //    var assemblies = new List<Assembly>();

        //    foreach (string assemblyPath in Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories))
        //    {
        //        var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
        //        assemblies.Add(assembly);
        //    }


        //    // Define types that need matching
        //    var scopedRegistration = typeof(ScopedRegisterAttribute);
        //    //var singletonRegistration = typeof(SingletonRegistrationAttribute);
        //    //var transientRegistration = typeof(TransientRegistrationAttribute);

        //    var types = assemblies//AppDomain.CurrentDomain.GetAssemblies()
        //        .SelectMany(s => s.GetTypes())
        //        .Where(p => p.IsDefined(scopedRegistration, false)
        //                     //|| p.IsDefined(transientRegistration, false)
        //                     //|| p.IsDefined(singletonRegistration, false)
        //                     && !p.IsInterface)
        //        .Select(s => new
        //        {
        //            Service = s.GetInterface($"I{s.Name}"),
        //            Implementation = s
        //        })
        //        .Where(x => x.Service != null);

        //    foreach (var type in types)
        //    {
        //        if (type.Implementation.IsDefined(scopedRegistration, false))
        //        {
        //            services.AddScoped(type.Service, type.Implementation);
        //        }

        //    }
        //}

        public static void RegisterServices(this IServiceCollection services)
        {
            // Define types that need matching
            var scopedRegistration = typeof(ScopedRegisterAttribute);
            //var singletonRegistration = typeof(SingletonRegistrationAttribute);
            //var transientRegistration = typeof(TransientRegistrationAttribute);

            var assemblies = Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories)
                .Select(assemblyPath => System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath))
                .ToList();

            var types = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsDefined(scopedRegistration, false)
                             //|| p.IsDefined(transientRegistration, false)
                             //|| p.IsDefined(singletonRegistration, false)
                             && !p.IsInterface)
                .Select(s => new
                {
                    Service = s.GetInterface($"I{s.Name}"),
                    Implementation = s
                })
                .Where(x => x.Service != null);

            foreach (var type in types)
            {
                if (type.Implementation.IsDefined(scopedRegistration, false))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }

                //if (type.Implementation.IsDefined(transientRegistration, false))
                //{
                //    services.AddTransient(type.Service, type.Implementation);
                //}

                //if (type.Implementation.IsDefined(singletonRegistration, false))
                //{
                //    services.AddSingleton(type.Service, type.Implementation);
                //}
            }

        }


    }
}
