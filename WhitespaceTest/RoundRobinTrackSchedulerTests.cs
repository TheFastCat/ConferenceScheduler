using System.Collections.Generic;
using System.Linq;
using Xunit;
using Whitespace;
using Autofac;

namespace WhitespaceTest
{
    public class RoundRobinTrackSchedulerSchedulerTests : TestBase
    {
        [Fact]
        public void EachSessionContainsMultipleTalks()
        {
            using var scope = Container.BeginLifetimeScope();
            var eventScheduler = scope.ResolveNamed<ITrackScheduler>("roundRobin");
            IEnumerable<ITrack> scheduledTracks1 = eventScheduler.Schedule(_events1);
            IEnumerable<ITrack> scheduledTracks2 = eventScheduler.Schedule(_events2);
            IEnumerable<ITrack> scheduledTracks3 = eventScheduler.Schedule(_events3);
            IEnumerable<ITrack> scheduledTracks4 = eventScheduler.Schedule(_events4);
            IEnumerable<ITrack> scheduledTracks5 = eventScheduler.Schedule(_events5);
            EachSessionContainsMultipleTalks_(scheduledTracks1);
            EachSessionContainsMultipleTalks_(scheduledTracks2);
            EachSessionContainsMultipleTalks_(scheduledTracks3);
            EachSessionContainsMultipleTalks_(scheduledTracks4);
            EachSessionContainsMultipleTalks_(scheduledTracks5);
        }

        [Fact]
        public void MorningSessionsBeginAt9AMandFinishByNoon()
        {
            using var scope = Container.BeginLifetimeScope();
            var eventScheduler = scope.ResolveNamed<ITrackScheduler>("roundRobin");
            IEnumerable<ITrack> scheduledTracks1 = eventScheduler.Schedule(_events1);
            IEnumerable<ITrack> scheduledTracks2 = eventScheduler.Schedule(_events2);
            IEnumerable<ITrack> scheduledTracks3 = eventScheduler.Schedule(_events3);
            IEnumerable<ITrack> scheduledTracks4 = eventScheduler.Schedule(_events4);
            IEnumerable<ITrack> scheduledTracks5 = eventScheduler.Schedule(_events5);
            MorningSessionsBeginAt9AMandFinishByNoon_(scheduledTracks1);
            MorningSessionsBeginAt9AMandFinishByNoon_(scheduledTracks2);
            MorningSessionsBeginAt9AMandFinishByNoon_(scheduledTracks3);
            MorningSessionsBeginAt9AMandFinishByNoon_(scheduledTracks4);
            MorningSessionsBeginAt9AMandFinishByNoon_(scheduledTracks5);
        }

        [Fact]
        public void LunchIsBetweenNoonAnd1pm()
        {
            using var scope = Container.BeginLifetimeScope();
            var eventScheduler = scope.ResolveNamed<ITrackScheduler>("roundRobin");
            IEnumerable<ITrack> scheduledTracks1 = eventScheduler.Schedule(_events1);
            IEnumerable<ITrack> scheduledTracks2 = eventScheduler.Schedule(_events2);
            IEnumerable<ITrack> scheduledTracks3 = eventScheduler.Schedule(_events3);
            IEnumerable<ITrack> scheduledTracks4 = eventScheduler.Schedule(_events4);
            IEnumerable<ITrack> scheduledTracks5 = eventScheduler.Schedule(_events5);
            LunchIsBetweenNoonAnd1pm_(scheduledTracks1);
            LunchIsBetweenNoonAnd1pm_(scheduledTracks2);
            LunchIsBetweenNoonAnd1pm_(scheduledTracks3);
            LunchIsBetweenNoonAnd1pm_(scheduledTracks4);
            LunchIsBetweenNoonAnd1pm_(scheduledTracks5);
        }

        [Fact]
        public void NetworkingEventBetween4pmand5pm()
        {
            using var scope = Container.BeginLifetimeScope();
            var eventScheduler = scope.ResolveNamed<ITrackScheduler>("roundRobin");
            IEnumerable<ITrack> scheduledTracks1 = eventScheduler.Schedule(_events1);
            IEnumerable<ITrack> scheduledTracks2 = eventScheduler.Schedule(_events2);
            IEnumerable<ITrack> scheduledTracks3 = eventScheduler.Schedule(_events3);
            IEnumerable<ITrack> scheduledTracks4 = eventScheduler.Schedule(_events4);
            IEnumerable<ITrack> scheduledTracks5 = eventScheduler.Schedule(_events5);
            NetworkingEventBetween4pmand5pm_(scheduledTracks1);
            NetworkingEventBetween4pmand5pm_(scheduledTracks2);
            NetworkingEventBetween4pmand5pm_(scheduledTracks3);
            NetworkingEventBetween4pmand5pm_(scheduledTracks4);
            NetworkingEventBetween4pmand5pm_(scheduledTracks5);
        }

        [Fact]
        public void NoGapsBetweenSessions()
        {
            using var scope = Container.BeginLifetimeScope();
            var eventScheduler = scope.ResolveNamed<ITrackScheduler>("roundRobin");
            IEnumerable<ITrack> scheduledTracks1 = eventScheduler.Schedule(_events1);
            IEnumerable<ITrack> scheduledTracks2 = eventScheduler.Schedule(_events2);
            IEnumerable<ITrack> scheduledTracks3 = eventScheduler.Schedule(_events3);
            IEnumerable<ITrack> scheduledTracks4 = eventScheduler.Schedule(_events4);
            IEnumerable<ITrack> scheduledTracks5 = eventScheduler.Schedule(_events5);
            NoGapsBetweenSessions_(scheduledTracks1);
            NoGapsBetweenSessions_(scheduledTracks2);
            NoGapsBetweenSessions_(scheduledTracks3);
            NoGapsBetweenSessions_(scheduledTracks4);
            NoGapsBetweenSessions_(scheduledTracks5);
        }
    }
}
