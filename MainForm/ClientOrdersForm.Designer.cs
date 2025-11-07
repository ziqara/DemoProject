namespace MainForm
{
    partial class ClientOrdersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientOrdersForm));
            this.OrdersTable = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrdersTable
            // 
            this.OrdersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OrdersTable.Location = new System.Drawing.Point(0, 46);
            this.OrdersTable.MultiSelect = false;
            this.OrdersTable.Name = "OrdersTable";
            this.OrdersTable.ReadOnly = true;
            this.OrdersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersTable.Size = new System.Drawing.Size(543, 236);
            this.OrdersTable.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBtn,
            this.deleteBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(543, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addBtn
            // 
            this.addBtn.AutoSize = false;
            this.addBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(40, 40);
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.AutoSize = false;
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(40, 40);
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // ClientOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 282);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.OrdersTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ClientOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
    }
}