namespace MainForm
{
    partial class AddClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClientForm));
            this.nameBox = new System.Windows.Forms.TextBox();
            this.desBox = new System.Windows.Forms.TextBox();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.imageBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.avatarBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(112, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 0;
            // 
            // desBox
            // 
            this.desBox.Location = new System.Drawing.Point(112, 38);
            this.desBox.Name = "desBox";
            this.desBox.Size = new System.Drawing.Size(100, 20);
            this.desBox.TabIndex = 1;
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(112, 64);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(100, 20);
            this.phoneBox.TabIndex = 2;
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(112, 90);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(100, 20);
            this.mailBox.TabIndex = 3;
            // 
            // imageBtn
            // 
            this.imageBtn.Location = new System.Drawing.Point(112, 116);
            this.imageBtn.Name = "imageBtn";
            this.imageBtn.Size = new System.Drawing.Size(100, 23);
            this.imageBtn.TabIndex = 4;
            this.imageBtn.Text = "Загрузить";
            this.imageBtn.UseVisualStyleBackColor = true;
            this.imageBtn.Click += new System.EventHandler(this.imageBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(218, 145);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(100, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Сохранить";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // avatarBox
            // 
            this.avatarBox.Location = new System.Drawing.Point(218, 39);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(100, 100);
            this.avatarBox.TabIndex = 7;
            this.avatarBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Телефон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Описание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Название";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Загрузите фото";
            // 
            // AddClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 184);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.avatarBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.imageBtn);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.desBox);
            this.Controls.Add(this.nameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddClientForm";
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox desBox;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Button imageBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.PictureBox avatarBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}