using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public interface IEventListFacadeFactory
    {
        public IEventListFacade Create(IEnumerable<Event> events);
    }
}
