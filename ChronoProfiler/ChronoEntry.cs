using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ChronoProfiler
{
    public class ChronoEntry
    {
        public Stopwatch sw = new Stopwatch();
        public string name;
        public int timesstarted = 1;

        public ChronoEntry(string name) { this.name = name; sw.Start(); }

        public void Start() { if (sw.IsRunning) throw new ApplicationException("StopWatch running"); sw.Start(); timesstarted++; }
        public void Stop() { if (!sw.IsRunning) throw new ApplicationException("StopWatch not running"); sw.Stop(); }
        public bool IsRunning() { return sw.IsRunning; }
    }
}
