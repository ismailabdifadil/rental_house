namespace Rental_Management
{
    partial class Category
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
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.textCName = new System.Windows.Forms.TextBox();
            this.btnGAdd = new System.Windows.Forms.Button();
            this.textCDes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Rental_Management.Properties.Resources.multiply_48px;
            this.pictureBox7.Location = new System.Drawing.Point(637, 14);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(38, 34);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 56;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(1, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 85);
            this.panel2.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(30, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 29);
            this.label8.TabIndex = 38;
            this.label8.Text = "Category";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(20, 178);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(82, 29);
            this.lbl.TabIndex = 59;
            this.lbl.Text = "Name";
            // 
            // textCName
            // 
            this.textCName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCName.Location = new System.Drawing.Point(25, 215);
            this.textCName.Name = "textCName";
            this.textCName.Size = new System.Drawing.Size(208, 53);
            this.textCName.TabIndex = 58;
            // 
            // btnGAdd
            // 
            this.btnGAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(95)))), ((int)(((byte)(246)))));
            this.btnGAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGAdd.ForeColor = System.Drawing.Color.White;
            this.btnGAdd.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnGAdd.Location = new System.Drawing.Point(18, 391);
            this.btnGAdd.Name = "btnGAdd";
            this.btnGAdd.Size = new System.Drawing.Size(215, 63);
            this.btnGAdd.TabIndex = 60;
            this.btnGAdd.Text = "Add";
            this.btnGAdd.UseVisualStyleBackColor = false;
            this.btnGAdd.Click += new System.EventHandler(this.btnGAdd_Click);
            // 
            // textCDes
            // 
            this.textCDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCDes.Location = new System.Drawing.Point(25, 319);
            this.textCDes.Name = "textCDes";
            this.textCDes.Size = new System.Drawing.Size(208, 53);
            this.textCDes.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 29);
            this.label1.TabIndex = 59;
            this.label1.Text = "Description";
            // 
            // categoryGridView
            // 
            this.categoryGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.categoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryGridView.Location = new System.Drawing.Point(241, 167);
            this.categoryGridView.Name = "categoryGridView";
            this.categoryGridView.RowHeadersWidth = 62;
            this.categoryGridView.RowTemplate.Height = 28;
            this.categoryGridView.Size = new System.Drawing.Size(434, 287);
            this.categoryGridView.TabIndex = 61;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 477);
            this.Controls.Add(this.categoryGridView);
            this.Controls.Add(this.btnGAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.textCDes);
            this.Controls.Add(this.textCName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Category";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox textCName;
        private System.Windows.Forms.Button btnGAdd;
        private System.Windows.Forms.TextBox textCDes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView categoryGridView;
    }
}