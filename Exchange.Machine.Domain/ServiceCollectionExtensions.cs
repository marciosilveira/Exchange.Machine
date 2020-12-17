using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Machine.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependency(this IServiceCollection services)
        {
            return services
                .AddSingleton(Box.New(Coin.New()))
                .AddTransient<ICashRegister, CashRegister>()
                .AddTransient<ICalculateChange, CalculateChange>();
        }
    }
}
