namespace Food_Delivery_Platform
{
    partial class BusinessForm
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
            this.txtbxrestorantname = new System.Windows.Forms.TextBox();
            this.btnset = new System.Windows.Forms.Button();
            this.lblrestourantname = new System.Windows.Forms.Label();
            this.groupBoxnoname = new System.Windows.Forms.GroupBox();
            this.txtbxloc = new System.Windows.Forms.TextBox();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.btnstart = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.comboBoxproducts = new System.Windows.Forms.ComboBox();
            this.groupBoxactions = new System.Windows.Forms.GroupBox();
            this.btnvieworders = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.groupBoxdata = new System.Windows.Forms.GroupBox();
            this.txtbximageloc = new System.Windows.Forms.TextBox();
            this.comboBoxstatus = new System.Windows.Forms.ComboBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.btngetimage = new System.Windows.Forms.Button();
            this.picturebxproduct = new System.Windows.Forms.PictureBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblimageloc = new System.Windows.Forms.Label();
            this.txtbxprice = new System.Windows.Forms.TextBox();
            this.txtbxingredients = new System.Windows.Forms.TextBox();
            this.txtbxproductname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblingredients = new System.Windows.Forms.Label();
            this.lblproductname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxnoname.SuspendLayout();
            this.groupBoxactions.SuspendLayout();
            this.groupBoxdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebxproduct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxrestorantname
            // 
            this.txtbxrestorantname.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxrestorantname.Location = new System.Drawing.Point(161, 19);
            this.txtbxrestorantname.MaxLength = 29;
            this.txtbxrestorantname.Name = "txtbxrestorantname";
            this.txtbxrestorantname.Size = new System.Drawing.Size(166, 33);
            this.txtbxrestorantname.TabIndex = 1;
            // 
            // btnset
            // 
            this.btnset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnset.Font = new System.Drawing.Font("Leelawadee UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnset.Location = new System.Drawing.Point(6, 19);
            this.btnset.Name = "btnset";
            this.btnset.Size = new System.Drawing.Size(75, 33);
            this.btnset.TabIndex = 0;
            this.btnset.Text = "SET";
            this.btnset.UseVisualStyleBackColor = false;
            this.btnset.Click += new System.EventHandler(this.btnset_Click);
            // 
            // lblrestourantname
            // 
            this.lblrestourantname.AutoSize = true;
            this.lblrestourantname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblrestourantname.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrestourantname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblrestourantname.Location = new System.Drawing.Point(543, 27);
            this.lblrestourantname.Name = "lblrestourantname";
            this.lblrestourantname.Size = new System.Drawing.Size(33, 37);
            this.lblrestourantname.TabIndex = 2;
            this.lblrestourantname.Text = "0";
            this.lblrestourantname.Visible = false;
            // 
            // groupBoxnoname
            // 
            this.groupBoxnoname.Controls.Add(this.txtbxloc);
            this.groupBoxnoname.Controls.Add(this.lblLoc);
            this.groupBoxnoname.Controls.Add(this.lblname);
            this.groupBoxnoname.Controls.Add(this.txtbxrestorantname);
            this.groupBoxnoname.Controls.Add(this.btnset);
            this.groupBoxnoname.Location = new System.Drawing.Point(12, 12);
            this.groupBoxnoname.Name = "groupBoxnoname";
            this.groupBoxnoname.Size = new System.Drawing.Size(333, 114);
            this.groupBoxnoname.TabIndex = 3;
            this.groupBoxnoname.TabStop = false;
            this.groupBoxnoname.Visible = false;
            // 
            // txtbxloc
            // 
            this.txtbxloc.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxloc.Location = new System.Drawing.Point(161, 69);
            this.txtbxloc.MaxLength = 59;
            this.txtbxloc.Name = "txtbxloc";
            this.txtbxloc.Size = new System.Drawing.Size(166, 33);
            this.txtbxloc.TabIndex = 5;
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoc.Location = new System.Drawing.Point(67, 75);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(84, 21);
            this.lblLoc.TabIndex = 6;
            this.lblLoc.Text = "Location :";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(87, 25);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(64, 21);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "Name :";
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnstart.Font = new System.Drawing.Font("Leelawadee UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstart.ForeColor = System.Drawing.Color.Black;
            this.btnstart.Location = new System.Drawing.Point(387, 12);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(110, 78);
            this.btnstart.TabIndex = 4;
            this.btnstart.Text = "START";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnadd.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.Black;
            this.btnadd.Location = new System.Drawing.Point(6, 65);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(176, 40);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "Add Product";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnview.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.Black;
            this.btnview.Location = new System.Drawing.Point(6, 19);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(176, 40);
            this.btnview.TabIndex = 6;
            this.btnview.Text = "View Products";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // comboBoxproducts
            // 
            this.comboBoxproducts.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxproducts.FormattingEnabled = true;
            this.comboBoxproducts.Location = new System.Drawing.Point(236, 155);
            this.comboBoxproducts.Name = "comboBoxproducts";
            this.comboBoxproducts.Size = new System.Drawing.Size(193, 33);
            this.comboBoxproducts.TabIndex = 7;
            this.comboBoxproducts.Visible = false;
            this.comboBoxproducts.SelectedValueChanged += new System.EventHandler(this.comboBoxproducts_SelectedValueChanged);
            // 
            // groupBoxactions
            // 
            this.groupBoxactions.Controls.Add(this.btnvieworders);
            this.groupBoxactions.Controls.Add(this.btndelete);
            this.groupBoxactions.Controls.Add(this.btnupdate);
            this.groupBoxactions.Controls.Add(this.btnadd);
            this.groupBoxactions.Controls.Add(this.btnview);
            this.groupBoxactions.Location = new System.Drawing.Point(12, 144);
            this.groupBoxactions.Name = "groupBoxactions";
            this.groupBoxactions.Size = new System.Drawing.Size(200, 248);
            this.groupBoxactions.TabIndex = 8;
            this.groupBoxactions.TabStop = false;
            this.groupBoxactions.Visible = false;
            // 
            // btnvieworders
            // 
            this.btnvieworders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnvieworders.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvieworders.ForeColor = System.Drawing.Color.Black;
            this.btnvieworders.Location = new System.Drawing.Point(6, 203);
            this.btnvieworders.Name = "btnvieworders";
            this.btnvieworders.Size = new System.Drawing.Size(176, 40);
            this.btnvieworders.TabIndex = 9;
            this.btnvieworders.Text = "View Orders";
            this.btnvieworders.UseVisualStyleBackColor = false;
            this.btnvieworders.Click += new System.EventHandler(this.btnvieworders_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btndelete.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Location = new System.Drawing.Point(6, 157);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(176, 40);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = "Delete Product";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnupdate.Font = new System.Drawing.Font("Leelawadee UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.Black;
            this.btnupdate.Location = new System.Drawing.Point(6, 111);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(176, 40);
            this.btnupdate.TabIndex = 7;
            this.btnupdate.Text = "Update Product";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // groupBoxdata
            // 
            this.groupBoxdata.Controls.Add(this.txtbximageloc);
            this.groupBoxdata.Controls.Add(this.comboBoxstatus);
            this.groupBoxdata.Controls.Add(this.lblstatus);
            this.groupBoxdata.Controls.Add(this.btngetimage);
            this.groupBoxdata.Controls.Add(this.picturebxproduct);
            this.groupBoxdata.Controls.Add(this.btnsave);
            this.groupBoxdata.Controls.Add(this.lblimageloc);
            this.groupBoxdata.Controls.Add(this.txtbxprice);
            this.groupBoxdata.Controls.Add(this.txtbxingredients);
            this.groupBoxdata.Controls.Add(this.txtbxproductname);
            this.groupBoxdata.Controls.Add(this.label3);
            this.groupBoxdata.Controls.Add(this.lblingredients);
            this.groupBoxdata.Controls.Add(this.lblproductname);
            this.groupBoxdata.Location = new System.Drawing.Point(454, 209);
            this.groupBoxdata.Name = "groupBoxdata";
            this.groupBoxdata.Size = new System.Drawing.Size(634, 322);
            this.groupBoxdata.TabIndex = 9;
            this.groupBoxdata.TabStop = false;
            this.groupBoxdata.Visible = false;
            // 
            // txtbximageloc
            // 
            this.txtbximageloc.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbximageloc.Location = new System.Drawing.Point(157, 234);
            this.txtbximageloc.Name = "txtbximageloc";
            this.txtbximageloc.Size = new System.Drawing.Size(166, 33);
            this.txtbximageloc.TabIndex = 21;
            // 
            // comboBoxstatus
            // 
            this.comboBoxstatus.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxstatus.FormattingEnabled = true;
            this.comboBoxstatus.Items.AddRange(new object[] {
            "in Stock",
            "out of Stock"});
            this.comboBoxstatus.Location = new System.Drawing.Point(157, 185);
            this.comboBoxstatus.Name = "comboBoxstatus";
            this.comboBoxstatus.Size = new System.Drawing.Size(166, 33);
            this.comboBoxstatus.TabIndex = 18;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.Location = new System.Drawing.Point(53, 193);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(77, 25);
            this.lblstatus.TabIndex = 17;
            this.lblstatus.Text = "Status :";
            // 
            // btngetimage
            // 
            this.btngetimage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btngetimage.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetimage.Location = new System.Drawing.Point(316, 234);
            this.btngetimage.Name = "btngetimage";
            this.btngetimage.Size = new System.Drawing.Size(49, 35);
            this.btngetimage.TabIndex = 16;
            this.btngetimage.Text = " ...";
            this.btngetimage.UseVisualStyleBackColor = false;
            this.btngetimage.Visible = false;
            this.btngetimage.Click += new System.EventHandler(this.btngetimage_Click);
            // 
            // picturebxproduct
            // 
            this.picturebxproduct.BackColor = System.Drawing.Color.White;
            this.picturebxproduct.Location = new System.Drawing.Point(370, 36);
            this.picturebxproduct.Name = "picturebxproduct";
            this.picturebxproduct.Size = new System.Drawing.Size(274, 194);
            this.picturebxproduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebxproduct.TabIndex = 15;
            this.picturebxproduct.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnsave.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(157, 280);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(111, 35);
            this.btnsave.TabIndex = 14;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Visible = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblimageloc
            // 
            this.lblimageloc.AutoSize = true;
            this.lblimageloc.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimageloc.Location = new System.Drawing.Point(19, 237);
            this.lblimageloc.Name = "lblimageloc";
            this.lblimageloc.Size = new System.Drawing.Size(113, 25);
            this.lblimageloc.TabIndex = 12;
            this.lblimageloc.Text = "Image Loc :";
            // 
            // txtbxprice
            // 
            this.txtbxprice.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxprice.Location = new System.Drawing.Point(157, 134);
            this.txtbxprice.MaxLength = 4;
            this.txtbxprice.Name = "txtbxprice";
            this.txtbxprice.Size = new System.Drawing.Size(166, 33);
            this.txtbxprice.TabIndex = 11;
            // 
            // txtbxingredients
            // 
            this.txtbxingredients.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxingredients.Location = new System.Drawing.Point(157, 84);
            this.txtbxingredients.MaxLength = 199;
            this.txtbxingredients.Name = "txtbxingredients";
            this.txtbxingredients.Size = new System.Drawing.Size(166, 33);
            this.txtbxingredients.TabIndex = 10;
            // 
            // txtbxproductname
            // 
            this.txtbxproductname.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxproductname.Location = new System.Drawing.Point(157, 36);
            this.txtbxproductname.MaxLength = 59;
            this.txtbxproductname.Name = "txtbxproductname";
            this.txtbxproductname.Size = new System.Drawing.Size(166, 33);
            this.txtbxproductname.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Price :";
            // 
            // lblingredients
            // 
            this.lblingredients.AutoSize = true;
            this.lblingredients.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblingredients.Location = new System.Drawing.Point(7, 92);
            this.lblingredients.Name = "lblingredients";
            this.lblingredients.Size = new System.Drawing.Size(129, 25);
            this.lblingredients.TabIndex = 7;
            this.lblingredients.Text = "Ingredients : ";
            // 
            // lblproductname
            // 
            this.lblproductname.AutoSize = true;
            this.lblproductname.Font = new System.Drawing.Font("Leelawadee UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproductname.Location = new System.Drawing.Point(56, 44);
            this.lblproductname.Name = "lblproductname";
            this.lblproductname.Size = new System.Drawing.Size(74, 25);
            this.lblproductname.TabIndex = 6;
            this.lblproductname.Text = "Name :";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 260);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BusinessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1100, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxdata);
            this.Controls.Add(this.groupBoxactions);
            this.Controls.Add(this.comboBoxproducts);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.groupBoxnoname);
            this.Controls.Add(this.lblrestourantname);
            this.Name = "BusinessForm";
            this.Text = "Business";
            this.groupBoxnoname.ResumeLayout(false);
            this.groupBoxnoname.PerformLayout();
            this.groupBoxactions.ResumeLayout(false);
            this.groupBoxdata.ResumeLayout(false);
            this.groupBoxdata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebxproduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxrestorantname;
        private System.Windows.Forms.Button btnset;
        private System.Windows.Forms.Label lblrestourantname;
        private System.Windows.Forms.GroupBox groupBoxnoname;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.TextBox txtbxloc;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.ComboBox comboBoxproducts;
        private System.Windows.Forms.GroupBox groupBoxactions;
        private System.Windows.Forms.GroupBox groupBoxdata;
        private System.Windows.Forms.TextBox txtbxprice;
        private System.Windows.Forms.TextBox txtbxingredients;
        private System.Windows.Forms.TextBox txtbxproductname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblingredients;
        private System.Windows.Forms.Label lblproductname;
        private System.Windows.Forms.Label lblimageloc;
        private System.Windows.Forms.PictureBox picturebxproduct;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btngetimage;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.ComboBox comboBoxstatus;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.TextBox txtbximageloc;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnvieworders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}