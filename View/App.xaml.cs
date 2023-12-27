using Core.Data;
using Core.Data.Repositories;
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

            var serviceProvider = ConfigureServices();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Specify the relative path to the SQL script
                var scriptFilePath = Path.Combine("..", "..", "..", "..", "Core", "Data", "SqlScripts", "SeedData.sql");

                // Get the full path to the script file
                var scriptFullPath = Path.Combine(Directory.GetCurrentDirectory(), scriptFilePath);

                // Read SQL script content
                var scriptContent = File.ReadAllText(scriptFullPath);

                // Execute the script
                dbContext.Database.ExecuteSqlRaw(scriptContent);
            }

            // Create the main window and set its DataContext to your main ViewModel
            var mainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetService<MainViewModel>()
            };

            mainWindow.Show();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register services and view models
            services.AddScoped<AppDbContext>();
            services.AddScoped<CustomerRepository>();
            services.AddAutoMapper(typeof(App));

            services.AddTransient<MainViewModel>();

            // Other service registrations...

            // Build and return the service provider
            return services.BuildServiceProvider();
        }
    }
}
