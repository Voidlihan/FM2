using FarmersMarket.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FarmersMarket
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public User currentUser { get; set; }
        public string ConnectionString { get; set; }

        public App()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appSettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();

            ConnectionString = configurationRoot.GetConnectionString("MyConnectionString");
        }
	}
}
