namespace ChronoProfiler
{
    partial class ChronoResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tv = new Aga.Controls.Tree.TreeViewAdv();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.BackColor = System.Drawing.SystemColors.Window;
            this.tv.ColumnHeaderHeight = 0;
            this.tv.DefaultToolTipProvider = null;
            this.tv.DragDropMarkColor = System.Drawing.Color.Black;
            this.tv.LineColor = System.Drawing.SystemColors.ControlDark;
            this.tv.Location = new System.Drawing.Point(12, 12);
            this.tv.Model = null;
            this.tv.Name = "tv";
            this.tv.SelectedNode = null;
            this.tv.Size = new System.Drawing.Size(650, 614);
            this.tv.TabIndex = 0;
            this.tv.Text = "treeViewAdv1";
            this.tv.ColumnClicked += new System.EventHandler<Aga.Controls.Tree.TreeColumnEventArgs>(this.tv_ColumnClicked);
            // 
            // ChronoResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 638);
            this.Controls.Add(this.tv);
            this.Name = "ChronoResults";
            this.Text = "ChronoResults";
            this.Load += new System.EventHandler(this.CronometroResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Aga.Controls.Tree.TreeViewAdv tv;

    }
}