using Blazored.LocalStorage;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeMage.Shared.Dtos;

namespace TimeMage.Client
{
    public class SpeechToTextClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public SpeechToTextClient(
            HttpClient httpClient,
            ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<byte[]> GetSpeech(string text)
        {
            try
            {
                var audioData = await _localStorageService.GetItemAsync<byte[]>(text);

                if (audioData == null)
                {
                    var textDto = new TextDto
                    {
                        Text = text
                    };

                    var response = await _httpClient.PostAsJsonAsync("texttospeech/getspeech", textDto);
                    response.EnsureSuccessStatusCode();
                    audioData = await response.Content.ReadFromJsonAsync<byte[]>();
                    await _localStorageService.SetItemAsync<byte[]>(text, audioData);
                }

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
