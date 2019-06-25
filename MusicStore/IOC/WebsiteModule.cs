using Autofac;
using Autofac.Integration.Mvc;
using MusicStore.Business.PaymentGateway;
using MusicStore.Controllers;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Infrastructure.Repository;
using Payment.PaymentClient;
using System.Diagnostics.CodeAnalysis;

namespace MusicStore.IOC
{
    [ExcludeFromCodeCoverage]
    public class WebsiteModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());

         
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(MakePaymentController).Assembly);
            builder.RegisterControllers(typeof(CartController).Assembly);
            builder.RegisterType<DatabaseCallImpl>()
                .As<IDatabaseCalls>()
                .SingleInstance();
            builder.RegisterControllers(typeof(CartController).Assembly);
            builder.RegisterType<PaymentClient>()
                .As<IPaymentClient>()
                .SingleInstance();
            builder.RegisterType<PaymentGateway>()
                .As<IPaymentGateway>()
                .SingleInstance();
            base.Load(builder);
        }
    }
}