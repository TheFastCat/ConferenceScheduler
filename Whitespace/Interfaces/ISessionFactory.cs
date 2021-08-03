using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public interface ISessionFactory
    {
        ISession Create(DateTime startTime, DateTime endTime);
    }
}
