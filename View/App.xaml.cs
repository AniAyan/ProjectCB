using Core.Data;
using Core.Data.Repositories;
using Core.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using View.Mapping;
using View.ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Directory.SetCurrentDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Core"));
            var currentWorkingDirectory = Directory.GetCurrentDirectory();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var serviceProvider = ConfigureServices();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var isSeeded = dbContext.Regions.Any();

                if (!isSeeded)
                {
                    var scriptFilePath = Path.Combine("Data", "SqlScripts", "SeedData.sql");
                    var scriptFullPath = Path.Combine(Directory.GetCurrentDirectory(), scriptFilePath);
                    var scriptContent = File.ReadAllText(scriptFullPath);
                    dbContext.Database.ExecuteSqlRaw(scriptContent);
                }

                var mainWindow = new MainWindow
                {
                    DataContext = serviceProvider.GetService<MainViewModel>()
                };

                mainWindow.Show();
            }
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<AppDbContext>();
            services.AddScoped<CustomerEntityDTOMapper>();
            services.AddScoped<ApplicationEntityDTOMapper>();
            services.AddScoped<BranchEntityDTOMapper>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<ApplicationRepository>();
            services.AddScoped<BranchRepository>();
            services.AddScoped<CustomerDTOViewModelMapper>();
            services.AddScoped<ApplicationDTOViewModelMapper>();
            services.AddScoped<BranchDTOViewModelMapper>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<BranchUpdateViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
