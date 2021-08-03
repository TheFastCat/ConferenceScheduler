using System;
using System.Collections.Generic;
using System.Linq;

namespace Whitespace
{
    public class DeepTrackScheduler : TrackScheduler, ITrackScheduler
    {
        public DeepTrackScheduler(IEventListFacadeFactory eventListFacadeFactory, 
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

            // schedule longest duration Events for availability;
            // try to fill a Track before scheduling others until unable, or no Events remain
            while (_eventListFacade.EventCount > 0)
            {
                ITrack workingTrack = _trackQueue.Dequeue();

                for(int maxDurationForCeiling = _eventListFacade.MaxDurationForCeilingMins(workingTrack.MaxAvailableCapacityMins); 
                    maxDurationForCeiling > 0;
                    maxDurationForCeiling = _eventListFacade.MaxDurationForCeilingMins(workingTrack.MaxAvailableCapacityMins))
                {
                    workingTrack.ScheduleEventBalancedCountFirst(_eventListFacade.PopForDuration(maxDurationForCeiling));

                    // assure last Track's sessions contains multiple Events as per requirement
                    if (_eventListFacade.EventCount == 4)
                        break;
                }

                _trackQueue.Enqueue(workingTrack);
            }

            FitRequiredEvents();

            return _trackQueue.OrderBy(track => track.Identifier);
        }

        /*
        protected override void FitRequiredEvents()
        {
            Event lunch = new("Lunch 60min");
            lunch.StartTime = DateTime.Today.AddHours(12);

            // Schedule Lunch as needed
            // Schedule Networking as needed
            foreach (Track track in _trackQueue)
            {
                track.MorningSession.ForceEventScheduleAtTime(lunch, true);

                // if networking doesn't align with constraints -- make it
                if (track.AfternoonSession.NextNextAvailableStartTime < _afternoonEndTime.Subtract(new TimeSpan(1, 0, 0)))
                {
                    Event networking = new("Networking Event 60min");
                    networking.StartTime = DateTime.Today.AddHours(16);
                    track.AfternoonSession.ForceEventScheduleAtTime(networking, true);
                }
                else
                {
                    track.AfternoonSession.ScheduleEvent(new Event("Networking Event 60min"), true);
                }
            }
        }
        */
    }
}
