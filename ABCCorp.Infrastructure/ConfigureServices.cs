using System;
using ABCCorp.Application.Interfaces;
using ABCCorp.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABCCorp.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ABCCorpDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<ITaskService, TaskService>();
			services.AddScoped<ITaskRepository, TaskRepository>();
			services.AddScoped<ITaskManagerRepository, TaskManagerRepository>();
            services.AddScoped<ITaskManagerService, TaskManagerService>();

            return services;
		}
	}
}

