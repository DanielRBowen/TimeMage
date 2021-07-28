using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TimeMage.Shared;
using TimeMage.Shared.Dtos;

namespace TimeMage.Client
{
    public class PreloadedIntervalSetsClient
    {
        private readonly HttpClient _httpClient;

        public PreloadedIntervalSetsClient(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<IntervalSet>> GetPreloadedIntervalSets()
        {
            var preloadedIntervalSets = await _httpClient.GetFromJsonAsync<List<IntervalSet>>("PreloadedIntervalSets/GetPreloadedIntervalSets");
            return preloadedIntervalSets;
        }

		public List<IntervalSet> PreloadedIntervalSets { get; private set; }
	}
}
