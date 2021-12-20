using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
	public sealed class FakeSignalRService
	{

		public event Action<IEnumerable<Int32>> DataReceived;

		public async Task InitAsync()
		{
			await Task.Run(() =>
			{

				Random random = new Random();
				List<Int32> data = new List<Int32>();

				for (Int32 index = 0; index < 20_000; index++)
				{
					data.Add(random.Next());
				}

				Thread.Sleep(2000);
				DataReceived?.Invoke(data);

			});
		}

	}
}