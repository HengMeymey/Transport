namespace Final
{
    partial class Bus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBusType = new System.Windows.Forms.TextBox();
            this.txtBusNO = new System.Windows.Forms.TextBox();
            this.txtBusModel = new System.Windows.Forms.TextBox();
            this.txtTotalSeats = new System.Windows.Forms.TextBox();
            this.txtDefaultFarr = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(419, 539);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1079, 282);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Khmer Moul", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Final.Properties.Resources.search__2_;
            this.pictureBox1.Location = new System.Drawing.Point(836, 461);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer OS Muol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1003, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "BusType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer OS Muol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(999, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bus No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Khmer OS Muol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(999, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "TotalSeat";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Khmer OS Muol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1003, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 37);
            this.label5.TabIndex = 7;
            this.label5.Text = "Bus Model";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Khmer OS Muol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1003, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 37);
            this.label9.TabIndex = 11;
            this.label9.Text = "DefaultFare";
            // 
            // txtBusType
            // 
            this.txtBusType.Location = new System.Drawing.Point(1184, 239);
            this.txtBusType.Multiline = true;
            this.txtBusType.Name = "txtBusType";
            this.txtBusType.Size = new System.Drawing.Size(270, 32);
            this.txtBusType.TabIndex = 16;
            // 
            // txtBusNO
            // 
            this.txtBusNO.Location = new System.Drawing.Point(1184, 100);
            this.txtBusNO.Multiline = true;
            this.txtBusNO.Name = "txtBusNO";
            this.txtBusNO.Size = new System.Drawing.Size(270, 32);
            this.txtBusNO.TabIndex = 20;
            // 
            // txtBusModel
            // 
            this.txtBusModel.Location = new System.Drawing.Point(1184, 304);
            this.txtBusModel.Multiline = true;
            this.txtBusModel.Name = "txtBusModel";
            this.txtBusModel.Size = new System.Drawing.Size(270, 32);
            this.txtBusModel.TabIndex = 21;
            // 
            // txtTotalSeats
            // 
            this.txtTotalSeats.Location = new System.Drawing.Point(1184, 169);
            this.txtTotalSeats.Multiline = true;
            this.txtTotalSeats.Name = "txtTotalSeats";
            this.txtTotalSeats.Size = new System.Drawing.Size(270, 32);
            this.txtTotalSeats.TabIndex = 22;
            // 
            // txtDefaultFarr
            // 
            this.txtDefaultFarr.Location = new System.Drawing.Point(1184, 372);
            this.txtDefaultFarr.Multiline = true;
            this.txtDefaultFarr.Name = "txtDefaultFarr";
            this.txtDefaultFarr.Size = new System.Drawing.Size(270, 32);
            this.txtDefaultFarr.TabIndex = 26;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1351, 455);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 39);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1240, 455);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(119, 40);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(1006, 455);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(119, 40);
            this.btnInsert.TabIndex = 33;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1123, 456);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(119, 38);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Khmer OS Muol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(999, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 37);
            this.label11.TabIndex = 36;
            this.label11.Text = "BusID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(1184, 35);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(270, 32);
            this.txtID.TabIndex = 37;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(499, 466);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(332, 34);
            this.txtsearch.TabIndex = 38;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Final.Properties.Resources.photo_2024_06_22_14_29_17;
            this.pictureBox2.Location = new System.Drawing.Point(419, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(488, 379);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // Bus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1524, 833);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtDefaultFarr);
            this.Controls.Add(this.txtTotalSeats);
            this.Controls.Add(this.txtBusModel);
            this.Controls.Add(this.txtBusNO);
            this.Controls.Add(this.txtBusType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Bus";
            this.Text = "Bus";
            this.Load += new System.EventHandler(this.Bus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBusType;
        private System.Windows.Forms.TextBox txtBusNO;
        private System.Windows.Forms.TextBox txtBusModel;
        private System.Windows.Forms.TextBox txtTotalSeats;
        private System.Windows.Forms.TextBox txtDefaultFarr;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}