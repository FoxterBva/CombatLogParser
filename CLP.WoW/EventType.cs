using CLP.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLP.WoW
{
    public enum EventTypes
    {
        Unknown,
        SwingDamage,
        SwingDamageLanded
    }

    public class EventType : IEventType
    {
        public EventTypes Type { get; set; }
        public string Text { get; set; }                // used to store string for undefined events
    }
}
