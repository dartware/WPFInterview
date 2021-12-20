using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
	public interface ISignalR
	{

		event Action<IEnumerable<Int32>> DataReceived;

		Task InitAsync();

	}
}