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
            this.txtbxlocation = new System.Windows.Forms.TextBox();
            this.lblloc = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
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
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1109, 613);
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
    }
}