namespace Final
{
    partial class Schedule
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtScheduleID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFare = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBusNoSearch = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.dgvSch = new System.Windows.Forms.DataGridView();
            this.cbBusNo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(653, 295);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(65, 35);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(744, 295);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 35);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtScheduleID
            // 
            this.txtScheduleID.Location = new System.Drawing.Point(352, 52);
            this.txtScheduleID.Name = "txtScheduleID";
            this.txtScheduleID.Size = new System.Drawing.Size(194, 29);
            this.txtScheduleID.TabIndex = 6;
            this.txtScheduleID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "ScheduleID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "BusNo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "DepartureTime";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(352, 213);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(194, 29);
            this.txtTime.TabIndex = 12;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Origin";
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(733, 108);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(202, 29);
            this.txtOrigin.TabIndex = 16;
            this.txtOrigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(655, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Fare";
            // 
            // txtFare
            // 
            this.txtFare.Location = new System.Drawing.Point(733, 52);
            this.txtFare.Name = "txtFare";
            this.txtFare.Size = new System.Drawing.Size(202, 29);
            this.txtFare.TabIndex = 14;
            this.txtFare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(649, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Destination";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(733, 164);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(202, 29);
            this.txtDestination.TabIndex = 18;
            this.txtDestination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(352, 157);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(194, 29);
            this.dtpDate.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(417, 292);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 35);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBusNoSearch
            // 
            this.txtBusNoSearch.Location = new System.Drawing.Point(228, 295);
            this.txtBusNoSearch.Name = "txtBusNoSearch";
            this.txtBusNoSearch.Size = new System.Drawing.Size(183, 29);
            this.txtBusNoSearch.TabIndex = 22;
            this.txtBusNoSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(830, 295);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(62, 35);
            this.btnReload.TabIndex = 23;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(909, 295);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 35);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(962, 46);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(99, 35);
            this.btnLogOut.TabIndex = 25;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // dgvSch
            // 
            this.dgvSch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSch.Location = new System.Drawing.Point(164, 361);
            this.dgvSch.Name = "dgvSch";
            this.dgvSch.RowHeadersWidth = 62;
            this.dgvSch.RowTemplate.Height = 28;
            this.dgvSch.Size = new System.Drawing.Size(873, 213);
            this.dgvSch.TabIndex = 26;
            // 
            // cbBusNo
            // 
            this.cbBusNo.FormattingEnabled = true;
            this.cbBusNo.Location = new System.Drawing.Point(352, 101);
            this.cbBusNo.Name = "cbBusNo";
            this.cbBusNo.Size = new System.Drawing.Size(194, 30);
            this.cbBusNo.TabIndex = 28;
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 586);
            this.Controls.Add(this.cbBusNo);
            this.Controls.Add(this.dgvSch);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtBusNoSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScheduleID);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Schedule";
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.Schedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtScheduleID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBusNoSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.DataGridView dgvSch;
        private System.Windows.Forms.ComboBox cbBusNo;
    }
}