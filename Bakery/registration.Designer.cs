namespace Bakery
{
    partial class Registration
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
            this.createAccount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordReg = new System.Windows.Forms.TextBox();
            this.userNameReg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createAccount
            // 
            this.createAccount.Location = new System.Drawing.Point(31, 134);
            this.createAccount.Margin = new System.Windows.Forms.Padding(6);
            this.createAccount.Name = "createAccount";
            this.createAccount.Size = new System.Drawing.Size(262, 57);
            this.createAccount.TabIndex = 0;
            this.createAccount.Text = "Создать аккаунт";
            this.createAccount.UseVisualStyleBackColor = true;
            this.createAccount.Click += new System.EventHandler(this.CreateAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // passwordReg
            // 
            this.passwordReg.Location = new System.Drawing.Point(114, 96);
            this.passwordReg.Name = "passwordReg";
            this.passwordReg.PasswordChar = '*';
            this.passwordReg.Size = new System.Drawing.Size(179, 29);
            this.passwordReg.TabIndex = 3;
            // 
            // userNameReg
            // 
            this.userNameReg.Location = new System.Drawing.Point(114, 53);
            this.userNameReg.Name = "userNameReg";
            this.userNameReg.Size = new System.Drawing.Size(179, 29);
            this.userNameReg.TabIndex = 4;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 244);
            this.Controls.Add(this.userNameReg);
            this.Controls.Add(this.passwordReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createAccount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordReg;
        private System.Windows.Forms.TextBox userNameReg;
    }
}