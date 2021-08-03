using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Whitespace
{
    public class TrackSchedulePrinter : ITrackSchedulePrinter
    {
        public string Print(IEnumerable<ITrack> tracks)
        {
            StringBuilder sb = new();

            foreach (Track track in tracks)
            {
                sb.AppendLine(PrintTrack(track));
            }

            return sb.ToString();
        }

        private static string PrintTrack(ITrack track)
        {
            StringBuilder sb = new();
            sb.AppendLine(track.Identifier);
            sb.Append(PrintSession(track.MorningSession));
            sb.AppendLine(PrintSession(track.AfternoonSession));
            return sb.ToString();
        }

        private static string PrintSession(ISession session)
        {
            StringBuilder sb = new();
            session.ScheduledEvents.ForEach(evnt => sb.AppendFormat("\t{0} {1}\n", evnt.StartTimeString, evnt.Title));
            return sb.ToString();
        }
    }
}
