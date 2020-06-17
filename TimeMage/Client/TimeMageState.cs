using System.Collections.Generic;
using TimeMage.Shared;
using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace TimeMage.Client
{
    public class TimeMageState
    {
        private readonly ILocalStorageService _localStorageService;

        public TimeMageState(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public List<TmTimer> Timers { get; set; } = new List<TmTimer>();

        public List<IntervalSet> IntervalSets { get; set; } = new List<IntervalSet>();

        public async Task SaveAsync()
        {
            await _localStorageService.SetItemAsync<List<TmTimer>>(nameof(Timers), Timers);
            await _localStorageService.SetItemAsync(nameof(IntervalSets), IntervalSets);
        }

        public async Task LoadAsync()
        {
            var timers = await _localStorageService.GetItemAsync<List<TmTimer>>(nameof(Timers));

            if (timers != null)
            {
                Timers = timers;
            }

            var intervalSets = await _localStorageService.GetItemAsync<List<IntervalSet>>(nameof(IntervalSets));

            if (intervalSets != null)
            {
                IntervalSets = intervalSets;
            }
        }
    }
}
