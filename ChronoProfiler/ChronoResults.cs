using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aga.Controls.Tree;
using Aga.Controls.Tree.NodeControls;

namespace ChronoProfiler
{
    public partial class ChronoResults : Form
    {
        private Dictionary<string, ChronoEntry> dati = null;
        private List<ChronoItem> items = new List<ChronoItem>();

        private void CreateItems()
        {
            foreach (ChronoEntry entry in dati.Values)
            {
                if (entry.IsRunning())
                    throw new ApplicationException("Timer still executing.");

                List<ChronoItem> locallist = items;
                string[] splitted = entry.name.Split(';');
                for (int i = 0; i < splitted.Length; i++)
                {
                    string s = splitted[i];
                    ChronoItem ci = locallist.Find(new Predicate<ChronoItem>(delegate(ChronoItem citemp) { return citemp.Name == s; }));
                    if (ci == null)
                    {
                        if (i == splitted.Length - 1)
                            ci = new ChronoItem(s, (int)entry.sw.ElapsedMilliseconds, entry.timesstarted);
                        else
                            ci = new ChronoItem(s, -1, -1);
                        locallist.Add(ci);
                    }
                    locallist = ci.chronoitemschildren;
                }
            }
        }

        public ChronoResults(Dictionary<string, ChronoEntry> dati)
        {
            InitializeComponent();
            this.dati = dati;
            CreateItems();
        }

        private void CronometroResults_Load(object sender, EventArgs e)
        {
            TreeColumn tcName = new TreeColumn("Name", 300);
            TreeColumn tcElapsed = new TreeColumn("Elapsed", 100);
            TreeColumn tcQty = new TreeColumn("Qty", 100);
            TreeColumn tcAverage = new TreeColumn("Average", 100);

            tv.Columns.Add(tcName);
            tv.Columns.Add(tcElapsed);
            tv.Columns.Add(tcQty);
            tv.Columns.Add(tcAverage);

            NodeTextBox ntbName = new NodeTextBox();
            ntbName.DataPropertyName = "Name";
            ntbName.ParentColumn = tcName;
            ntbName.IsEditEnabledValueNeeded += new EventHandler<NodeControlValueEventArgs>(EventSetReadOnly);
            tv.NodeControls.Add(ntbName);

            NodeTextBox ntbElapsed = new NodeTextBox();
            ntbElapsed.DataPropertyName = "Elapsed";
            ntbElapsed.ParentColumn = tcElapsed;
            tv.NodeControls.Add(ntbElapsed);

            NodeTextBox ntbQty = new NodeTextBox();
            ntbQty.DataPropertyName = "Qty";
            ntbQty.ParentColumn = tcQty;
            tv.NodeControls.Add(ntbQty);

            NodeTextBox ntbAverage = new NodeTextBox();
            ntbAverage.DataPropertyName = "Average";
            ntbAverage.ParentColumn = tcAverage;
            tv.NodeControls.Add(ntbAverage);

            tv.Model = new SortedTreeModel(new ChronoModel(items));

            tv.ColumnHeaderHeight = 20;
            //tv.RowHeight = 20;
            tv.UseColumns = true;
            tv.SelectionMode = TreeSelectionMode.Multi;
            tv.ExpandAll();
        }

        void EventSetReadOnly(object sender, NodeControlValueEventArgs e)
        {
            e.Value = false;
        }

        private void tv_ColumnClicked(object sender, TreeColumnEventArgs e)
        {
            TreeColumn clicked = e.Column;
            if (clicked.SortOrder == SortOrder.Ascending)
                clicked.SortOrder = SortOrder.Descending;
            else
                clicked.SortOrder = SortOrder.Ascending;

            (tv.Model as SortedTreeModel).Comparer = new ChronoItemSorter(clicked.Header, clicked.SortOrder);
        }
    }
}
