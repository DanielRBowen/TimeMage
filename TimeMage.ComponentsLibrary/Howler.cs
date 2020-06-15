using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace TimeMage.ComponentsLibrary
{
    public static class Howler
    {
        public static ValueTask<string> Play(IJSRuntime jsRuntime, byte[] audioData)
           => jsRuntime.InvokeAsync<string>("playAudio.playBlob", audioData);
    }
}
