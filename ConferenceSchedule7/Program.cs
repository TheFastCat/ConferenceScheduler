using Autofac;
using System;
using System.Collections.Generic;
using Whitespace;

namespace ConferenceSchedule7
{
    class Program
    {
        static List<string> _eventsInput = new()
        {
            { "Proper Unit Tests for Anyone 60min" },
            { "Why Python ? 45min" },
            { "TDD for Embedded Systems 30min" },
            { "Dependency Management with Interpreted languages 45min" }
        };

        static Program()
        {
            _eventsInput.ForEach(str => _events.Add(new Event(str)));

            var builder = new ContainerBuilder();
            builder.RegisterType<TrackFactory>().As<ITrackFactory>();
            builder.RegisterType<SessionFactory>().As<ISessionFactory>();
            builder.RegisterType<EventListFacadeFactory>().As<IEventListFacadeFactory>();
            builder.RegisterType<RoundRobinTrackScheduler>().Named<ITrackScheduler>("roundRobin");
            builder.RegisterType<TrackSchedulePrinter>().As<ITrackSchedulePrinter>();
            Container = builder.Build();
        }

        private static List<Event> _events = new();
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            using var scope = Container.BeginLifetimeScope();
            var eventScheduler = scope.ResolveNamed<ITrackScheduler>("roundRobin");
            IEnumerable<ITrack> scheduledEvents1 = eventScheduler.Schedule(_events);
            string scheduledEvents1string = eventScheduler.Print(scheduledEvents1);

            Console.WriteLine(scheduledEvents1string);
            Console.ReadLine();
        }
    }
}
