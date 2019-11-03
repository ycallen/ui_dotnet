using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Query = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.back = new System.Windows.Forms.ToolStripButton();
            this.foward = new System.Windows.Forms.ToolStripButton();
            this.erase = new System.Windows.Forms.ToolStripButton();
            this.run = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.Query.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(1, 64);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(917, 295);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tabControl1.Controls.Add(this.Query);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(913, 63);
            this.tabControl1.TabIndex = 2;
            // 
            // Query
            // 
            this.Query.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Query.Controls.Add(this.toolStrip2);
            this.Query.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Query.Location = new System.Drawing.Point(4, 29);
            this.Query.Name = "Query";
            this.Query.Padding = new System.Windows.Forms.Padding(3);
            this.Query.Size = new System.Drawing.Size(905, 30);
            this.Query.TabIndex = 0;
            this.Query.Text = "Query";
            this.Query.Click += new System.EventHandler(this.Query_Click_1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.back,
            this.foward,
            this.erase,
            this.run});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(104, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // back
            // 
            this.back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(23, 22);
            this.back.Text = "toolStripButton3";
            this.back.ToolTipText = "back";
            this.back.Click += new System.EventHandler(this.backward_Click);
            // 
            // foward
            // 
            this.foward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.foward.Image = ((System.Drawing.Image)(resources.GetObject("foward.Image")));
            this.foward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.foward.Name = "foward";
            this.foward.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.foward.Size = new System.Drawing.Size(23, 22);
            this.foward.Text = "toolStripButton4";
            this.foward.ToolTipText = "foward";
            this.foward.Click += new System.EventHandler(this.foward_Click);
            // 
            // erase
            // 
            this.erase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.erase.Image = ((System.Drawing.Image)(resources.GetObject("erase.Image")));
            this.erase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(23, 22);
            this.erase.Text = "erase";
            this.erase.Click += new System.EventHandler(this.erase_Click);
            // 
            // run
            // 
            this.run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.run.Image = ((System.Drawing.Image)(resources.GetObject("run.Image")));
            this.run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(23, 22);
            this.run.Text = "run";
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(917, 222);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView1_RowPostPaint);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(31, 362);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(222, 25);
            this.richTextBox3.TabIndex = 5;
            this.richTextBox3.Text = "";
            this.richTextBox3.TextChanged += new System.EventHandler(this.RichTextBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(267, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 24);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Image = global::View.Properties.Resources.icons8_search_16__1_1;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(7, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 25);
            this.label2.TabIndex = 7;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(920, 613);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SparqlUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Query.ResumeLayout(false);
            this.Query.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        
        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource != null)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[invisible] LIKE '%{0}%'", richTextBox3.Text);
            }            
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        


        #endregion
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Query;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton run;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton back;
        private System.Windows.Forms.ToolStripButton foward;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private RichTextBox richTextBox3;
        private Label label1;
        private Label label2;
        private ToolStripButton erase;
    }
}

