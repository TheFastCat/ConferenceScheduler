using System;
using System.Collections.Generic;
using System.Linq;

namespace Whitespace
{
    public class RoundRobinTrackScheduler : TrackScheduler, ITrackScheduler
    {
        public RoundRobinTrackScheduler(IEventListFacadeFactory eventListFacadeFactory, 
            ITrackFactory trackFactory,
            ITrackSchedulePrinter trackSchedulePrinter)
        {        
            _trackFactory = trackFactory;
            _eventListFacadeFactory = eventListFacadeFactory;
            _trackSchedulePrinter = trackSchedulePrinter;
        }

        public IEnumerable<ITrack> Schedule(List<Event> eventList)
        {
            Initialize(eventList);

            // schedule longest duration Event for availability;
            // schedule Events round-robin across tracks (prefer mornings) until none remain
            while (_eventListFacade.EventCount > 0)
            {
                ITrack workingTrack = _trackQueue.Dequeue();

                int maxDurationForCeiling = _eventListFacade.MaxDurationForCeilingMins(workingTrack.MaxAvailableCapacityMins);

                if (maxDurationForCeiling > 0)
                    workingTrack.ScheduleEventMostCapacityOrMorningFirst(_eventListFacade.PopForDuration(maxDurationForCeiling));

                _trackQueue.Enqueue(workingTrack);
            }

            FitRequiredEvents();

            return _trackQueue.OrderBy(track => track.Identifier);
        }
    }
}
