using System;
using System.Collections.Generic;
using TimeMage.Shared;

namespace TimeMage.ComponentsLibrary
{
	public static class PreloadedIntervalSets
	{
		public static List<IntervalSet> IntervalSets { get; set; } = new List<IntervalSet>
		{
			new IntervalSet
			{
				Name = "Fat Burn",
				GuideUrl = "https://youtu.be/9boaIRTLnns",
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
			},
			new IntervalSet
			{
				Name = "Ten Minute Ab Workout",
				GuideUrl = "https://youtu.be/i27K2ry9jEo",
				Intervals = new List<TmTimer>
				{
					new TmTimer{ Name = "Crescent Tucks", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Backwards 7's", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Swipers", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Side Cycle Left", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Side Cycle Right", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Mountain Hip Dips", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Frog V-Ups", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Side Scissor Crunch Left", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Side Scissor Crunch Right", Time = TimeSpan.FromSeconds(45) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Corpse Crunch", Time = TimeSpan.FromSeconds(45) },
				}
			},
			new IntervalSet
			{
				Name = "Ten Minute Chest Workout",
				GuideUrl = "https://youtu.be/rxEMKXW2Wqs",
				Intervals = new List<TmTimer>
				{
					new TmTimer{ Name = "Plyo Release Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Plyo Release Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Plyo Release Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Plyo Release Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },

					new TmTimer{ Name = "Prowler Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Prowler Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Prowler Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Prowler Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },

					new TmTimer{ Name = "Decline Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Decline Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Decline Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Decline Pushup", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },

					new TmTimer{ Name = "Lateral Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Lateral Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Lateral Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Lateral Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },

					new TmTimer{ Name = "Shoulder Tap Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Shoulder Tap Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Shoulder Tap Pushups", Time = TimeSpan.FromSeconds(10) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Shoulder Tap Pushups", Time = TimeSpan.FromSeconds(10) },
				}
			},
			new IntervalSet
			{
				Name = "Door",
				GuideUrl = "https://youtu.be/Ae81rtoBpOw",
				Intervals = new List<TmTimer>
				{
					new TmTimer{ Name = "Door Face Pull", Time = TimeSpan.FromSeconds(30) },
					new TmTimer{ Name = "Door Hold", Time = TimeSpan.FromSeconds(30) },
				}
			},
			new IntervalSet
			{
				Name = "Dips/Pullups",
				Intervals = new List<TmTimer>
				{
					new TmTimer{ Name = "Dips", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Dips", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Dips", Time = TimeSpan.FromSeconds(15) },

					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },

					new TmTimer{ Name = "Pull Ups", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Pull Ups", Time = TimeSpan.FromSeconds(15) },
					new TmTimer{ Name = "Rest", Time = TimeSpan.FromSeconds(20) },
					new TmTimer{ Name = "Pull Ups", Time = TimeSpan.FromSeconds(15) },
				}
			}
		};
	}
}
