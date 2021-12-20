using System;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1
{
	public static class DependencyResolver
	{

		private static IServiceProvider serviceProvider;

		public static IServiceCollection Services { get; }

		static DependencyResolver()
		{
			Services = new ServiceCollection();
		}

		public static void Build()
		{
			serviceProvider = Services.BuildServiceProvider();
		}

		public static TypeDefenition Get<TypeDefenition>() => serviceProvider.GetService<TypeDefenition>();

	}
}