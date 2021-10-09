using Microsoft.Extensions.DependencyInjection;
using Penguin.Data.Repositories;
using Penguin.Domain.Interfaces;
using System;

namespace Penguin.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }

}
