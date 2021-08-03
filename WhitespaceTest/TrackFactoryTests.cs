using System;
using Xunit;
using Whitespace;

namespace WhitespaceTest
{
    public class TrackFactoryTests : TestBase
    {
        [Fact]
        public void Create()
        {
            ISessionFactory sessionFactory = new SessionFactory();
            TrackFactory trackFactory = new(sessionFactory);
            ITrack track = trackFactory.Create("Track1", _morningStartTime, _morningEndTime, _afternoonStartTime, _afternoonEndTime);
            Assert.Equal("Track1", track.Identifier);
            Assert.Equal(_morningStartTime, track.MorningSession.StartTime);
            Assert.Equal(_morningEndTime, track.MorningSession.EndTime);
            Assert.Equal(_afternoonStartTime, track.AfternoonSession.StartTime);
            Assert.Equal(_afternoonEndTime, track.AfternoonSession.EndTime);
            Assert.Equal(_morningEndTime.Subtract(_morningStartTime), track.MorningAvailableCapacity);
            Assert.Equal(_afternoonEndTime.Subtract(_afternoonStartTime), track.AfternoonAvailableCapacity);
            Assert.Equal(_0mins, track.ScheduledCapacity);
        }
    }
}
