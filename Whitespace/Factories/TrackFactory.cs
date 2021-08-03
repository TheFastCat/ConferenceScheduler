using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public class TrackFactory : ITrackFactory
    {
        readonly ISessionFactory _sessionFactory;

        public TrackFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public ITrack Create(string title, 
            DateTime morningStartTime,
            DateTime morningEndTime,
            DateTime afternoonStartTime,
            DateTime afternoonEndTime)
        {
            return new Track(_sessionFactory, title, morningStartTime, morningEndTime, afternoonStartTime, afternoonEndTime);
        }
    }
}
