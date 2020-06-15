using System;
using System.Collections.Generic;
using TimeMage.Shared;

namespace TimeMage.Client
{
    public static class PreloadedIntervalSets
    {
        public static IntervalSet FatBurn { get; set; } = new IntervalSet
        {
            Name = "Fat Burn",
            Intervals = new List<TmTimer>
              {
                   new TmTimer{ Name = "Mountain Climbers", Time = TimeSpan.FromSeconds(30) },
                   new TmTimer{ Name = "Side Through", Time = TimeSpan.FromSeconds(20) },
                   new TmTimer{ Name = "Burpees", Time = TimeSpan.FromSeconds(10) },
                   new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(10) },

                   new TmTimer{ Name = "Mountain Climbers", Time = TimeSpan.FromSeconds(10) },
                   new TmTimer{ Name = "Side Through", Time = TimeSpan.FromSeconds(30) },
                   new TmTimer{ Name = "Burpees", Time = TimeSpan.FromSeconds(20) },
                   new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },

                   new TmTimer{ Name = "Mountain Climbers", Time = TimeSpan.FromSeconds(20) },
                   new TmTimer{ Name = "Side Through", Time = TimeSpan.FromSeconds(10) },
                   new TmTimer{ Name = "Burpees", Time = TimeSpan.FromSeconds(30) },
                   new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(30) },

                   new TmTimer{ Name = "Mountain Climbers", Time = TimeSpan.FromSeconds(30) },
                   new TmTimer{ Name = "Side Through", Time = TimeSpan.FromSeconds(20) },
                   new TmTimer{ Name = "Burpees", Time = TimeSpan.FromSeconds(10) },
              }
        };
    }
}
