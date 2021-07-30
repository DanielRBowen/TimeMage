using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace TimeMage.ComponentsLibrary
{
	public static class NoSleep
	{
		public static ValueTask<string> Enable(IJSRuntime jsRuntime)
		  => jsRuntime.InvokeAsync<string>("noSleepEnable");

		public static ValueTask<string> Disable(IJSRuntime jsRuntime)
		=> jsRuntime.InvokeAsync<string>("noSleepDisable");
	}
}
