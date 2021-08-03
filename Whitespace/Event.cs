using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Whitespace
{
    public class Event
    {
		public Event(string eventTitle)
		{
			if(eventTitle.Length < 3)
            {
				throw new ArgumentException("EventTitle must contain at least 3 chars: 1_3 : 'A 5'.");
			}

			// parse embedded digits from string "Proper Unit Tests for Anyone 60min"
			Match minutes = Regex.Match(eventTitle, @"\d+");

			if (minutes.Success)
			{
				int minutesInt = Convert.ToInt32(minutes.Value);
				if (minutesInt <= 0)
				{
					throw new ArgumentException("Event duration must be at least 1 minute");
				}
				this.Duration = new TimeSpan(0, minutesInt, 0);
			}
			else
			{ 
				// no digit extracted check for lightning
				Match lightning = Regex.Match(eventTitle, @"lightning$", RegexOptions.IgnoreCase);
				if (lightning.Success)
				{
					this.Duration = new TimeSpan(0, 5, 0);
				}
				else
                {
					throw new ArgumentException("Unable to parse Event duration from input string: " + eventTitle);
                }
			}

			Title = eventTitle;
		}

		public TimeSpan Duration { get; private set; }
		public int DurationMins { get { return (int)Duration.TotalMinutes; } }
		public DateTime? EndTime { get; set; }
		public DateTime? StartTime { get; set; }
		public string StartTimeString 
		{ 
			get 
			{ 
				// force culture for consistent output
				return StartTime.HasValue ? StartTime.Value.ToString("t", new CultureInfo("en-US")) : string.Empty; 
			} 
		}
		public string EndTimeString
		{
			get
			{
				return EndTime.HasValue ? EndTime.Value.ToString("t", new CultureInfo("en-US")) : string.Empty;
			}
		}
		public string Title { get; private set; }
	}
}
