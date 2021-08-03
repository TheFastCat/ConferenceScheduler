using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public abstract class TrackScheduler
    {
        protected readonly DateTime _morningStartTime = DateTime.Now.Date.AddHours(9);
        protected readonly DateTime _morningEndTime = DateTime.Now.Date.AddHours(12);
        protected readonly DateTime _afternoonStartTime = DateTime.Now.Date.AddHours(13);
        protected readonly DateTime _afternoonEndTime = DateTime.Now.Date.AddHours(17);

        protected IEventListFacadeFactory _eventListFacadeFactory;
        protected ITrackFactory _trackFactory;
        protected ITrackSchedulePrinter _trackSchedulePrinter;

        protected Queue<ITrack> _trackQueue;
        protected IEventListFacade _eventListFacade;

        protected virtual void Initialize(List<Event> eventList)
        {
            _eventListFacade = _eventListFacadeFactory.Create(eventList);
            int tracksRequired = _eventListFacade.TracksRequiredToSchedule((int)new TimeSpan(7, 0, 0).TotalMinutes);
            _trackQueue = new(tracksRequired);

            for (int i = 1; i <= tracksRequired; ++i)
            {
                ITrack track = _trackFactory.Create(string.Format("Track{0}", i), _morningStartTime, _morningEndTime, _afternoonStartTime, _afternoonEndTime);
                _trackQueue.Enqueue(track);
            }
        }

        /*
        protected virtual void FitRequiredEvents()
        {
            Event lunch = new("Lunch 60min");
            lunch.StartTime = DateTime.Today.AddHours(12);

            // Schedule Lunch as needed
            // Schedule Networking as needed
            foreach (Track track in _trackQueue)
            {
                track.MorningSession.ForceEventScheduleAtTime(lunch, true);
                track.AfternoonSession.ScheduleEvent(new Event("Networking Event 60min"), true);
            }
        }
        */

        protected virtual void FitRequiredEvents()
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

        public string Print(IEnumerable<ITrack> tracks)
        {
            return _trackSchedulePrinter.Print(tracks);
        }
    }
}
