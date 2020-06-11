using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimeMage.Shared
{
    public class TmTimer
    {
        public string Name { get; set; } = "Timer";

        public TimeSpan Time { get; set; } = new TimeSpan(0, 5, 0);

        private TimeSpan _timeLeft;

        public TimeSpan TimeLeft
        {
            get { return _timeLeft; }
        }

        private bool _isTimerRunning;

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

            while (_timeLeft > new TimeSpan() && _isTimerRunning == true)
            {
                await Task.Delay(1000);
                _timeLeft = _timeLeft.Subtract(new TimeSpan(0, 0, 1));
                SecondElapsed(EventArgs.Empty);
            }

            Finished(EventArgs.Empty);
        }

        public void Stop()
        {
            _isTimerRunning = false;
            Stopped(EventArgs.Empty);
        }
    }
}
