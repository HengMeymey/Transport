using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
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
            dgvCus = new DataGridView();
            btnRefresh = new Button();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCus).BeginInit();
            SuspendLayout();
            // 
            // dgvStu
            // 
            dgvCus.AllowUserToAddRows = false;
            dgvCus.AllowUserToDeleteRows = false;
            dgvCus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCus.Location = new Point(22, 61);
            dgvCus.Margin = new Padding(4, 4, 4, 4);
            dgvCus.Name = "dgvStu";
            dgvCus.ReadOnly = true;
            dgvCus.RowHeadersWidth = 51;
            dgvCus.RowTemplate.Height = 29;
            dgvCus.Size = new Size(942, 571);
            dgvCus.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(22, 15);
            btnRefresh.Margin = new Padding(4, 4, 4, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(118, 36);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(564, 15);
            btnCreate.Margin = new Padding(4, 4, 4, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(118, 36);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(705, 15);
            btnEdit.Margin = new Padding(4, 4, 4, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(118, 36);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(848, 15);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 36);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // MainForm1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 641);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnCreate);
            Controls.Add(btnRefresh);
            Controls.Add(dgvCus);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)dgvCus).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvCus;
        private Button btnRefresh;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
    }
}