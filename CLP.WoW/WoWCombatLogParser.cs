using CLP.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLP.WoW
{
    public class WoWCombatLogParser
    {
        private const int year = 2016;

        public IEnumerable<ICombatLogEntry> ParseFile(string fullName)
        {
            var res = new List<ICombatLogEntry>();

            using (var sr = new StreamReader(fullName))
            {
                while (!sr.EndOfStream)
                {
                    var str = sr.ReadLine();
                    var evt = ParseString(str);
                    res.Add(evt);
                }
            }

            return res;
        }

        private ICombatLogEntry ParseString(string str)
        {
            var res = new CombatLogEntry();

            var parts = str.Split(',');

            var dateTypeStr = parts[0];
            var dateTypeStrParts = dateTypeStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var dateStr = dateTypeStrParts[0];
            var timeStr = dateTypeStrParts[1];
            var typeStr = dateTypeStrParts[2];

            var date = DateTime.Parse(dateStr + "/" + year);
            var ts = TimeSpan.Parse(timeStr);
            res.EventType = GetEventType(typeStr);
            res.TimeStamp = date.Add(ts);

            return res;
        }

        private EventType GetEventType(string typeStr)
        {
            var res = new EventType();

            switch (typeStr)
            {
                case "SWING_DAMAGE":
                    res.Type = EventTypes.SwingDamage;
                    break;
                case "SWING_DAMAGE_LANDED":
                    res.Type = EventTypes.SwingDamageLanded;
                    break;
                default:
                    res.Type = EventTypes.Unknown;
                    res.Text = typeStr;
                    break;
            }

            return res;
        }
    }
}
