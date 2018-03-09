using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChronoProfiler
{
    public class ChronoItem
    {
        private string name; public string Name{get { return name; }}
        private int elapsed; public int Elapsed{get { return elapsed; }}
        private int qty; public int Qty{get { return qty; }}
        public double Average { get { if (elapsed >= 0) return elapsed / qty; else return -1; } }

        public ChronoItem(string name, int elapsed, int qty)
        {
            this.name = name;
            this.elapsed = elapsed;
            this.qty = qty;
        }

        public List<ChronoItem> chronoitemschildren = new List<ChronoItem>();

        public bool IsLeaf() { return chronoitemschildren.Count == 0; }
    }
}
