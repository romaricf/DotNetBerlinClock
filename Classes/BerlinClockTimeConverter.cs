using BerlinClock.Tools;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public static class BerlinClockTimeConverter
    {
        /// <exception cref="FormatException">aTime should be in a HH:mm:ss format</exception>
        public static string ToBerlinClockTime(string aTime)
        {
            DateTime time = DateTime.ParseExact(aTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            return ToBerlinClockTime(time);
        }

        public static string ToBerlinClockTime(DateTime time)
        {
            // Generate each line of the clock

            var line1 = time.Second % 2 == 0 ? "Y" : "O";
            
            var line2 = "R".Times(time.Hour % 5).PadRight(4, 'O');

            var line3 = "R".Times(time.Hour / 5).PadRight(4, 'O');
            
            var b = new StringBuilder("Y".Times(time.Minute / 5).PadRight(11, 'O'));
            int[] q = { 2, 5, 8 }; // These lights are red when on
            q.ForEach(x => b[x] = YellowToRed(b[x]));
            var line4 = b.ToString();

            var line5 = "Y".Times(time.Minute % 5).PadRight(4, 'O');

            // Aggregate the lines
            string[] lines = { line1, line3, line2, line4, line5 };
            return lines.Aggregate((x,y) => x + Environment.NewLine + y);
        }

        static char YellowToRed(char c)
        {
            return c == 'Y' ? 'R' : c;
        }
    }
}
