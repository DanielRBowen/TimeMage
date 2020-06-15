using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeMage.Shared.Dtos;

namespace TimeMage.Client
{
    public class SpeechToTextClient
    {
        private readonly HttpClient _httpClient;

        public SpeechToTextClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetSpeech(string text)
        {
            try
            {
                // https://developer.mozilla.org/en-US/docs/Web/API/File
                // TODO: Check if it is cached on the client first;
                var textDto = new TextDto
                {
                    Text = text
                };

                var response = await _httpClient.PostAsJsonAsync("texttospeech/getspeech", textDto);
                response.EnsureSuccessStatusCode();
                var audioData = await response.Content.ReadFromJsonAsync<byte[]>();
                return audioData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
