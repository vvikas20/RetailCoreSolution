using Microsoft.Extensions.DependencyInjection;
using RetailCore.Interfaces.DataAccess;
using RetailCore.Interfaces.Repository;
using RetailCore.Persistance.DataAccess;
using RetailCore.Repository;
using RetailCore.ServiceContracts;
using RetailCore.Services;

namespace RetailCore.WindowsApp
{
	internal static class Program
	{
		private static IServiceProvider serviceProvider;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			serviceProvider = serviceCollection.BuildServiceProvider();

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			var userService = serviceProvider.GetRequiredService<IUserService>();

			var userCount = userService.GetUserCount();
			if (userCount == 0)
			{
				Application.Run(serviceProvider.GetRequiredService<MainForm>());
			}
			else
			{
				Application.Run(serviceProvider.GetRequiredService<LoginForm>());
			}
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IDatabaseFactory, DatabaseFactory>();
			services.AddSingleton<IUnitOfWork, UnitOfWork>();

			services.AddTransient<IRoleLevelRepository, RoleLevelRepository>();
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IUserRoleRepository, UserRoleRepository>();


			services.AddTransient<IRoleLevelService, RoleLevelService>();
			services.AddTransient<IRoleService, RoleService>();
			services.AddTransient<IUserService, UserService>();

			services.AddSingleton<LoginForm>();
			services.AddSingleton<MainForm>();
			services.AddTransient<AddUserForm>();
			services.AddTransient<AddRoleLevelForm>();
			services.AddTransient<AddRoleForm>();

		}
	}
}