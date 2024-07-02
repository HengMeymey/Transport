using System.Windows.Forms;

namespace Final
{
    partial class Payment
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.txtMajorID = new System.Windows.Forms.TextBox();
            this.txtStuID = new System.Windows.Forms.TextBox();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.txtStaffPosition = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.dtpPayment = new System.Windows.Forms.DateTimePicker();
            this.checkPaid = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dgvPay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPay)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date                      :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone Number   :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Departure Time  : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Origin                   :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Destination          :";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(500, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 50);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "Total price  :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(616, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 22);
            this.label11.TabIndex = 11;
            this.label11.Text = "Staff Name     :";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(621, 181);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(172, 47);
            this.btnInsert.TabIndex = 12;
            this.btnInsert.Text = "Add";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(621, 254);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(172, 47);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(621, 329);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(172, 47);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.Text = "Clear";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Location = new System.Drawing.Point(218, 62);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(263, 29);
            this.txtPaidAmount.TabIndex = 18;
            // 
            // txtMajorID
            // 
            this.txtMajorID.Location = new System.Drawing.Point(217, 21);
            this.txtMajorID.Name = "txtMajorID";
            this.txtMajorID.Size = new System.Drawing.Size(263, 29);
            this.txtMajorID.TabIndex = 19;
            // 
            // txtStuID
            // 
            this.txtStuID.Location = new System.Drawing.Point(218, 163);
            this.txtStuID.Name = "txtStuID";
            this.txtStuID.Size = new System.Drawing.Size(263, 29);
            this.txtStuID.TabIndex = 20;
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(218, 212);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(263, 29);
            this.txtStaffID.TabIndex = 21;
            // 
            // txtStaffPosition
            // 
            this.txtStaffPosition.Location = new System.Drawing.Point(218, 260);
            this.txtStaffPosition.Name = "txtStaffPosition";
            this.txtStaffPosition.Size = new System.Drawing.Size(263, 29);
            this.txtStaffPosition.TabIndex = 22;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(783, 72);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(226, 29);
            this.txtStaffName.TabIndex = 23;
            // 
            // dtpPayment
            // 
            this.dtpPayment.Location = new System.Drawing.Point(217, 117);
            this.dtpPayment.Name = "dtpPayment";
            this.dtpPayment.Size = new System.Drawing.Size(263, 29);
            this.dtpPayment.TabIndex = 24;
            // 
            // checkPaid
            // 
            this.checkPaid.AutoSize = true;
            this.checkPaid.Location = new System.Drawing.Point(458, 433);
            this.checkPaid.Name = "checkPaid";
            this.checkPaid.Size = new System.Drawing.Size(22, 21);
            this.checkPaid.TabIndex = 25;
            this.checkPaid.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 317);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 22);
            this.label13.TabIndex = 30;
            this.label13.Text = "Bus No                 :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(218, 311);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 29);
            this.textBox1.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 371);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 22);
            this.label14.TabIndex = 32;
            this.label14.Text = "Seat No                : ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(218, 365);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(263, 29);
            this.textBox2.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(616, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 22);
            this.label9.TabIndex = 34;
            this.label9.Text = "Staff Position :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(783, 119);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(226, 29);
            this.textBox3.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 47);
            this.button1.TabIndex = 36;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 22);
            this.label1.TabIndex = 37;
            this.label1.Text = "Paid  :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(177, 422);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(144, 29);
            this.textBox4.TabIndex = 38;
            // 
            // dgvPay
            // 
            this.dgvPay.AllowUserToAddRows = false;
            this.dgvPay.AllowUserToDeleteRows = false;
            this.dgvPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPay.Location = new System.Drawing.Point(12, 474);
            this.dgvPay.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPay.Name = "dgvPay";
            this.dgvPay.ReadOnly = true;
            this.dgvPay.RowHeadersWidth = 62;
            this.dgvPay.RowTemplate.Height = 28;
            this.dgvPay.Size = new System.Drawing.Size(997, 140);
            this.dgvPay.TabIndex = 0;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 629);
            this.Controls.Add(this.dgvPay);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.checkPaid);
            this.Controls.Add(this.dtpPayment);
            this.Controls.Add(this.txtStaffPosition);
            this.Controls.Add(this.txtStaffID);
            this.Controls.Add(this.txtStuID);
            this.Controls.Add(this.txtMajorID);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Payment";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtMajorID;
        private System.Windows.Forms.TextBox txtStuID;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.TextBox txtStaffPosition;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.DateTimePicker dtpPayment;
        private System.Windows.Forms.CheckBox checkPaid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private DataGridView dgvPay;
    }
}