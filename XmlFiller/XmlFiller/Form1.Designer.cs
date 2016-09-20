namespace XmlFiller
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gemXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hentXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DataTree = new System.Windows.Forms.TreeView();
            this.contextMenuTreeNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Opret = new System.Windows.Forms.ToolStripMenuItem();
            this.visSomTabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDatatype = new System.Windows.Forms.Label();
            this.indtastningData = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuTreeNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filerToolStripMenuItem
            // 
            this.filerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDllToolStripMenuItem,
            this.toolStripSeparator1,
            this.gemXMLToolStripMenuItem,
            this.hentXMLToolStripMenuItem});
            this.filerToolStripMenuItem.Name = "filerToolStripMenuItem";
            this.filerToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.filerToolStripMenuItem.Text = "Filer";
            // 
            // loadDllToolStripMenuItem
            // 
            this.loadDllToolStripMenuItem.Name = "loadDllToolStripMenuItem";
            this.loadDllToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.loadDllToolStripMenuItem.Text = "Load dll";
            this.loadDllToolStripMenuItem.Click += new System.EventHandler(this.loadDllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // gemXMLToolStripMenuItem
            // 
            this.gemXMLToolStripMenuItem.Name = "gemXMLToolStripMenuItem";
            this.gemXMLToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.gemXMLToolStripMenuItem.Text = "Gem XML";
            this.gemXMLToolStripMenuItem.Click += new System.EventHandler(this.gemXMLToolStripMenuItem_Click);
            // 
            // hentXMLToolStripMenuItem
            // 
            this.hentXMLToolStripMenuItem.Name = "hentXMLToolStripMenuItem";
            this.hentXMLToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.hentXMLToolStripMenuItem.Text = "Hent XML";
            this.hentXMLToolStripMenuItem.Click += new System.EventHandler(this.hentXMLToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DataTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblName);
            this.splitContainer1.Panel2.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel2.Controls.Add(this.lblDatatype);
            this.splitContainer1.Panel2.Controls.Add(this.indtastningData);
            this.splitContainer1.Size = new System.Drawing.Size(866, 544);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 1;
            // 
            // DataTree
            // 
            this.DataTree.ContextMenuStrip = this.contextMenuTreeNode;
            this.DataTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTree.Location = new System.Drawing.Point(0, 0);
            this.DataTree.Name = "DataTree";
            this.DataTree.Size = new System.Drawing.Size(324, 544);
            this.DataTree.TabIndex = 0;
            this.DataTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.DataTree_BeforeSelect);
            this.DataTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DataTree_AfterSelect);
            // 
            // contextMenuTreeNode
            // 
            this.contextMenuTreeNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opret,
            this.visSomTabelToolStripMenuItem});
            this.contextMenuTreeNode.Name = "contextMenuTreeNode";
            this.contextMenuTreeNode.Size = new System.Drawing.Size(154, 48);
            this.contextMenuTreeNode.Text = "Indsæt";
            this.contextMenuTreeNode.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuTreeNode_Opening);
            // 
            // Opret
            // 
            this.Opret.Name = "Opret";
            this.Opret.Size = new System.Drawing.Size(153, 22);
            this.Opret.Text = "Opret forekomst";
            this.Opret.Click += new System.EventHandler(this.Opret_Click);
            // 
            // visSomTabelToolStripMenuItem
            // 
            this.visSomTabelToolStripMenuItem.Name = "visSomTabelToolStripMenuItem";
            this.visSomTabelToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.visSomTabelToolStripMenuItem.Text = "Vis som tabel";
            this.visSomTabelToolStripMenuItem.Click += new System.EventHandler(this.visSomTabelToolStripMenuItem_Click);
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(29, 161);
            this.lblName.Multiline = true;
            this.lblName.Name = "lblName";
            this.lblName.ReadOnly = true;
            this.lblName.Size = new System.Drawing.Size(433, 128);
            this.lblName.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(413, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // lblDatatype
            // 
            this.lblDatatype.AutoSize = true;
            this.lblDatatype.Location = new System.Drawing.Point(26, 145);
            this.lblDatatype.Name = "lblDatatype";
            this.lblDatatype.Size = new System.Drawing.Size(48, 13);
            this.lblDatatype.TabIndex = 1;
            this.lblDatatype.Text = "datatype";
            // 
            // indtastningData
            // 
            this.indtastningData.Dock = System.Windows.Forms.DockStyle.Top;
            this.indtastningData.Enabled = false;
            this.indtastningData.Location = new System.Drawing.Point(0, 0);
            this.indtastningData.Multiline = true;
            this.indtastningData.Name = "indtastningData";
            this.indtastningData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.indtastningData.Size = new System.Drawing.Size(538, 128);
            this.indtastningData.TabIndex = 0;
            this.indtastningData.TextChanged += new System.EventHandler(this.indtastningData_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 568);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FACILIA XmlFiller";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuTreeNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDllToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView DataTree;
        private System.Windows.Forms.Label lblDatatype;
        private System.Windows.Forms.TextBox indtastningData;
        private System.Windows.Forms.ContextMenuStrip contextMenuTreeNode;
        private System.Windows.Forms.ToolStripMenuItem Opret;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripMenuItem gemXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hentXMLToolStripMenuItem;
        private System.Windows.Forms.TextBox lblName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem visSomTabelToolStripMenuItem;
    }
}

