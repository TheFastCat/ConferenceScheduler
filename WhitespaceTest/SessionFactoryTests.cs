using Xunit;
using Whitespace;

namespace WhitespaceTest
{
    public class SessionFactoryTests : TestBase
    {
        [Fact]
        public void Create()
        {
            SessionFactory sessionFactory = new();
            ISession morningSession = sessionFactory.Create(_morningStartTime, _morningEndTime);
            Assert.Equal(_morningStartTime, morningSession.StartTime);
            Assert.Equal(_morningEndTime, morningSession.EndTime);
            Assert.Equal(_0mins, morningSession.ScheduledCapacity);

            ISession afternoonSession = sessionFactory.Create(_afternoonStartTime, _afternoonEndTime);
            Assert.Equal(_afternoonStartTime, afternoonSession.StartTime);
            Assert.Equal(_afternoonEndTime, afternoonSession.EndTime);
            Assert.Equal(_0mins, afternoonSession.ScheduledCapacity);
        }
    }
}
