using System.Collections.Generic;

namespace TimeMage.Shared
{
    public class IntervalSet
    {
        public string Name { get; set; } = "Fat Burn";

        public List<TmTimer> Intervals { get; set; } = new List<TmTimer>();
    }
}
