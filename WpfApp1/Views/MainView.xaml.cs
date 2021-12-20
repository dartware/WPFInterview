using System.ComponentModel;
using System.Windows.Controls;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
	public partial class MainView : UserControl
	{
		public MainView()
		{

			InitializeComponent();

			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				DataContext = DependencyResolver.Get<MainViewModel>();
			}

		}
	}
}