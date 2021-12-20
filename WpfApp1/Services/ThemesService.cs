using System;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.Services
{
	public sealed class ThemesService : IThemes
	{
		public void Apply(Theme theme)
		{

			String path = theme switch
			{
				Theme.Light => "./Resources/Themes/Light.xaml",
				Theme.Dark => "./Resources/Themes/Dark.xaml",
				_ => null
			};

			if (String.IsNullOrEmpty(path))
			{
				return;
			}

			Application.Current.Resources.MergedDictionaries[0].Source = new Uri(path, UriKind.RelativeOrAbsolute);

		}
	}
}