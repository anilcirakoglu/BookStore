using Core.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Aspects
{
    public static class Configure
    {
        public static IServiceCollection ConfigureBusiness(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddInterceptedScoped<IUserBO, UserBO>()
                .AddInterceptedScoped<InterceptorBase<CacheAttribute>, CacheInterceptor>()
                .AddInterceptedScoped<InterceptorBase<PerformanceAttribute>, PerformanceInterceptor>();

        }
    }
}
