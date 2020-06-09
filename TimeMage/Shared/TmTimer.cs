using System;

namespace TimeMage.Shared
{
    public class TmTimer
    {
        public string Name { get; set; } = "Timer";

        public TimeSpan Time { get; set; } = new TimeSpan(0, 5, 0);
    }
}
