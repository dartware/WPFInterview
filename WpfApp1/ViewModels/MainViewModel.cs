using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using WpfApp1.Core;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
	public sealed class MainViewModel : ViewModel
	{

		private readonly FakeSignalRService signalR;

		public ObservableCollection<Int32> Data { get; }

		public ReactiveCommand<Unit, Unit> LoadedCommand { get; }
		public ReactiveCommand<Theme, Unit> ApplyThemeCommand { get; }
		public ReactiveCommand<Unit, Unit> SaveToFileCommand { get; }

		public MainViewModel(FakeSignalRService signalR, IThemes themes)
		{
			this.signalR = signalR;
			Data = new ObservableCollection<Int32>();
			LoadedCommand = ReactiveCommand.CreateFromTask(OnLoadedAsync);
			ApplyThemeCommand = ReactiveCommand.Create<Theme>(themes.Apply);
			SaveToFileCommand = ReactiveCommand.Create(SaveToFile);
		}

		private async Task OnLoadedAsync()
		{

			signalR.DataReceived += OnDataReceived;

			await signalR.InitAsync();

		}

		private void OnDataReceived(IEnumerable<Int32> data)
		{
			Data.AddRange(data);
		}

		private void SaveToFile()
		{
			Task.Factory.StartNew(async () =>
			{

				IEnumerable<Int32> dataForSave = Data.Take(100);
				StreamWriter writer = new StreamWriter("File.txt");

				foreach (Int32 number in dataForSave)
				{
					writer.WriteLine(number.ToString());
				}

			});
		}

	}
}