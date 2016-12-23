using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLP.Common.Interfaces
{
    public interface ICombatLogEntry
    {
        DateTime TimeStamp { get; set; }
        IActor Source { get; set; }
        IActor Target { get; set; }
        IEventType EventType { get; set; }
    }
}
