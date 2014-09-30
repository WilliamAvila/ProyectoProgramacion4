using System.Reflection;
using Autofac;
using AutoMapper;

namespace PredictionLeague.Api
{
    public class ConfigureDependencies : IBootstrapperTask
    {
        readonly ContainerBuilder _containerBuilder;

        public ConfigureDependencies(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        #region IBootstrapperTask Members

        public void Run()
        {
            Assembly data = Assembly.Load("PredictionLeague.Data");
            Assembly domain = Assembly.Load("PredictionLeague.Domain");

            _containerBuilder
                .RegisterAssemblyTypes(data, domain)
                .AsImplementedInterfaces();
            _containerBuilder.Register(c => Mapper.Engine).As<IMappingEngine>();

        }

        #endregion
    }
}