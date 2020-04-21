﻿namespace MinecraftLauncher
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label_login = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox_baniere = new System.Windows.Forms.PictureBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button_run = new System.Windows.Forms.Button();
            this.button_login_offline = new System.Windows.Forms.Button();
            this.textBox_username_offline = new System.Windows.Forms.TextBox();
            this.label_username_offline = new System.Windows.Forms.Label();
            this.label_progressbar = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_baniere)).BeginInit();
            this.SuspendLayout();
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.BackColor = System.Drawing.Color.Transparent;
            this.label_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login.ForeColor = System.Drawing.Color.White;
            this.label_login.Location = new System.Drawing.Point(12, 82);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(143, 20);
            this.label_login.TabIndex = 0;
            this.label_login.Text = "Nom d\'utilisateur";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.BackColor = System.Drawing.Color.Transparent;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.ForeColor = System.Drawing.Color.White;
            this.label_password.Location = new System.Drawing.Point(12, 145);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(117, 20);
            this.label_password.TabIndex = 1;
            this.label_password.Text = "Mot de passe";
            // 
            // textBox_username
            // 
            this.textBox_username.BackColor = System.Drawing.Color.Black;
            this.textBox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_username.ForeColor = System.Drawing.Color.White;
            this.textBox_username.Location = new System.Drawing.Point(12, 105);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(178, 26);
            this.textBox_username.TabIndex = 2;
            // 
            // textBox_password
            // 
            this.textBox_password.BackColor = System.Drawing.Color.Black;
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.ForeColor = System.Drawing.Color.White;
            this.textBox_password.Location = new System.Drawing.Point(12, 168);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(178, 26);
            this.textBox_password.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(406, 397);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(466, 52);
            this.progressBar1.TabIndex = 4;
            // 
            // pictureBox_baniere
            // 
            this.pictureBox_baniere.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_baniere.Location = new System.Drawing.Point(16, 12);
            this.pictureBox_baniere.Name = "pictureBox_baniere";
            this.pictureBox_baniere.Size = new System.Drawing.Size(856, 67);
            this.pictureBox_baniere.TabIndex = 5;
            this.pictureBox_baniere.TabStop = false;
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.Transparent;
            this.button_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_login.BackgroundImage")));
            this.button_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.Transparent;
            this.button_login.Location = new System.Drawing.Point(12, 200);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(178, 33);
            this.button_login.TabIndex = 6;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_run
            // 
            this.button_run.BackColor = System.Drawing.Color.Transparent;
            this.button_run.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_run.BackgroundImage")));
            this.button_run.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_run.ForeColor = System.Drawing.Color.Transparent;
            this.button_run.Location = new System.Drawing.Point(12, 374);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(388, 75);
            this.button_run.TabIndex = 7;
            this.button_run.Text = "Launch minecraft";
            this.button_run.UseVisualStyleBackColor = false;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // button_login_offline
            // 
            this.button_login_offline.BackColor = System.Drawing.Color.Transparent;
            this.button_login_offline.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_login_offline.BackgroundImage")));
            this.button_login_offline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_login_offline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login_offline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login_offline.ForeColor = System.Drawing.Color.Transparent;
            this.button_login_offline.Location = new System.Drawing.Point(222, 200);
            this.button_login_offline.Name = "button_login_offline";
            this.button_login_offline.Size = new System.Drawing.Size(178, 33);
            this.button_login_offline.TabIndex = 8;
            this.button_login_offline.Text = "Login-Offline";
            this.button_login_offline.UseVisualStyleBackColor = false;
            this.button_login_offline.Click += new System.EventHandler(this.button_login_offline_Click);
            // 
            // textBox_username_offline
            // 
            this.textBox_username_offline.BackColor = System.Drawing.Color.Black;
            this.textBox_username_offline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_username_offline.ForeColor = System.Drawing.Color.White;
            this.textBox_username_offline.Location = new System.Drawing.Point(222, 105);
            this.textBox_username_offline.Name = "textBox_username_offline";
            this.textBox_username_offline.Size = new System.Drawing.Size(178, 26);
            this.textBox_username_offline.TabIndex = 10;
            // 
            // label_username_offline
            // 
            this.label_username_offline.AutoSize = true;
            this.label_username_offline.BackColor = System.Drawing.Color.Transparent;
            this.label_username_offline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username_offline.ForeColor = System.Drawing.Color.White;
            this.label_username_offline.Location = new System.Drawing.Point(222, 82);
            this.label_username_offline.Name = "label_username_offline";
            this.label_username_offline.Size = new System.Drawing.Size(143, 20);
            this.label_username_offline.TabIndex = 9;
            this.label_username_offline.Text = "Nom d\'utilisateur";
            // 
            // label_progressbar
            // 
            this.label_progressbar.AutoSize = true;
            this.label_progressbar.BackColor = System.Drawing.Color.Transparent;
            this.label_progressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_progressbar.ForeColor = System.Drawing.Color.White;
            this.label_progressbar.Location = new System.Drawing.Point(406, 374);
            this.label_progressbar.Name = "label_progressbar";
            this.label_progressbar.Size = new System.Drawing.Size(153, 20);
            this.label_progressbar.TabIndex = 11;
            this.label_progressbar.Text = "label_progressbar";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.ForeColor = System.Drawing.Color.White;
            this.label_info.Location = new System.Drawing.Point(472, 105);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(87, 20);
            this.label_info.TabIndex = 12;
            this.label_info.Text = "label_info";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label_progressbar);
            this.Controls.Add(this.textBox_username_offline);
            this.Controls.Add(this.label_username_offline);
            this.Controls.Add(this.button_login_offline);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.pictureBox_baniere);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_baniere)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox_baniere;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.Button button_login_offline;
        private System.Windows.Forms.TextBox textBox_username_offline;
        private System.Windows.Forms.Label label_username_offline;
        private System.Windows.Forms.Label label_progressbar;
        private System.Windows.Forms.Label label_info;
    }
}
