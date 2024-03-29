﻿using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
			//var preloadedIntervalSets = await _httpClient.GetFromJsonAsync<List<IntervalSet>>("PreloadedIntervalSets/GetPreloadedIntervalSets");
			//return PreloadedIntervalSets.IntervalSets; // Just get the interval sets from memory because the Json Deserialization isn't working.
			JsonSerializerOptions jsonSerializerOptions = new(); // https://github.com/dotnet/runtime/issues/29932
			jsonSerializerOptions.Converters.Add(new TimeSpanConverter());
			var preloadedIntervalSets = await _httpClient.GetFromJsonAsync<List<IntervalSet>>("IntervalSets.json", jsonSerializerOptions); // https://www.syncfusion.com/faq/blazor/web-api/how-do-i-read-a-json-file-in-blazor-webassembly
			return preloadedIntervalSets;
		}
	}
}
