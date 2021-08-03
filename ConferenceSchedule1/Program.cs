using Autofac;
using System;
using System.Collections.Generic;
using Whitespace;

namespace ConferenceSchedule1
{
    class Program
    {
        static List<string> _eventsInput = new()
        {
            { "Proper Unit Tests for Anyone 60min" },
            { "Why Python ? 45min" },
            { "TDD for Embedded Systems 30min" },
            { "Dependency Management with Interpreted languages 45min" },
            { "Java, really end of life 45min" },
            { "From Java to Java lightning" },
            { "Managing Network Latency 60min" },
            { "BDD Gone Mad 45min" },
            { "Do you smell that ? (Code Smells) 30min" },
            { "Open Office Space or Closets ???? 30min" },
            { "Proper Pairing 45min" },
            { "Spring JuJu 60min" },
            { "Effective DSL(Domain Specific Languages) 60min" },
            { "Clojure... What Happened(on my project) 45min" },
            { "Effective Legacy Code Techniques... 30min" },
            { "Backends and FrontEnds in JavaScript ? 30min" },
            { "CD on the Mainframe 60min" },
            { "Making Windows Development Enjoyable... 30min" },
            { "Modern Build Systems 30min" }
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
