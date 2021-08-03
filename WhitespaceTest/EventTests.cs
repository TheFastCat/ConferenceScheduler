using System;
using Xunit;
using Whitespace;
using System.Linq;
using System.Collections.Generic;

namespace WhitespaceTest
{
    public class EventTests : TestBase
    {
        [Fact]
        public void Constructor1()
        {
            foreach (KeyValuePair<string, int> pair in _eventsInput1)
            {
                Event evnt = new(pair.Key);
                Assert.Equal(pair.Key, evnt.Title);
                Assert.Equal(new TimeSpan(0, pair.Value, 0), evnt.Duration);
                Assert.Equal(new TimeSpan(0, pair.Value, 0).TotalMinutes, evnt.DurationMins);
                Assert.Null(evnt.StartTime);
                Assert.Null(evnt.EndTime);
            }

            foreach (KeyValuePair<string, int> pair in _eventsInput2)
            {
                Event evnt = new(pair.Key);
                Assert.Equal(pair.Key, evnt.Title);
                Assert.Equal(new TimeSpan(0, pair.Value, 0), evnt.Duration);
                Assert.Equal(new TimeSpan(0, pair.Value, 0).TotalMinutes, evnt.DurationMins);
                Assert.Null(evnt.StartTime);
                Assert.Null(evnt.EndTime);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("C")]
        [InlineData("5")]
        [InlineData("C5")]
        public void ThrowsExceptionGivenInvalidTitle(string eventTitle)
        {
            var caughtException = Assert.Throws<ArgumentException>(() => new Event(eventTitle));
            Assert.Equal("EventTitle must contain at least 3 chars: 1_3 : 'A 5'.", caughtException.Message);
        }

        [Theory]
        [InlineData("C mins")]
        [InlineData("C fifteenmins")]
        [InlineData("Description")]
        public void ThrowsExceptionGivenMissingDuration(string eventTitle)
        {
            var caughtException = Assert.Throws<ArgumentException>(() => new Event(eventTitle));
            Assert.Equal("Unable to parse Event duration from input string: " + eventTitle, caughtException.Message);
        }

        [Theory]
        [InlineData("C 0mins")]
        public void ThrowsExceptionGivenZeroDuration(string eventTitle)
        {
            var caughtException = Assert.Throws<ArgumentException>(() => new Event(eventTitle));
            Assert.Equal("Event duration must be at least 1 minute", caughtException.Message);
        }

        [Fact]
        public void StartTime()
        {
            DateTime nineAM = DateTime.Now.Date.AddHours(9);
            _event30min.StartTime = nineAM;
            Assert.NotNull(_event30min.StartTime);
            Assert.Equal("9:00 AM", _event30min.StartTimeString);
        }

        [Fact]
        public void EndTime()
        {
            DateTime twelvePM = DateTime.Now.Date.AddHours(12);
            _event30min.EndTime = twelvePM;
            Assert.NotNull(_event30min.EndTime);
            Assert.Equal("12:00 PM", _event30min.EndTimeString);
        }

        [Fact]
        public void EventDuration1Min()
        {
            Assert.Equal(_1, _event1min.DurationMins);
            Assert.Equal(_1mins, _event1min.Duration);
        }

        [Fact]
        public void EventDurationLightning()
        {
            Assert.Equal(_5, _eventLightning.DurationMins);
            Assert.Equal(_5mins, _eventLightning.Duration);
        }

        [Fact]
        public void EventDuration60Min()
        {
            Assert.Equal(_60, _event60min.DurationMins);
            Assert.Equal(_60mins, _event60min.Duration);
        }

        [Fact]
        public void EventDuration180Min()
        {
            Assert.Equal(_180, _event180min.DurationMins);
            Assert.Equal(_180mins, _event180min.Duration);
        }
    }
}
