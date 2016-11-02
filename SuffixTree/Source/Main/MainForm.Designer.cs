namespace SuffixTreeExplorer
{
    partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.ctrlGraph = new Microsoft.Msagl.GraphViewerGdi.GViewer();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.ctrlInputString = new System.Windows.Forms.TextBox();
         this.ctrlBuild = new System.Windows.Forms.Button();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.ctrlSuffixArray = new System.Windows.Forms.ListBox();
         this.tableLayoutPanel1.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // ctrlGraph
         // 
         this.ctrlGraph.ArrowheadLength = 10D;
         this.ctrlGraph.AsyncLayout = false;
         this.ctrlGraph.AutoScroll = true;
         this.ctrlGraph.BackwardEnabled = false;
         this.ctrlGraph.BuildHitTree = true;
         this.ctrlGraph.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
         this.ctrlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ctrlGraph.EdgeInsertButtonVisible = true;
         this.ctrlGraph.FileName = "";
         this.ctrlGraph.ForwardEnabled = false;
         this.ctrlGraph.Graph = null;
         this.ctrlGraph.InsertingEdge = false;
         this.ctrlGraph.LayoutAlgorithmSettingsButtonVisible = true;
         this.ctrlGraph.LayoutEditingEnabled = true;
         this.ctrlGraph.Location = new System.Drawing.Point(0, 0);
         this.ctrlGraph.LooseOffsetForRouting = 0.25D;
         this.ctrlGraph.MouseHitDistance = 0.05D;
         this.ctrlGraph.Name = "ctrlGraph";
         this.ctrlGraph.NavigationVisible = true;
         this.ctrlGraph.NeedToCalculateLayout = true;
         this.ctrlGraph.OffsetForRelaxingInRouting = 0.6D;
         this.ctrlGraph.PaddingForEdgeRouting = 8D;
         this.ctrlGraph.PanButtonPressed = false;
         this.ctrlGraph.SaveAsImageEnabled = true;
         this.ctrlGraph.SaveAsMsaglEnabled = true;
         this.ctrlGraph.SaveButtonVisible = true;
         this.ctrlGraph.SaveGraphButtonVisible = true;
         this.ctrlGraph.SaveInVectorFormatEnabled = true;
         this.ctrlGraph.Size = new System.Drawing.Size(994, 653);
         this.ctrlGraph.TabIndex = 0;
         this.ctrlGraph.TightOffsetForRouting = 0.125D;
         this.ctrlGraph.ToolBarIsVisible = true;
         this.ctrlGraph.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("ctrlGraph.Transform")));
         this.ctrlGraph.UndoRedoButtonsVisible = true;
         this.ctrlGraph.WindowZoomButtonPressed = false;
         this.ctrlGraph.ZoomF = 1D;
         this.ctrlGraph.ZoomFraction = 0.5D;
         this.ctrlGraph.ZoomWhenMouseWheelScroll = true;
         this.ctrlGraph.ZoomWindowThreshold = 0.05D;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.775687F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.22431F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 691);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 4;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1270F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.Controls.Add(this.ctrlInputString, 2, 0);
         this.tableLayoutPanel2.Controls.Add(this.ctrlBuild, 1, 0);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(1271, 26);
         this.tableLayoutPanel2.TabIndex = 1;
         // 
         // ctrlInputString
         // 
         this.ctrlInputString.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.ctrlInputString.Location = new System.Drawing.Point(110, 3);
         this.ctrlInputString.Name = "ctrlInputString";
         this.ctrlInputString.Size = new System.Drawing.Size(1065, 20);
         this.ctrlInputString.TabIndex = 1;
         this.ctrlInputString.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctrlInputString_KeyPress);
         // 
         // ctrlBuild
         // 
         this.ctrlBuild.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.ctrlBuild.Location = new System.Drawing.Point(12, 3);
         this.ctrlBuild.Name = "ctrlBuild";
         this.ctrlBuild.Size = new System.Drawing.Size(75, 20);
         this.ctrlBuild.TabIndex = 0;
         this.ctrlBuild.Text = "Build";
         this.ctrlBuild.UseVisualStyleBackColor = true;
         this.ctrlBuild.Click += new System.EventHandler(this.ctrlBuild_Click);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(3, 35);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.ctrlSuffixArray);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.ctrlGraph);
         this.splitContainer1.Size = new System.Drawing.Size(1271, 653);
         this.splitContainer1.SplitterDistance = 273;
         this.splitContainer1.TabIndex = 2;
         // 
         // ctrlSuffixArray
         // 
         this.ctrlSuffixArray.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ctrlSuffixArray.FormattingEnabled = true;
         this.ctrlSuffixArray.Location = new System.Drawing.Point(0, 0);
         this.ctrlSuffixArray.Name = "ctrlSuffixArray";
         this.ctrlSuffixArray.Size = new System.Drawing.Size(273, 653);
         this.ctrlSuffixArray.TabIndex = 0;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1277, 691);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Name = "MainForm";
         this.Text = "SuffixTreeExplorer";
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer ctrlGraph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox ctrlInputString;
        private System.Windows.Forms.Button ctrlBuild;
        private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.ListBox ctrlSuffixArray;
   }
}

