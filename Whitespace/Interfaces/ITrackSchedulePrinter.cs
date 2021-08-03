using System.Collections.Generic;

namespace Whitespace
{
    public interface ITrackSchedulePrinter
    {
        string Print(IEnumerable<ITrack> tracks);
    }
}