using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public class EventListFacadeFactory : IEventListFacadeFactory
    {
        public IEventListFacade Create(IEnumerable<Event> events)
        {
            return new EventListFacade(events);
        }
    }
}
