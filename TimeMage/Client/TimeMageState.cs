using System.Collections.Generic;
using TimeMage.Shared;

namespace TimeMage.Client
{
    public class TimeMageState
    {
        public List<TmTimer> Timers { get; set; } = new List<TmTimer>();

        public List<IntervalSet> IntervalSets { get; set; } = new List<IntervalSet>();
    }
}
