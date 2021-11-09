using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeMage.Shared
{
	public class IntervalSet : IGuidedIntervalSet
	{
		[JsonInclude]
		public string Name { get; set; } = "Name";

		[JsonInclude]
		public List<TmTimer> Intervals { get; set; } = new List<TmTimer>();

		[JsonInclude]
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

		[JsonIgnore]
		public bool IsTimerRunning
		{
			get { return _isTimerRunning; }
		}

		private int _currentIntervalIndex;

		private string _currentIntervalName;

		[JsonIgnore]
		public string CurrentIntervalName
		{
			get { return _currentIntervalName; }
		}

		private string _nextIntervalName;

		[JsonIgnore]
		public string NextIntervalName
		{
			get { return _nextIntervalName; }
		}

		private TimeSpan _totalTimeLeft;

		[JsonIgnore]
		public TimeSpan TotalTimeLeft
		{
			get { return _totalTimeLeft; }
		}

		private TimeSpan _currentTimerLeft;

		[JsonIgnore]
		public TimeSpan CurrentTimerLeft
		{
			get { return _currentTimerLeft; }
		}

		[JsonInclude]
		public string GuideUrl { get; set; }

		private bool _isPaused;

		[JsonIgnore]
		public bool IsPaused
		{
			get { return _isPaused; }
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

		private void StopFinishedCurrentInterval()
		{
			Intervals[_currentIntervalIndex].OnSecondElapsed -= Interval_OnSecondElapsed;
			Intervals[_currentIntervalIndex].OnFinished -= Interval_OnFinished;
			Intervals[_currentIntervalIndex].Stop();
		}

		private void StartCurrentInterval()
		{
			_currentTimerLeft = Intervals[_currentIntervalIndex].TimeLeft;
			_currentIntervalName = Intervals[_currentIntervalIndex].Name;
			_nextIntervalName = (_currentIntervalIndex < Intervals.Count - 1) ? Intervals[_currentIntervalIndex + 1].Name : null;
			CurrentIntervalStarted(EventArgs.Empty);
			Intervals[_currentIntervalIndex].OnSecondElapsed += Interval_OnSecondElapsed;
			Intervals[_currentIntervalIndex].OnFinished += Interval_OnFinished;
			Intervals[_currentIntervalIndex].Start();

		}

		public void Stop()
		{
			_isTimerRunning = false;
			UnPause();
			_totalTimeLeft = new TimeSpan();
			Intervals.ForEach(timer => { timer.Stop(); timer.OnFinished -= Interval_OnFinished; timer.OnSecondElapsed -= Interval_OnSecondElapsed; });
			Stopped(EventArgs.Empty);
		}

		public void Pause()
		{
			//_isTimerRunning = false;
			if (Intervals.Any())
			{
				Intervals[_currentIntervalIndex].Pause();
			}

			_isPaused = true;
		}

		public void UnPause()
		{
			//_isTimerRunning = true;
			if (Intervals.Any())
			{
				Intervals[_currentIntervalIndex].UnPause();
			}

			_isPaused = false;
		}

		private void Interval_OnSecondElapsed(object sender, EventArgs e)
		{
			if (_isPaused == false)
			{
				_totalTimeLeft = _totalTimeLeft.Subtract(new TimeSpan(0, 0, 1));
				_currentTimerLeft = Intervals[_currentIntervalIndex].TimeLeft;
				SecondElapsed(EventArgs.Empty);
			}
		}

		private void Interval_OnStopped(object sender, EventArgs e)
		{
		}

		private void Interval_OnFinished(object sender, EventArgs e)
		{
			StopFinishedCurrentInterval();
			_currentIntervalIndex++;

			if (_currentIntervalIndex < Intervals.Count)
			{
				StartCurrentInterval();
			}
			else
			{
				_isTimerRunning = false;
				Intervals.ForEach(timer => { timer.Stop(); timer.OnFinished -= Interval_OnFinished; timer.OnSecondElapsed -= Interval_OnSecondElapsed; });
				Finished(EventArgs.Empty);
			}
		}
	}
}
