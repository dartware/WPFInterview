using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs args)
		{
			
			base.OnStartup(args);

			DependencyResolver.Services.AddSingleton<FakeSignalRService>();
			DependencyResolver.Services.AddTransient<IThemes, ThemesService>();

			DependencyResolver.Services.AddSingleton<MainViewModel>();

			DependencyResolver.Build();

		}
	}
}