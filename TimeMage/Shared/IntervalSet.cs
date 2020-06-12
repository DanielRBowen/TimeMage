using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeMage.Shared
{
    public class IntervalSet
    {
        public string Name { get; set; } = "Fat Burn";

        public List<TmTimer> Intervals { get; set; } = new List<TmTimer>();

        public TimeSpan TotalTime
        {
            get
            {
                var totalTime = new TimeSpan();
                Intervals.ForEach(timer => totalTime += timer.Time);
                return totalTime;
            }
        }
        private bool _isTimerRunning;

        public bool IsTimerRunning
        {
            get { return _isTimerRunning; }
        }

        private int _currentIntervalIndex;

        private string _currentIntervalName;

        public string CurrentIntervalName
        {
            get { return _currentIntervalName; }
        }

        private TimeSpan _totalTimeLeft;

        public TimeSpan TotalTimeLeft
        {
            get { return _totalTimeLeft; }
        }

        private TimeSpan _currentTimerLeft;

        public TimeSpan CurrentTimerLeft
        {
            get { return _currentTimerLeft; }
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

        protected virtual void CurrentIntervalStarted(EventArgs e)
        {
            OnCurrentIntervalStarted?.Invoke(this, e);
        }

        public event EventHandler OnCurrentIntervalStarted;

        public void Start()
        {
            Run();
        }

        private void Run()
        {
            if (Intervals.Any() == false || _isTimerRunning)
            {
                return;
            }

            Intervals.ForEach(timer => _totalTimeLeft += timer.Time);
            _currentIntervalIndex = 0;
            SecondElapsed(EventArgs.Empty);
            _isTimerRunning = true;
            StartCurrentInterval();
        }

        private void StartCurrentInterval()
        {
            _currentTimerLeft = Intervals[_currentIntervalIndex].TimeLeft;
            _currentIntervalName = Intervals[_currentIntervalIndex].Name;
            CurrentIntervalStarted(EventArgs.Empty);
            Intervals[_currentIntervalIndex].OnSecondElapsed += Interval_OnSecondElapsed;
            Intervals[_currentIntervalIndex].OnFinished += Interval_OnFinished;
            Intervals[_currentIntervalIndex].Start();

        }

        public void Stop()
        {
            _isTimerRunning = false;
            Intervals.ForEach(timer => timer.Stop());
            Stopped(EventArgs.Empty);
        }

        private void Interval_OnSecondElapsed(object sender, EventArgs e)
        {
            _totalTimeLeft = _totalTimeLeft.Subtract(new TimeSpan(0, 0, 1));
            _currentTimerLeft = Intervals[_currentIntervalIndex].TimeLeft;
            SecondElapsed(EventArgs.Empty);
        }

        private void Interval_OnStopped(object sender, EventArgs e)
        {
        }

        private void Interval_OnFinished(object sender, EventArgs e)
        {
            _currentIntervalIndex++;

            if (_currentIntervalIndex < Intervals.Count)
            {
                StartCurrentInterval();
            }
            else
            {
                Intervals.ForEach(timer => timer.Stop());
                Finished(EventArgs.Empty);
            }
        }
    }
}
