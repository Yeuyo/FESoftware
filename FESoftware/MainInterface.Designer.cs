
namespace FESoftware
{
    partial class MainInterface
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.structureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingBoundaryConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.structureToolStripMenuItem,
            this.analysisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAnalysisToolStripMenuItem,
            this.loadAnalysisToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newAnalysisToolStripMenuItem
            // 
            this.newAnalysisToolStripMenuItem.Name = "newAnalysisToolStripMenuItem";
            this.newAnalysisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newAnalysisToolStripMenuItem.Text = "New Analysis";
            // 
            // loadAnalysisToolStripMenuItem
            // 
            this.loadAnalysisToolStripMenuItem.Name = "loadAnalysisToolStripMenuItem";
            this.loadAnalysisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadAnalysisToolStripMenuItem.Text = "Load Analysis";
            this.loadAnalysisToolStripMenuItem.Click += new System.EventHandler(this.loadAnalysisToolStripMenuItem_Click);
            // 
            // structureToolStripMenuItem
            // 
            this.structureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodesToolStripMenuItem,
            this.addElementsToolStripMenuItem});
            this.structureToolStripMenuItem.Name = "structureToolStripMenuItem";
            this.structureToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.structureToolStripMenuItem.Text = "Structure";
            // 
            // addNodesToolStripMenuItem
            // 
            this.addNodesToolStripMenuItem.Name = "addNodesToolStripMenuItem";
            this.addNodesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNodesToolStripMenuItem.Text = "Add Node(s)";
            this.addNodesToolStripMenuItem.Click += new System.EventHandler(this.addNodesToolStripMenuItem_Click);
            // 
            // addElementsToolStripMenuItem
            // 
            this.addElementsToolStripMenuItem.Name = "addElementsToolStripMenuItem";
            this.addElementsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addElementsToolStripMenuItem.Text = "Add Element(s)";
            this.addElementsToolStripMenuItem.Click += new System.EventHandler(this.addElementsToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialsToolStripMenuItem,
            this.loadingBoundaryConditionsToolStripMenuItem,
            this.runAnalysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // materialsToolStripMenuItem
            // 
            this.materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            this.materialsToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.materialsToolStripMenuItem.Text = "Materials";
            this.materialsToolStripMenuItem.Click += new System.EventHandler(this.materialsToolStripMenuItem_Click);
            // 
            // loadingBoundaryConditionsToolStripMenuItem
            // 
            this.loadingBoundaryConditionsToolStripMenuItem.Name = "loadingBoundaryConditionsToolStripMenuItem";
            this.loadingBoundaryConditionsToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.loadingBoundaryConditionsToolStripMenuItem.Text = "Loading and Boundary Conditions";
            this.loadingBoundaryConditionsToolStripMenuItem.Click += new System.EventHandler(this.loadingBoundaryConditionsToolStripMenuItem_Click);
            // 
            // runAnalysisToolStripMenuItem
            // 
            this.runAnalysisToolStripMenuItem.Name = "runAnalysisToolStripMenuItem";
            this.runAnalysisToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.runAnalysisToolStripMenuItem.Text = "Run Analysis";
            this.runAnalysisToolStripMenuItem.Click += new System.EventHandler(this.runAnalysisToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(961, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(275, 327);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(21, 387);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(916, 150);
            this.dataGridView2.TabIndex = 2;
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 558);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainInterface";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAnalysisToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem structureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadingBoundaryConditionsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem runAnalysisToolStripMenuItem;
    }
}

