using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using AutofacDynamicContext.Domain;
using AutofacDynamicContext.EF;
using AutofacDynamicContext.EF.Repositories;
using AutofacDynamicContext.EF.Services;
using System.Web.Mvc;
using AutofacDynamicContext.Domain.Enums;

namespace AutofacDynamicContext.Web.App_Start
{
    public class AutofacConfig
    {

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Context
            builder.RegisterType<EnvironmentContext>().AsSelf().InstancePerRequest();
            builder.Register(c => new SampleContext("name=preprod")).Keyed<SampleContext>(CurrentEnvironment.PreProd).InstancePerRequest();
            builder.Register(c => new SampleContext("name=prod")).Keyed<SampleContext>(CurrentEnvironment.Prod).InstancePerRequest();

            // Repository
            builder.RegisterGeneric(typeof(BaseRepository<>)).AsImplementedInterfaces().InstancePerDependency();

            // Services
            builder.RegisterType<EmployeeService>().AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterModelBinderProvider();
            builder.RegisterModelBinders();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}