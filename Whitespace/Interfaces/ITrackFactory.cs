using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public interface ITrackFactory
    {
        ITrack Create(string title,
            DateTime morningStartTime,
            DateTime morningEndTime,
            DateTime afternoonStartTime,
            DateTime afternoonEndTime);
    }
}
