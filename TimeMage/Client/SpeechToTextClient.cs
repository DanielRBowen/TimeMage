using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TimeMage.Client
{
    public class SpeechToTextClient
    {
        private readonly HttpClient _httpClient;

        public SpeechToTextClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> GetSpeech(string text)
        {
            try
            {
                // https://developer.mozilla.org/en-US/docs/Web/API/File
                // TODO: Check if it is cached on the client first;
                var audioData = await _httpClient.GetFromJsonAsync<byte[]>("getspeechbytes");
                File.WriteAllBytes("speech.wav", audioData); // Should only be one speech played at a time so overwrite it.
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
