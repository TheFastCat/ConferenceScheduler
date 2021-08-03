using System;
using System.Linq;
using System.Collections.Generic;
using Autofac;
using Whitespace;
using Xunit;

namespace WhitespaceTest
{
    public class TestBase
    {
        protected readonly Dictionary<string, int> _eventsInput1 = new()
            {
                { "Proper Unit Tests for Anyone 60min", 60 },
                { "Why Python ? 45min", 45 },
                { "TDD for Embedded Systems 30min", 30 },
                { "Dependency Management with Interpreted languages 45min", 45 },
                { "Java, really end of life 45min", 45 },
                { "From Java to Java lightning", 5 },
                { "Managing Network Latency 60min", 60 },
                { "BDD Gone Mad 45min", 45 },
                { "Do you smell that ? (Code Smells) 30min", 30 },
                { "Open Office Space or Closets ???? 30min", 30 },
                { "Proper Pairing 45min", 45 },
                { "Spring JuJu 60min", 60 },
                { "Effective DSL(Domain Specific Languages) 60min", 60 },
                { "Clojure... What Happened(on my project) 45min", 45 },
                { "Effective Legacy Code Techniques... 30min", 30 },
                { "Backends and FrontEnds in JavaScript ? 30min", 30 },
                { "CD on the Mainframe 60min", 60 },
                { "Making Windows Development Enjoyable... 30min", 30 },
                { "Modern Build Systems 30min", 30 }
            };
        protected readonly Dictionary<string, int> _eventsInput2 = new()
            {
                { "Proper Unit Tests for Anyone 60min", 60 },
                { "Why Python ? 45min", 45 },
                { "TDD for Embedded Systems 30min", 30 },
                { "Dependency Management with Interpreted languages 45min", 45 },
                { "Java, really end of life 45min", 45 },
                { "From Java to Java lightning", 5 },
                { "Managing Network Latency 60min", 60 },
                { "BDD Gone Mad 45min", 45 },
                { "Do you smell that ? (Code Smells) 30min", 30 },
                { "Open Office Space or Closets ???? 30min", 30 },
                { "Proper Pairing 45min", 45 },
                { "Spring JuJu 60min", 60 },
                { "Effective DSL(Domain Specific Languages) 60min", 60 },
                { "Clojure... What Happened(on my project) 45min", 45 },
                { "Effective Legacy Code Techniques... 30min", 30 },
                { "Backends and FrontEnds in JavaScript ? 30min", 30 },
                { "CD on the Mainframe 60min", 60 },
                { "Making Windows Development Enjoyable... 30min", 30 },
                { "Modern Build Systems 30min", 30 },

                { "TDD 120min", 120 },
                { "BDD 120min", 120 },
                { "Law of Demeter and U 30min", 30 },
                { "Trendy Tech Acronyms 45min", 45 },
                { "RU leet enough? 45min", 45 },
                { "Impressing others by Blogging lightning", 5 },
                { "Twitter Burns You Can Use lightning", 5 },
                { "How to Get A Girlfriend lightning", 5 },
                { "Funny things About Frogs lightning", 5 },
                { "The Next Coolest JS Framework lightning", 5 },
                { "Debugging for Fun and Profit 60min", 60 },
                { "Amusing T-Shirt Design Contest 45min", 45 },
                { "Coffee Curation for Nerds 30min", 30 },
                { "Is Your Code Woke Enough? 30min", 30 },
                { "Mega Extreme Extreme Programming  45min", 45 },
                { "Circle the Bandwagons 60min", 60 },
                { "Stack Overflow 60min", 60 },
                { "Spreadsheets 45min", 45 },
                { "Refactoring 30min", 30 },
                { "System Design 30min", 30 },
                { "Cloud Architecture Patterns 60min", 60 },
                { "Wintermute 30min", 30 },
                { "Technolycanthropy 30min", 30 }
            };
        protected readonly List<string> _eventsInput3 = new()
            {
                { "Proper Unit Tests for Anyone 60min"},
                { "Why Python ? 45min"},
                { "TDD for Embedded Systems 30min"},
                { "Dependency Management with Interpreted languages 45min"},
                { "Java, really end of life 45min"},
                { "From Java to Java lightning"},
                { "Managing Network Latency 60min"},
                { "BDD Gone Mad 45min"},
                { "Do you smell that ? (Code Smells) 30min"},
                { "Open Office Space or Closets ???? 30min"},
                { "Proper Pairing 45min"},
                { "Spring JuJu 60min"},
                { "Effective DSL(Domain Specific Languages) 60min"},
                { "Clojure... What Happened(on my project) 45min"},
                { "Effective Legacy Code Techniques... 30min"},
                { "Backends and FrontEnds in JavaScript ? 30min"},
                { "CD on the Mainframe 60min"},
                { "Making Windows Development Enjoyable... 30min"},
                { "Modern Build Systems 30min"},

                { "TDD 120min" },
                { "BDD 120min"},
                { "Law of Demeter and U 30min"},
                { "Trendy Tech Acronyms 45min"},
                { "RU leet enough? 45min"},
                { "Impressing others by Blogging lightning"},
                { "Twitter Burns You Can Use lightning"},
                { "How to Get A Girlfriend lightning"},
                { "Funny things About Frogs lightning"},
                { "The Next Coolest JS Framework lightning"},
                { "Debugging for Fun and Profit 60min"},
                { "Amusing T-Shirt Design Contest 45min"},
                { "Coffee Curation for Nerds 30min"},
                { "Is Your Code Woke Enough? 30min"},
                { "Mega Extreme Extreme Programming  45min"},
                { "Circle the Bandwagons 60min"},
                { "Stack Overflow 60min"},
                { "Spreadsheets 45min"},
                { "Refactoring 30min"},
                { "System Design 30min"},
                { "Cloud Architecture Patterns 60min"},
                { "Wintermute 30min"},
                { "Technolycanthropy 30min"},

                { "Proper Unit Tests for Anyone 60min"},
                { "Why Python ? 45min"},
                { "TDD for Embedded Systems 30min"},
                { "Dependency Management with Interpreted languages 45min"},
                { "Java, really end of life 45min"},
                { "From Java to Java lightning"},
                { "Managing Network Latency 60min"},
                { "BDD Gone Mad 45min"},
                { "Do you smell that ? (Code Smells) 30min"},
                { "Open Office Space or Closets ???? 30min"},
                { "Proper Pairing 45min"},
                { "Spring JuJu 60min"},
                { "Effective DSL(Domain Specific Languages) 60min"},
                { "Clojure... What Happened(on my project) 45min"},
                { "Effective Legacy Code Techniques... 30min"},
                { "Backends and FrontEnds in JavaScript ? 30min"},
                { "CD on the Mainframe 60min"},
                { "Making Windows Development Enjoyable... 30min"},
                { "Modern Build Systems 30min"},

                { "TDD 120min" },
                { "BDD 120min"},
                { "Law of Demeter and U 30min"},
                { "Trendy Tech Acronyms 45min"},
                { "RU leet enough? 45min"},
                { "Impressing others by Blogging lightning"},
                { "Twitter Burns You Can Use lightning"},
                { "How to Get A Girlfriend lightning"},
                { "Funny things About Frogs lightning"},
                { "The Next Coolest JS Framework lightning"},
                { "Debugging for Fun and Profit 60min"},
                { "Amusing T-Shirt Design Contest 45min"},
                { "Coffee Curation for Nerds 30min"},
                { "Is Your Code Woke Enough? 30min"},
                { "Mega Extreme Extreme Programming  45min"},
                { "Circle the Bandwagons 60min"},
                { "Stack Overflow 60min"},
                { "Spreadsheets 45min"},
                { "Refactoring 30min"},
                { "System Design 30min"},
                { "Cloud Architecture Patterns 60min"},
                { "Wintermute 30min"},
                { "Technolycanthropy 30min"}
            };
        protected readonly List<string> _eventsInput4 = new()
        {
            { "Proper Unit Tests for Anyone 60min"},
            { "Why Python ? 45min" },
            { "TDD for Embedded Systems 30min"},
            { "Dependency Management with Interpreted languages 45min" }
        };
        protected readonly List<string> _eventsInput5 = new()
        {
            { "Proper Unit Tests for Anyone 1min" },
            { "Why Python ? 2min" },
            { "TDD for Embedded Systems 3min" },
            { "Dependency Management with Interpreted languages 4min" },
            { "Java, really end of life 5min" },
            { "From Java to Java lightning" },
            { "Managing Network Latency 6min" },
            { "BDD Gone Mad 7min" },
            { "Do you smell that ? (Code Smells) 8min" },
            { "Open Office Space or Closets ???? 9min" },
            { "Proper Pairing 10min" },
            { "Spring JuJu 11min" },
            { "Effective DSL(Domain Specific Languages) 12min" },
            { "Clojure... What Happened(on my project) 13min" },
            { "Effective Legacy Code Techniques... 14min" },
            { "Backends and FrontEnds in JavaScript ? 15min" },
            { "CD on the Mainframe 16min" },
            { "Making Windows Development Enjoyable... 17min" },
            { "Modern Build Systems 18min" },

            { "TDD 19min" },
            { "BDD 20min" },
            { "Law of Demeter and U 21min" },
            { "Trendy Tech Acronyms 22min" },
            { "RU leet enough? 23min" },
            { "Impressing others by Blogging lightning" },
            { "Twitter Burns You Can Use lightning" },
            { "How to Get A Girlfriend lightning" },
            { "Funny things About Frogs lightning" },
            { "The Next Coolest JS Framework lightning" },
            { "Debugging for Fun and Profit 24min" },
            { "Amusing T-Shirt Design Contest 25min" },
            { "Coffee Curation for Nerds 26min" },
            { "Is Your Code Woke Enough? 27min" },
            { "Mega Extreme Extreme Programming  28min" },
            { "Circle the Bandwagons 29min" },
            { "Stack Overflow 30min" },
            { "Spreadsheets 31min" },
            { "Refactoring 32min" },
            { "System Design 33min" },
            { "Cloud Architecture Patterns 34min" },
            { "Wintermute 35min" },
            { "Technolycanthropy 36min" },

            { "Open source: how to work for free 37min" },
            { "EndDowns: The new Startups 38m" },
            { "Instagram Filters to Make You look Like a Leader 39min" },
            { "Be Heard : Why Listen When You can Talk? 40min" },
            { "Modern History: Revisiting Obselete Tech from Two Years Ago 41min" },
            { "Raising your Children From Inside a Cubicle lightning" },
            { "Power Moves: Thumb Exercises to Type Faster on Mobile Devices 42min" },
            { "Round-Table: Stare at your Eletronic Device With Others for 43min" },
            { "Pokemon Tournament 44min" },
            { "Tips For Appearing Productive 45min" },
            { "Hyper-Coding : The Next Neologism! 46min" },
            { "[Interactive Display] Ferris Wheel of Tech-Churn (Child-Friendly Event) 47min" },
            { "Bio-Hack your BMI 48min" },
            { "Social Networks for Unsocial People 49min" },
            { "Powering Hacking for 10xers Who Are Rockstars 50min" },
            { "[Interactive Display] Mechanical Keyboard Noise-making Symphony 51min" },
            { "Electronic Communications In a World of Humans 52min" },
            { "Duct-Tape it! How To Kick The Can a few Years Down the Road for Someone Else to Deal With 53min" },
            { "Listen to My Talk So I Can take a Photo for my LinkedIn Profile 54min" },

            { "Proper Unit Tests for Anyone 1min" },
            { "Why Python ? 2min" },
            { "TDD for Embedded Systems 3min" },
            { "Dependency Management with Interpreted languages 4min" },
            { "Java, really end of life 5min" },
            { "From Java to Java lightning" },
            { "Managing Network Latency 6min" },
            { "BDD Gone Mad 7min" },
            { "Do you smell that ? (Code Smells) 8min" },
            { "Open Office Space or Closets ???? 9min" },
            { "Proper Pairing 10min" },
            { "Spring JuJu 11min" },
            { "Effective DSL(Domain Specific Languages) 12min" },
            { "Clojure... What Happened(on my project) 13min" },
            { "Effective Legacy Code Techniques... 14min" },
            { "Backends and FrontEnds in JavaScript ? 15min" },
            { "CD on the Mainframe 16min" },
            { "Making Windows Development Enjoyable... 17min" },
            { "Modern Build Systems 18min" },

            { "TDD 19min" },
            { "BDD 20min" },
            { "Law of Demeter and U 21min" },
            { "Trendy Tech Acronyms 22min" },
            { "RU leet enough? 23min" },
            { "Impressing others by Blogging lightning" },
            { "Twitter Burns You Can Use lightning" },
            { "How to Get A Girlfriend lightning" },
            { "Funny things About Frogs lightning" },
            { "The Next Coolest JS Framework lightning" },
            { "Debugging for Fun and Profit 24min" },
            { "Amusing T-Shirt Design Contest 25min" },
            { "Coffee Curation for Nerds 26min" },
            { "Is Your Code Woke Enough? 27min" },
            { "Mega Extreme Extreme Programming  28min" },
            { "Circle the Bandwagons 29min" },
            { "Stack Overflow 30min" },
            { "Spreadsheets 31min" },
            { "Refactoring 32min" },
            { "System Design 33min" },
            { "Cloud Architecture Patterns 34min" },
            { "Wintermute 35min" },
            { "Technolycanthropy 36min" },

            { "Open source: how to work for free 37min" },
            { "EndDowns: The new Startups 38m" },
            { "Instagram Filters to Make You look Like a Leader 39min" },
            { "Be Heard : Why Listen When You can Talk? 40min" },
            { "Modern History: Revisiting Obselete Tech from Two Years Ago 41min" },
            { "Raising your Children From Inside a Cubicle lightning" },
            { "Power Moves: Thumb Exercises to Type Faster on Mobile Devices 42min" },
            { "Round-Table: Stare at your Eletronic Device With Others for 43min" },
            { "Pokemon Tournament 44min" },
            { "Tips For Appearing Productive 45min" },
            { "Hyper-Coding : The Next Neologism! 46min" },
            { "[Interactive Display] Ferris Wheel of Tech-Churn (Child-Friendly Event) 47min" },
            { "Bio-Hack your BMI 48min" },
            { "Social Networks for Unsocial People 49min" },
            { "Powering Hacking for 10xers Who Are Rockstars 50min" },
            { "[Interactive Display] Mechanical Keyboard Noise-making Symphony 51min" },
            { "Electronic Communications In a World of Humans 52min" },
            { "Duct-Tape it! How To Kick The Can a few Years Down the Road for Someone Else to Deal With 53min" },
            { "Listen to My Talk So I Can take a Photo for my LinkedIn Profile 54min" },

            { "Proper Unit Tests for Anyone 1min" },
            { "Why Python ? 2min" },
            { "TDD for Embedded Systems 3min" },
            { "Dependency Management with Interpreted languages 4min" },
            { "Java, really end of life 5min" },
            { "From Java to Java lightning" },
            { "Managing Network Latency 6min" },
            { "BDD Gone Mad 7min" },
            { "Do you smell that ? (Code Smells) 8min" },
            { "Open Office Space or Closets ???? 9min" },
            { "Proper Pairing 10min" },
            { "Spring JuJu 11min" },
            { "Effective DSL(Domain Specific Languages) 12min" },
            { "Clojure... What Happened(on my project) 13min" },
            { "Effective Legacy Code Techniques... 14min" },
            { "Backends and FrontEnds in JavaScript ? 15min" },
            { "CD on the Mainframe 16min" },
            { "Making Windows Development Enjoyable... 17min" },
            { "Modern Build Systems 18min" },

            { "TDD 19min" },
            { "BDD 20min" },
            { "Law of Demeter and U 21min" },
            { "Trendy Tech Acronyms 22min" },
            { "RU leet enough? 23min" },
            { "Impressing others by Blogging lightning" },
            { "Twitter Burns You Can Use lightning" },
            { "How to Get A Girlfriend lightning" },
            { "Funny things About Frogs lightning" },
            { "The Next Coolest JS Framework lightning" },
            { "Debugging for Fun and Profit 24min" },
            { "Amusing T-Shirt Design Contest 25min" },
            { "Coffee Curation for Nerds 26min" },
            { "Is Your Code Woke Enough? 27min" },
            { "Mega Extreme Extreme Programming  28min" },
            { "Circle the Bandwagons 29min" },
            { "Stack Overflow 30min" },
            { "Spreadsheets 31min" },
            { "Refactoring 32min" },
            { "System Design 33min" },
            { "Cloud Architecture Patterns 34min" },
            { "Wintermute 35min" },
            { "Technolycanthropy 36min" },

            { "Open source: how to work for free 37min" },
            { "EndDowns: The new Startups 38m" },
            { "Instagram Filters to Make You look Like a Leader 39min" },
            { "Be Heard : Why Listen When You can Talk? 40min" },
            { "Modern History: Revisiting Obselete Tech from Two Years Ago 41min" },
            { "Raising your Children From Inside a Cubicle lightning" },
            { "Power Moves: Thumb Exercises to Type Faster on Mobile Devices 42min" },
            { "Round-Table: Stare at your Eletronic Device With Others for 43min" },
            { "Pokemon Tournament 44min" },
            { "Tips For Appearing Productive 45min" },
            { "Hyper-Coding : The Next Neologism! 46min" },
            { "[Interactive Display] Ferris Wheel of Tech-Churn (Child-Friendly Event) 47min" },
            { "Bio-Hack your BMI 48min" },
            { "Social Networks for Unsocial People 49min" },
            { "Powering Hacking for 10xers Who Are Rockstars 50min" },
            { "[Interactive Display] Mechanical Keyboard Noise-making Symphony 51min" },
            { "Electronic Communications In a World of Humans 52min" },
            { "Duct-Tape it! How To Kick The Can a few Years Down the Road for Someone Else to Deal With 53min" },
            { "Listen to My Talk So I Can take a Photo for my LinkedIn Profile 54min" },

            { "Proper Unit Tests for Anyone 1min" },
            { "Why Python ? 2min" },
            { "TDD for Embedded Systems 3min" },
            { "Dependency Management with Interpreted languages 4min" },
            { "Java, really end of life 5min" },
            { "From Java to Java lightning" },
            { "Managing Network Latency 6min" },
            { "BDD Gone Mad 7min" },
            { "Do you smell that ? (Code Smells) 8min" },
            { "Open Office Space or Closets ???? 9min" },
            { "Proper Pairing 10min" },
            { "Spring JuJu 11min" },
            { "Effective DSL(Domain Specific Languages) 12min" },
            { "Clojure... What Happened(on my project) 13min" },
            { "Effective Legacy Code Techniques... 14min" },
            { "Backends and FrontEnds in JavaScript ? 15min" },
            { "CD on the Mainframe 16min" },
            { "Making Windows Development Enjoyable... 17min" },
            { "Modern Build Systems 18min" },

            { "TDD 19min" },
            { "BDD 20min" },
            { "Law of Demeter and U 21min" },
            { "Trendy Tech Acronyms 22min" },
            { "RU leet enough? 23min" },
            { "Impressing others by Blogging lightning" },
            { "Twitter Burns You Can Use lightning" },
            { "How to Get A Girlfriend lightning" },
            { "Funny things About Frogs lightning" },
            { "The Next Coolest JS Framework lightning" },
            { "Debugging for Fun and Profit 24min" },
            { "Amusing T-Shirt Design Contest 25min" },
            { "Coffee Curation for Nerds 26min" },
            { "Is Your Code Woke Enough? 27min" },
            { "Mega Extreme Extreme Programming  28min" },
            { "Circle the Bandwagons 29min" },
            { "Stack Overflow 30min" },
            { "Spreadsheets 31min" },
            { "Refactoring 32min" },
            { "System Design 33min" },
            { "Cloud Architecture Patterns 34min" },
            { "Wintermute 35min" },
            { "Technolycanthropy 36min" },

            { "Open source: how to work for free 37min" },
            { "EndDowns: The new Startups 38m" },
            { "Instagram Filters to Make You look Like a Leader 39min" },
            { "Be Heard : Why Listen When You can Talk? 40min" },
            { "Modern History: Revisiting Obselete Tech from Two Years Ago 41min" },
            { "Raising your Children From Inside a Cubicle lightning" },
            { "Power Moves: Thumb Exercises to Type Faster on Mobile Devices 42min" },
            { "Round-Table: Stare at your Eletronic Device With Others for 43min" },
            { "Pokemon Tournament 44min" },
            { "Tips For Appearing Productive 45min" },
            { "Hyper-Coding : The Next Neologism! 46min" },
            { "[Interactive Display] Ferris Wheel of Tech-Churn (Child-Friendly Event) 47min" },
            { "Bio-Hack your BMI 48min" },
            { "Social Networks for Unsocial People 49min" },
            { "Powering Hacking for 10xers Who Are Rockstars 50min" },
            { "[Interactive Display] Mechanical Keyboard Noise-making Symphony 51min" },
            { "Electronic Communications In a World of Humans 52min" },
            { "Duct-Tape it! How To Kick The Can a few Years Down the Road for Someone Else to Deal With 53min" },
            { "Listen to My Talk So I Can take a Photo for my LinkedIn Profile 54min" }
        };

        protected readonly List<Event> _events1 = new();
        protected readonly List<Event> _events2 = new();
        protected readonly List<Event> _events3 = new();
        protected readonly List<Event> _events4 = new();
        protected readonly List<Event> _events5 = new();

        protected readonly List<Track> _tracks = new();

        protected readonly Event _event1min      = new("Joke 1min");
        protected readonly Event _eventLightning = new("Jobs lightning");
        protected readonly Event _event15min     = new("Kubernetes 15min");
        protected readonly Event _event30min     = new("Javascript 30min");
        protected readonly Event _event45min     = new("Pragmatic Unit Testing 45min");
        protected readonly Event _event60min     = new("C FAQs 60min");
        protected readonly Event _event90min     = new("F# 90min");
        protected readonly Event _event120min    = new("Kafka 120min");
        protected readonly Event _event180min    = new("C++ FAQs 180min");
        protected readonly Event _event240min    = new("SAFe 240min");
        protected readonly Event _event241min    = new("More SAFe 241min");

        protected readonly TimeSpan _0mins = new(0, 0, 0);
        protected readonly TimeSpan _1mins = new(0, 1, 0);
        protected readonly TimeSpan _5mins = new(0, 5, 0);
        protected readonly TimeSpan _15mins = new(0, 15, 0);
        protected readonly TimeSpan _30mins = new(0, 30, 0);
        protected readonly TimeSpan _45mins = new(0, 45, 0);
        protected readonly TimeSpan _60mins = new(0, 60, 0);
        protected readonly TimeSpan _120mins = new(0, 120, 0);
        protected readonly TimeSpan _180mins = new(0, 180, 0);
        protected readonly TimeSpan _240mins = new(0, 240, 0);
        protected readonly TimeSpan _300mins = new(0, 300, 0);
        protected readonly TimeSpan _360mins = new(0, 360, 0);
        protected readonly TimeSpan _420mins = new(0, 420, 0);

        protected readonly int _0 = 0;
        protected readonly int _1 = 1;
        protected readonly int _5 = 5;
        protected readonly int _15 = 15;
        protected readonly int _30 = 30;
        protected readonly int _45 = 45;
        protected readonly int _60 = 60;
        protected readonly int _120 = 120;
        protected readonly int _180 = 180;
        protected readonly int _240 = 240;
        protected readonly int _300 = 300;
        protected readonly int _360 = 360;
        protected readonly int _420 = 420;

        protected EventListFacade _eventListFacade1;
        protected EventListFacade _eventListFacade2;
        protected EventListFacade _eventListFacade3;
        protected EventListFacade _eventListFacade4;
        protected EventListFacade _eventListFacade5;

        protected Session _morningSession   = new(DateTime.Now.Date.AddHours(9), DateTime.Now.Date.AddHours(12));
        protected Session _afternoonSessionLong = new(DateTime.Now.Date.AddHours(13), DateTime.Now.Date.AddHours(17));
        protected Session _afternoonSessionShort = new(DateTime.Now.Date.AddHours(13), DateTime.Now.Date.AddHours(16));

        protected Session _morningSessionFilled = new(DateTime.Now.Date.AddHours(9), DateTime.Now.Date.AddHours(12));
        protected Session _afternoonSessionFilled = new(DateTime.Now.Date.AddHours(13), DateTime.Now.Date.AddHours(17));

        protected ISessionFactory _sessionFactory = new SessionFactory();

        protected ITrack _trackLong;
        protected ITrack _trackShort;
        protected ITrack _trackCustom;

        protected DateTime _morningStartTime = DateTime.Today.AddHours(9);
        protected DateTime _morningEndTime = DateTime.Today.AddHours(12);
        protected DateTime _afternoonStartTime = DateTime.Today.AddHours(13);
        protected DateTime _afternoonEndTime = DateTime.Today.AddHours(17);
        protected DateTime _afternoonEndTimeEarly = DateTime.Today.AddHours(16);
        protected DateTime _lunchStartTime = DateTime.Today.AddHours(12);
        protected DateTime _lunchEndTime = DateTime.Today.AddHours(13);

        protected static IContainer Container { get; set; }

        static TestBase()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TrackFactory>().As<ITrackFactory>();
            builder.RegisterType<SessionFactory>().As<ISessionFactory>();
            builder.RegisterType<EventListFacadeFactory>().As<IEventListFacadeFactory>(); 
            builder.RegisterType<RoundRobinTrackScheduler>().Named<ITrackScheduler>("roundRobin");
            builder.RegisterType<DeepTrackScheduler>().Named<ITrackScheduler>("deepTrack");
            builder.RegisterType<TrackSchedulePrinter>().As<ITrackSchedulePrinter>();
            Container = builder.Build();
        }
        public TestBase()
        {
            _trackLong = new Track(_sessionFactory, "TrackLong", _morningStartTime, _morningEndTime, _afternoonStartTime, _afternoonEndTime);
            _trackShort = new Track(_sessionFactory, "TrackShort", _morningStartTime, _morningEndTime, _afternoonStartTime, _afternoonEndTimeEarly);
            _trackCustom = new Track(_sessionFactory, "TrackShort", _morningStartTime, _morningEndTime, _afternoonStartTime, _afternoonEndTimeEarly);

            foreach (KeyValuePair<string, int> pair in _eventsInput1)
            {
                _events1.Add(new Event(pair.Key));
            }
            _eventListFacade1 = new EventListFacade(_events1);

            foreach (KeyValuePair<string, int> pair in _eventsInput2)
            {
                _events2.Add(new Event(pair.Key));
            }
            _eventListFacade2 = new EventListFacade(_events2);

            _eventsInput3.ForEach(str => _events3.Add(new Event(str)));
            _eventListFacade3 = new EventListFacade(_events3);

            _eventsInput4.ForEach(str => _events4.Add(new Event(str)));
            _eventListFacade4 = new EventListFacade(_events4);

            _eventsInput5.ForEach(str => _events5.Add(new Event(str)));
            _eventListFacade5 = new EventListFacade(_events5);

            foreach (Event evnt in _events1)
            {
                while(_morningSessionFilled.CanScheduleEvent(evnt))
                {
                    _morningSessionFilled.ScheduleEvent(evnt);
                }

                while (_afternoonSessionFilled.CanScheduleEvent(evnt))
                {
                    _afternoonSessionFilled.ScheduleEvent(evnt);
                }
            }  
        }

        protected bool EachSessionContainsMultipleTalks_(IEnumerable<ITrack> scheduledTracks)
        {
            foreach (ITrack scheduledTrack in scheduledTracks)
            {
                // 'Each session contains multiple talks'
                Assert.True(scheduledTrack.MorningSession.ScheduledEvents.Where(evnt => !evnt.Title.Contains("Lunch")).Count() > 1);
                Assert.True(scheduledTrack.AfternoonSession.ScheduledEvents.Where(evnt => !evnt.Title.Contains("Networking")).Count() > 1);
            }
            return true;
        }
        protected bool MorningSessionsBeginAt9AMandFinishByNoon_(IEnumerable<ITrack> scheduledTracks)
        {
            foreach (ITrack scheduledTrack in scheduledTracks)
            {
                // 'Morning sessions begin at 9am and must finish by 12 noon, for lunch.'
                Assert.NotNull(scheduledTrack.MorningSession.ScheduledEvents.FirstOrDefault());
                Assert.True(scheduledTrack.MorningSession.ScheduledEvents.FirstOrDefault().StartTime == _morningStartTime);
                Assert.Contains("Lunch", scheduledTrack.MorningSession.ScheduledEvents[scheduledTrack.MorningSession.ScheduledEvents.Count - 1].Title);
                Assert.True(scheduledTrack.MorningSession.ScheduledEvents[scheduledTrack.MorningSession.ScheduledEvents.Count - 2].EndTime <= _lunchStartTime);
            }
            return true;
        }
        protected bool LunchIsBetweenNoonAnd1pm_(IEnumerable<ITrack> scheduledTracks)
        {
            foreach (ITrack scheduledTrack in scheduledTracks)
            {
                // 'Morning sessions begin at 9am and must finish by 12 noon, for lunch.'
                var lunch = scheduledTrack.MorningSession.ScheduledEvents.Where(evnt => evnt.Title.Contains("Lunch"));
                Assert.NotNull(lunch);
                Assert.NotEmpty(lunch);
                Assert.Single(lunch);
                Assert.Equal(_lunchStartTime, lunch.FirstOrDefault().StartTime);
                Assert.Equal(_lunchEndTime, lunch.FirstOrDefault().EndTime);
            }
            return true;
        }
        protected bool NoGapsBetweenSessions_(IEnumerable<ITrack> scheduledTracks)
        {
            foreach (ITrack scheduledTrack in scheduledTracks)
            {
                Event previousEvent = new("Placeholder 1mins");
                // 'there needs to be no gap between sessions'
                foreach (Event evnt in scheduledTrack.MorningSession.ScheduledEvents)
                {
                    Assert.True(evnt.StartTime.HasValue);
                    Assert.True(evnt.EndTime.HasValue);

                    if (previousEvent.Title.Contains("Placeholder"))
                    {
                        previousEvent = evnt;
                        continue;
                    }

                    Assert.Equal(_0mins, evnt.StartTime.Value.Subtract(previousEvent.EndTime.Value));
                    previousEvent = evnt;
                }
            }
            return true;
        }
        protected bool NetworkingEventBetween4pmand5pm_(IEnumerable<ITrack> scheduledTracks)
        {
            foreach (ITrack scheduledTrack in scheduledTracks)
            {
                // 'The networking event can start no earlier than 4:00 and no later than 5:00.'
                var networking = scheduledTrack.AfternoonSession.ScheduledEvents.Where(evnt => evnt.Title.Contains("Networking"));
                Assert.NotNull(networking);
                Assert.NotEmpty(networking);
                Assert.Single(networking);
                Assert.True(networking.FirstOrDefault().StartTime >= _afternoonEndTimeEarly);
                Assert.True(networking.FirstOrDefault().StartTime <= _afternoonEndTime);
            }
            return true;
        }
    }
}
