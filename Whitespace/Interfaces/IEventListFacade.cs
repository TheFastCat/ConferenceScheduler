using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public interface IEventListFacade
    {
        List<int> DistintDurations { get; }
        Dictionary<int, Queue<Event>> DurationEventDictionary { get; }
        int EventCount { get; }
        List<Event> Events { get; }
        TimeSpan MaxDuration { get; }
        int MaxDurationMins { get; }
        TimeSpan MinDuration { get; }
        int MinDurationMins { get; }
        TimeSpan TotalDuration { get; }
        int TotalDurationMins { get; }

        int CountForDuration(int durationMins);
        int CountForDuration(TimeSpan duration);
        bool ExistsWithDuration(int durationMins);
        bool ExistsWithDuration(TimeSpan duration);
        TimeSpan MaxDurationForAvailable(TimeSpan duration);
        int MaxDurationForCeilingMins(int availableDurationMins);
        Event PopForDuration(int durationMins);
        Event PopForDuration(TimeSpan duration);
        Event PopMaxDuration();
        Event PopMinDuration();
        int TracksRequiredToSchedule(int trackDurationMins);
    }
}
