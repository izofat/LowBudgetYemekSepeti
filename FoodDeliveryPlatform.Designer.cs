namespace Food_Delivery_Platform
{
    partial class FoodDeliveryPlatform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodDeliveryPlatform));
            this.lblwelcome = new System.Windows.Forms.Label();
            this.btncustomer = new System.Windows.Forms.Button();
            this.btnbuniness = new System.Windows.Forms.Button();
            this.groupBoxstartup = new System.Windows.Forms.GroupBox();
            this.txtbxpassword = new System.Windows.Forms.TextBox();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnsignup = new System.Windows.Forms.Button();
            this.lblinfoacc = new System.Windows.Forms.Label();
            this.btnaction = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtbxusername = new System.Windows.Forms.TextBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.groupBoxactions = new System.Windows.Forms.GroupBox();
            this.groupBoxstartup.SuspendLayout();
            this.groupBoxactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblwelcome
            // 
            this.lblwelcome.AutoSize = true;
            this.lblwelcome.Font = new System.Drawing.Font("Leelawadee UI", 17.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwelcome.ForeColor = System.Drawing.Color.White;
            this.lblwelcome.Location = new System.Drawing.Point(138, 22);
            this.lblwelcome.Name = "lblwelcome";
            this.lblwelcome.Size = new System.Drawing.Size(481, 32);
            this.lblwelcome.TabIndex = 0;
            this.lblwelcome.Text = "Welcome to the Food Delivery Platform !";
            // 
            // btncustomer
            // 
            this.btncustomer.BackColor = System.Drawing.Color.White;
            this.btncustomer.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncustomer.Location = new System.Drawing.Point(203, 70);
            this.btncustomer.Name = "btncustomer";
            this.btncustomer.Size = new System.Drawing.Size(105, 37);
            this.btncustomer.TabIndex = 1;
            this.btncustomer.Text = "Customer";
            this.btncustomer.UseVisualStyleBackColor = false;
            this.btncustomer.Click += new System.EventHandler(this.btncustomer_Click);
            // 
            // btnbuniness
            // 
            this.btnbuniness.BackColor = System.Drawing.Color.White;
            this.btnbuniness.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuniness.Location = new System.Drawing.Point(492, 70);
            this.btnbuniness.Name = "btnbuniness";
            this.btnbuniness.Size = new System.Drawing.Size(105, 37);
            this.btnbuniness.TabIndex = 2;
            this.btnbuniness.Text = "Business";
            this.btnbuniness.UseVisualStyleBackColor = false;
            this.btnbuniness.Click += new System.EventHandler(this.btnbuniness_Click);
            // 
            // groupBoxstartup
            // 
            this.groupBoxstartup.Controls.Add(this.groupBoxactions);
            this.groupBoxstartup.Controls.Add(this.btnsignup);
            this.groupBoxstartup.Controls.Add(this.lblinfoacc);
            this.groupBoxstartup.Controls.Add(this.btnlogin);
            this.groupBoxstartup.Location = new System.Drawing.Point(229, 150);
            this.groupBoxstartup.Name = "groupBoxstartup";
            this.groupBoxstartup.Size = new System.Drawing.Size(345, 269);
            this.groupBoxstartup.TabIndex = 3;
            this.groupBoxstartup.TabStop = false;
            this.groupBoxstartup.Visible = false;
            // 
            // txtbxpassword
            // 
            this.txtbxpassword.Font = new System.Drawing.Font("Leelawadee UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxpassword.Location = new System.Drawing.Point(100, 70);
            this.txtbxpassword.MaxLength = 20;
            this.txtbxpassword.Name = "txtbxpassword";
            this.txtbxpassword.Size = new System.Drawing.Size(165, 29);
            this.txtbxpassword.TabIndex = 3;
            this.txtbxpassword.UseSystemPasswordChar = true;
            // 
            // btnshow
            // 
            this.btnshow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnshow.BackgroundImage")));
            this.btnshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnshow.Location = new System.Drawing.Point(263, 70);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(37, 29);
            this.btnshow.TabIndex = 9;
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnsignup
            // 
            this.btnsignup.BackColor = System.Drawing.Color.White;
            this.btnsignup.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsignup.Location = new System.Drawing.Point(175, 61);
            this.btnsignup.Name = "btnsignup";
            this.btnsignup.Size = new System.Drawing.Size(101, 29);
            this.btnsignup.TabIndex = 8;
            this.btnsignup.Text = "Sign up";
            this.btnsignup.UseVisualStyleBackColor = false;
            this.btnsignup.Click += new System.EventHandler(this.btnsignup_Click);
            // 
            // lblinfoacc
            // 
            this.lblinfoacc.AutoSize = true;
            this.lblinfoacc.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfoacc.ForeColor = System.Drawing.Color.White;
            this.lblinfoacc.Location = new System.Drawing.Point(22, 16);
            this.lblinfoacc.Name = "lblinfoacc";
            this.lblinfoacc.Size = new System.Drawing.Size(23, 25);
            this.lblinfoacc.TabIndex = 7;
            this.lblinfoacc.Text = "0";
            // 
            // btnaction
            // 
            this.btnaction.BackColor = System.Drawing.Color.White;
            this.btnaction.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaction.Location = new System.Drawing.Point(100, 120);
            this.btnaction.Name = "btnaction";
            this.btnaction.Size = new System.Drawing.Size(101, 29);
            this.btnaction.TabIndex = 6;
            this.btnaction.Text = "Log in";
            this.btnaction.UseVisualStyleBackColor = false;
            this.btnaction.Click += new System.EventHandler(this.btnaction_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.White;
            this.btnlogin.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(49, 61);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(101, 29);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Log in";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtbxusername
            // 
            this.txtbxusername.Font = new System.Drawing.Font("Leelawadee UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxusername.Location = new System.Drawing.Point(100, 34);
            this.txtbxusername.MaxLength = 20;
            this.txtbxusername.Name = "txtbxusername";
            this.txtbxusername.Size = new System.Drawing.Size(165, 29);
            this.txtbxusername.TabIndex = 2;
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpassword.ForeColor = System.Drawing.Color.White;
            this.lblpassword.Location = new System.Drawing.Point(6, 78);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(84, 21);
            this.lblpassword.TabIndex = 1;
            this.lblpassword.Text = "Password :";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.White;
            this.lblusername.Location = new System.Drawing.Point(6, 37);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(88, 21);
            this.lblusername.TabIndex = 0;
            this.lblusername.Text = "Username :";
            // 
            // groupBoxactions
            // 
            this.groupBoxactions.Controls.Add(this.txtbxpassword);
            this.groupBoxactions.Controls.Add(this.btnshow);
            this.groupBoxactions.Controls.Add(this.lblusername);
            this.groupBoxactions.Controls.Add(this.lblpassword);
            this.groupBoxactions.Controls.Add(this.txtbxusername);
            this.groupBoxactions.Controls.Add(this.btnaction);
            this.groupBoxactions.Location = new System.Drawing.Point(16, 96);
            this.groupBoxactions.Name = "groupBoxactions";
            this.groupBoxactions.Size = new System.Drawing.Size(323, 164);
            this.groupBoxactions.TabIndex = 10;
            this.groupBoxactions.TabStop = false;
            this.groupBoxactions.Visible = false;
            // 
            // FoodDeliveryPlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.groupBoxstartup);
            this.Controls.Add(this.btnbuniness);
            this.Controls.Add(this.btncustomer);
            this.Controls.Add(this.lblwelcome);
            this.Name = "FoodDeliveryPlatform";
            this.Text = "Username";
            this.groupBoxstartup.ResumeLayout(false);
            this.groupBoxstartup.PerformLayout();
            this.groupBoxactions.ResumeLayout(false);
            this.groupBoxactions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblwelcome;
        private System.Windows.Forms.Button btncustomer;
        private System.Windows.Forms.Button btnbuniness;
        private System.Windows.Forms.GroupBox groupBoxstartup;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox txtbxpassword;
        private System.Windows.Forms.TextBox txtbxusername;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label lblinfoacc;
        private System.Windows.Forms.Button btnaction;
        private System.Windows.Forms.Button btnsignup;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.GroupBox groupBoxactions;
    }
}

