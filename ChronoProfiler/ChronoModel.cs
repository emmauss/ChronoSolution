using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aga.Controls.Tree;

namespace ChronoProfiler
{
    public class ChronoModel : ITreeModel
    {
        List<ChronoItem> items;
        public ChronoModel(List<ChronoItem> items)
        {
            this.items = items;
        }

        public System.Collections.IEnumerable GetChildren(TreePath treePath)
        {
            if (treePath.LastNode == null)
            {
                return items;
            }
            else
                return ((ChronoItem)treePath.LastNode).chronoitemschildren;
        }

        public bool IsLeaf(TreePath treePath)
        {
            ChronoItem i = (ChronoItem)treePath.FullPath[0];
            return i.IsLeaf();
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;
        public event EventHandler<TreePathEventArgs> StructureChanged;
    }
}
