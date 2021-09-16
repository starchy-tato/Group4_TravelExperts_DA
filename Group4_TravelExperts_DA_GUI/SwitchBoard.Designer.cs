﻿
namespace Group4_TravelExperts_DA_GUI
{
    partial class frmSwitchBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSB = new System.Windows.Forms.Label();
            this.btnPackages = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSB
            // 
            this.lblSB.AutoSize = true;
            this.lblSB.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSB.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblSB.Location = new System.Drawing.Point(94, 51);
            this.lblSB.Name = "lblSB";
            this.lblSB.Size = new System.Drawing.Size(356, 65);
            this.lblSB.TabIndex = 0;
            this.lblSB.Text = "SWITCHBOARD";
            // 
            // btnPackages
            // 
            this.btnPackages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnPackages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPackages.Location = new System.Drawing.Point(28, 159);
            this.btnPackages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPackages.Name = "btnPackages";
            this.btnPackages.Size = new System.Drawing.Size(91, 34);
            this.btnPackages.TabIndex = 1;
            this.btnPackages.Text = "Packages";
            this.btnPackages.UseVisualStyleBackColor = false;
            this.btnPackages.Click += new System.EventHandler(this.btnPackages_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProducts.Location = new System.Drawing.Point(149, 159);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(91, 34);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSuppliers.Location = new System.Drawing.Point(268, 159);
            this.btnSuppliers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(91, 34);
            this.btnSuppliers.TabIndex = 3;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightCoral;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(442, 159);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 33);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSwitchBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 226);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnPackages);
            this.Controls.Add(this.lblSB);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSwitchBoard";
            this.Text = "Travel Experts Main";
            this.Load += new System.EventHandler(this.frmSwitchBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSB;
        private System.Windows.Forms.Button btnPackages;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnExit;
    }
}

