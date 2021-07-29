using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeMage.Shared
{
    public class TmTimer
    {
        /// <summary>
        /// Use JsonInclude property
        /// https://dev.to/j_sakamoto/c-some-scenarios-for-deserializing-a-json-to-a-type-with-read-only-properties-by-system-text-json-3lc
        /// </summary>
        [JsonInclude]
        public string Name { get; set; } = "Timer";

		[JsonInclude]
        public TimeSpan Time { get; set; } = new TimeSpan(0, 5, 0);

        private TimeSpan _timeLeft;

        [JsonIgnore]
        public TimeSpan TimeLeft
        {
            get { return _timeLeft; }
        }
       
        private bool _isTimerStopping;

        [JsonIgnore]
        public bool IsTimerStopping
        {
            get { return _isTimerStopping; }
        }

        private bool _isTimerRunning;

        [JsonIgnore]
        public bool IsTimerRunning
        {
            get { return _isTimerRunning; }
        }

        protected virtual void Finished(EventArgs e)
        {
            OnFinished?.Invoke(this, e);
        }

        public event EventHandler OnFinished;

        protected virtual void SecondElapsed(EventArgs e)
        {
            OnSecondElapsed?.Invoke(this, e);
        }

        public event EventHandler OnSecondElapsed;

        protected virtual void Stopped(EventArgs e)
        {
            OnStopped?.Invoke(this, e);
        }

        public event EventHandler OnStopped;

        public void Start()
        {
            Task.Run(() => Run());
        }

        private async Task Run()
        {
            if (Time.TotalSeconds <= 0 || _isTimerRunning)
            {
                return;
            }

            _timeLeft = Time;
            _isTimerRunning = true;
            _isTimerStopping = false;

            while (_timeLeft > new TimeSpan() && _isTimerRunning == true && _isTimerStopping == false)
            {
                await Task.Delay(1000);
                _timeLeft = _timeLeft.Subtract(new TimeSpan(0, 0, 1));
                SecondElapsed(EventArgs.Empty);
            }

            _timeLeft = new TimeSpan();
            Finished(EventArgs.Empty);
        }

        public void Stop()
        {
            _isTimerStopping = true;
            Task.Run(() => Stopping());
            Stopped(EventArgs.Empty);
        }

        private async Task Stopping()
        {
            await Task.Delay(1000);
            _isTimerRunning = false;
            SecondElapsed(EventArgs.Empty); // For State has changed.
        }
    }
}
