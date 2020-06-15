using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace TimeMage.ComponentsLibrary
{
    public static class Audio
    {
        public static ValueTask<string> Play(IJSRuntime jsRuntime, byte[] audioData)
           => jsRuntime.InvokeAsync<string>("playAudio.play", audioData);
    }
}
