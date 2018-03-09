using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace ChronoProfiler
{
    public class ChronoItemSorter : IComparer
    {
        private string _mode;
        private SortOrder _order;

        public ChronoItemSorter(string mode, SortOrder order)
		{
			_mode = mode;
			_order = order;
		}

        public int Compare(object x, object y)
        {
            ChronoItem a = x as ChronoItem;
            ChronoItem b = y as ChronoItem;
            int res = 0;

            if (_mode == "Name")
                res = a.Name.CompareTo(b.Name);
            else if (_mode == "Elapsed")
                res = a.Elapsed.CompareTo(b.Elapsed);
            else if (_mode == "Qty")
                res = a.Qty.CompareTo(b.Qty);
            else
                res = a.Average.CompareTo(b.Average);

            if (_order == SortOrder.Ascending)
                return -res;
            else
                return res;
        }

        private string GetData(object x)
        {
            return (x as ChronoItem).Name;
        }
    }
}
