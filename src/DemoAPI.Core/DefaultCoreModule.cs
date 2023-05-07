using Autofac;
using DemoAPI.Core.Interfaces;
using DemoAPI.Core.Services;

namespace DemoAPI.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {

    builder.RegisterType<DeleteClientService>()
        .As<IDeleteClientService>().InstancePerLifetimeScope();
  }
}
