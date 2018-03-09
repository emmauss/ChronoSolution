using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChronoProfiler
{
    public static class Chrono
    {
        private static Dictionary<string, ChronoEntry> data = new Dictionary<string, ChronoEntry>();

        public static void Start(string name)
        {
            if (data.ContainsKey(name))
                data[name].Start();
            else
                data[name] = new ChronoEntry(name);
        }

        public static void Stop(string name)
        {
            if (!data.ContainsKey(name))
                throw new ApplicationException("ID not existing");

            data[name].Stop();
        }

        public static void ShowResults()
        {
            (new ChronoResults(data)).ShowDialog();
        }
    }
}
