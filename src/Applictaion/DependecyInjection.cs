using Applictaion.Common;
using Applictaion.Common.Behaviours;
using Applictaion.Common.Event;
using Applictaion.Common.Interface;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Applictaion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).AddMediatr()
            .AddTransient<IEventPublisher, EventPublisher>();
         
            return services;
        }
        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            MediatRServiceConfiguration _mediatrConfiguration = new MediatRServiceConfiguration();
            _mediatrConfiguration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services.AddMediatR(_mediatrConfiguration);
        }
    }
}
