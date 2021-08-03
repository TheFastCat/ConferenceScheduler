using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public class SessionFactory : ISessionFactory
    {
        public ISession Create(DateTime startTime, DateTime endTime)
        {
            return new Session(startTime, endTime);
        }
    }
}
