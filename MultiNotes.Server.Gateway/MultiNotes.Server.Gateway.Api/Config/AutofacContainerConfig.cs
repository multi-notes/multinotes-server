using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace MultiNotes.Server.Gateway.Api.Config
{
    public static class AutofacContainerConfig
    {
        public static void RegisterAssemblies(ContainerBuilder builder)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(currentAssemblies)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
