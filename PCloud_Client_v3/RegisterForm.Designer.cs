namespace PCloud_Client_v3
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.labPsw = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labUser = new System.Windows.Forms.Label();
            this.txtRePsw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 40);
            this.label1.TabIndex = 35;
            this.label1.Text = "PCloud私人云盘";
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReg.Location = new System.Drawing.Point(321, 198);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(186, 23);
            this.btnReg.TabIndex = 32;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCencel.Location = new System.Drawing.Point(321, 227);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(186, 23);
            this.btnCencel.TabIndex = 33;
            this.btnCencel.Text = "退出";
            this.btnCencel.UseVisualStyleBackColor = false;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(321, 94);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.PasswordChar = '*';
            this.txtPsw.Size = new System.Drawing.Size(186, 21);
            this.txtPsw.TabIndex = 30;
            // 
            // labPsw
            // 
            this.labPsw.AutoSize = true;
            this.labPsw.Location = new System.Drawing.Point(319, 79);
            this.labPsw.Name = "labPsw";
            this.labPsw.Size = new System.Drawing.Size(29, 12);
            this.labPsw.TabIndex = 30;
            this.labPsw.Text = "密码";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(321, 42);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(186, 21);
            this.txtUser.TabIndex = 29;
            // 
            // labUser
            // 
            this.labUser.AutoSize = true;
            this.labUser.Location = new System.Drawing.Point(319, 27);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(29, 12);
            this.labUser.TabIndex = 28;
            this.labUser.Text = "帐号";
            // 
            // txtRePsw
            // 
            this.txtRePsw.Location = new System.Drawing.Point(321, 144);
            this.txtRePsw.Name = "txtRePsw";
            this.txtRePsw.PasswordChar = '*';
            this.txtRePsw.Size = new System.Drawing.Size(186, 21);
            this.txtRePsw.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "重复密码";
            // 
            // labInfo
            // 
            this.labInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labInfo.Location = new System.Drawing.Point(319, 171);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(188, 23);
            this.labInfo.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PCloud_Client_v3.Properties.Resources.icon_cloud;
            this.pictureBox1.Location = new System.Drawing.Point(108, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 106);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 274);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.txtRePsw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.labPsw);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.labUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "用户注册";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.Label labPsw;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label labUser;
        private System.Windows.Forms.TextBox txtRePsw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}