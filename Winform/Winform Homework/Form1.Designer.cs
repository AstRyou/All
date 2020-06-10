namespace HomeWorkWinform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addFurniture = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.coffeeTable = new System.Windows.Forms.Button();
            this.doubleBed = new System.Windows.Forms.Button();
            this.sofa = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.Button();
            this.buttonWall = new System.Windows.Forms.Button();
            this.createFurniture = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.addFurniture.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.createFurniture.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.paintbox_MouseWheel);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.addFurniture, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.createFurniture, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // addFurniture
            // 
            this.addFurniture.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.addFurniture, "addFurniture");
            this.addFurniture.Name = "addFurniture";
            this.addFurniture.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.coffeeTable);
            this.flowLayoutPanel1.Controls.Add(this.doubleBed);
            this.flowLayoutPanel1.Controls.Add(this.sofa);
            this.flowLayoutPanel1.Controls.Add(this.table);
            this.flowLayoutPanel1.Controls.Add(this.buttonWall);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // coffeeTable
            // 
            this.coffeeTable.BackColor = System.Drawing.Color.White;
            this.coffeeTable.BackgroundImage = global::HomeWorkWinform.Properties.Resources.coffee_table;
            resources.ApplyResources(this.coffeeTable, "coffeeTable");
            this.coffeeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.coffeeTable.Name = "coffeeTable";
            this.coffeeTable.Tag = "0";
            this.coffeeTable.UseVisualStyleBackColor = false;
            this.coffeeTable.Click += new System.EventHandler(this.button_Click);
            // 
            // doubleBed
            // 
            this.doubleBed.BackColor = System.Drawing.Color.White;
            this.doubleBed.BackgroundImage = global::HomeWorkWinform.Properties.Resources.double_bed;
            resources.ApplyResources(this.doubleBed, "doubleBed");
            this.doubleBed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doubleBed.Name = "doubleBed";
            this.doubleBed.Tag = "0";
            this.doubleBed.UseVisualStyleBackColor = false;
            this.doubleBed.Click += new System.EventHandler(this.button_Click);
            // 
            // sofa
            // 
            this.sofa.BackColor = System.Drawing.Color.White;
            this.sofa.BackgroundImage = global::HomeWorkWinform.Properties.Resources.sofa;
            resources.ApplyResources(this.sofa, "sofa");
            this.sofa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sofa.Name = "sofa";
            this.sofa.Tag = "0";
            this.sofa.UseVisualStyleBackColor = false;
            this.sofa.Click += new System.EventHandler(this.button_Click);
            // 
            // table
            // 
            this.table.BackColor = System.Drawing.Color.White;
            this.table.BackgroundImage = global::HomeWorkWinform.Properties.Resources.table;
            resources.ApplyResources(this.table, "table");
            this.table.Cursor = System.Windows.Forms.Cursors.Hand;
            this.table.Name = "table";
            this.table.Tag = "0";
            this.table.UseVisualStyleBackColor = false;
            this.table.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonWall
            // 
            this.buttonWall.BackColor = System.Drawing.Color.White;
            this.buttonWall.BackgroundImage = global::HomeWorkWinform.Properties.Resources.wall;
            resources.ApplyResources(this.buttonWall, "buttonWall");
            this.buttonWall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWall.Name = "buttonWall";
            this.buttonWall.Tag = "0";
            this.buttonWall.UseVisualStyleBackColor = false;
            this.buttonWall.Click += new System.EventHandler(this.button_Click);
            // 
            // createFurniture
            // 
            this.createFurniture.Controls.Add(this.listBox1);
            resources.ApplyResources(this.createFurniture, "createFurniture");
            this.createFurniture.Name = "createFurniture";
            this.createFurniture.TabStop = false;
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlueprintToolStripMenuItem,
            this.openBlueprintToolStripMenuItem,
            this.saveBlueprintToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newBlueprintToolStripMenuItem
            // 
            this.newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            resources.ApplyResources(this.newBlueprintToolStripMenuItem, "newBlueprintToolStripMenuItem");
            this.newBlueprintToolStripMenuItem.Click += new System.EventHandler(this.newBlueprintToolStripMenuItem_Click);
            // 
            // openBlueprintToolStripMenuItem
            // 
            this.openBlueprintToolStripMenuItem.Name = "openBlueprintToolStripMenuItem";
            resources.ApplyResources(this.openBlueprintToolStripMenuItem, "openBlueprintToolStripMenuItem");
            this.openBlueprintToolStripMenuItem.Click += new System.EventHandler(this.openBlueprintToolStripMenuItem_Click);
            // 
            // saveBlueprintToolStripMenuItem
            // 
            this.saveBlueprintToolStripMenuItem.Name = "saveBlueprintToolStripMenuItem";
            resources.ApplyResources(this.saveBlueprintToolStripMenuItem, "saveBlueprintToolStripMenuItem");
            this.saveBlueprintToolStripMenuItem.Click += new System.EventHandler(this.saveBlueprintToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pLToolStripMenuItem,
            this.engToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // pLToolStripMenuItem
            // 
            this.pLToolStripMenuItem.Name = "pLToolStripMenuItem";
            resources.ApplyResources(this.pLToolStripMenuItem, "pLToolStripMenuItem");
          
            // 
            // engToolStripMenuItem
            // 
            this.engToolStripMenuItem.Name = "engToolStripMenuItem";
            resources.ApplyResources(this.engToolStripMenuItem, "engToolStripMenuItem");
            
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.addFurniture.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.createFurniture.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox addFurniture;
        private System.Windows.Forms.GroupBox createFurniture;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBlueprintToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button coffeeTable;
        private System.Windows.Forms.Button doubleBed;
        private System.Windows.Forms.Button sofa;
        private System.Windows.Forms.Button table;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonWall;
        private System.Windows.Forms.ToolStripMenuItem openBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

