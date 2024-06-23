namespace Final
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Final.Properties.Resources.photo_2024_06_22_14_29_17;
            this.pictureBox1.Location = new System.Drawing.Point(34, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 408);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kh Prey Veng", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phone Number";
            // 
            // phone_number
            // 
            this.phone_number.Location = new System.Drawing.Point(621, 168);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(255, 26);
            this.phone_number.TabIndex = 3;
            this.phone_number.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(621, 220);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(255, 26);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(482, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 52);
            this.label3.TabIndex = 5;
            this.label3.Text = "LOG IN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kh Prey Veng", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(433, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.SystemColors.Menu;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Adobe Devanagari", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(425, 308);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(133, 39);
            this.exit.TabIndex = 7;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.Menu;
            this.Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login.Font = new System.Drawing.Font("Adobe Devanagari", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(729, 308);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(133, 39);
            this.Login.TabIndex = 8;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Menu;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Adobe Devanagari", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(579, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(899, 466);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.phone_number);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button button1;
    }
}