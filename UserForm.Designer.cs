﻿namespace Food_Delivery_Platform
{
    partial class UserForm
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
            this.groupBoxgetloc = new System.Windows.Forms.GroupBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblloc = new System.Windows.Forms.Label();
            this.txtbxlocation = new System.Windows.Forms.TextBox();
            this.comboBoxrestourants = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnviewbucket = new System.Windows.Forms.Button();
            this.btnorder = new System.Windows.Forms.Button();
            this.btnvieworders = new System.Windows.Forms.Button();
            this.groupBoxgetloc.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxgetloc
            // 
            this.groupBoxgetloc.Controls.Add(this.btnsave);
            this.groupBoxgetloc.Controls.Add(this.lblloc);
            this.groupBoxgetloc.Controls.Add(this.txtbxlocation);
            this.groupBoxgetloc.Location = new System.Drawing.Point(777, 1);
            this.groupBoxgetloc.Name = "groupBoxgetloc";
            this.groupBoxgetloc.Size = new System.Drawing.Size(331, 141);
            this.groupBoxgetloc.TabIndex = 0;
            this.groupBoxgetloc.TabStop = false;
            this.groupBoxgetloc.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(10, 81);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(88, 40);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblloc
            // 
            this.lblloc.AutoSize = true;
            this.lblloc.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloc.ForeColor = System.Drawing.Color.White;
            this.lblloc.Location = new System.Drawing.Point(5, 26);
            this.lblloc.Name = "lblloc";
            this.lblloc.Size = new System.Drawing.Size(93, 25);
            this.lblloc.TabIndex = 4;
            this.lblloc.Text = "Location :";
            // 
            // txtbxlocation
            // 
            this.txtbxlocation.Font = new System.Drawing.Font("Leelawadee UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxlocation.Location = new System.Drawing.Point(104, 11);
            this.txtbxlocation.MaxLength = 200;
            this.txtbxlocation.Multiline = true;
            this.txtbxlocation.Name = "txtbxlocation";
            this.txtbxlocation.Size = new System.Drawing.Size(216, 124);
            this.txtbxlocation.TabIndex = 3;
            // 
            // comboBoxrestourants
            // 
            this.comboBoxrestourants.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxrestourants.FormattingEnabled = true;
            this.comboBoxrestourants.Location = new System.Drawing.Point(12, 60);
            this.comboBoxrestourants.Name = "comboBoxrestourants";
            this.comboBoxrestourants.Size = new System.Drawing.Size(199, 35);
            this.comboBoxrestourants.TabIndex = 1;
            this.comboBoxrestourants.Visible = false;
            this.comboBoxrestourants.SelectedIndexChanged += new System.EventHandler(this.comboBoxrestourants_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(217, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 611);
            this.panel1.TabIndex = 2;
            // 
            // btnviewbucket
            // 
            this.btnviewbucket.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewbucket.Location = new System.Drawing.Point(12, 248);
            this.btnviewbucket.Name = "btnviewbucket";
            this.btnviewbucket.Size = new System.Drawing.Size(180, 35);
            this.btnviewbucket.TabIndex = 3;
            this.btnviewbucket.Text = "View Bucket";
            this.btnviewbucket.UseVisualStyleBackColor = true;
            this.btnviewbucket.Visible = false;
            this.btnviewbucket.Click += new System.EventHandler(this.btnviewbucket_Click);
            // 
            // btnorder
            // 
            this.btnorder.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnorder.Location = new System.Drawing.Point(840, 299);
            this.btnorder.Name = "btnorder";
            this.btnorder.Size = new System.Drawing.Size(108, 60);
            this.btnorder.TabIndex = 4;
            this.btnorder.Text = "Order";
            this.btnorder.UseVisualStyleBackColor = true;
            this.btnorder.Visible = false;
            // 
            // btnvieworders
            // 
            this.btnvieworders.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvieworders.Location = new System.Drawing.Point(12, 299);
            this.btnvieworders.Name = "btnvieworders";
            this.btnvieworders.Size = new System.Drawing.Size(180, 35);
            this.btnvieworders.TabIndex = 5;
            this.btnvieworders.Text = "View Orders";
            this.btnvieworders.UseVisualStyleBackColor = true;
            this.btnvieworders.Click += new System.EventHandler(this.btnvieworders_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1109, 613);
            this.Controls.Add(this.btnvieworders);
            this.Controls.Add(this.btnorder);
            this.Controls.Add(this.btnviewbucket);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBoxrestourants);
            this.Controls.Add(this.groupBoxgetloc);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.groupBoxgetloc.ResumeLayout(false);
            this.groupBoxgetloc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxgetloc;
        private System.Windows.Forms.TextBox txtbxlocation;
        private System.Windows.Forms.Label lblloc;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox comboBoxrestourants;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnviewbucket;
        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.Button btnvieworders;
    }
}