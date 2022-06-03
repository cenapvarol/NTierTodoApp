using Cbs.TodoAppNTier.Business.Interfaces;
using Cbs.TodoAppNTier.Business.Services;
using Cbs.TodoAppNTier.DataAccess.Context;
using Cbs.TodoAppNTier.DataAccess.Interfaces;
using Cbs.TodoAppNTier.DataAccess.UnitofWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Cbs.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtention
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("Server=127.0.0.1;Database=TodoDb;User Id=sa;Password=Cbs123db;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();
        }

    }
}
