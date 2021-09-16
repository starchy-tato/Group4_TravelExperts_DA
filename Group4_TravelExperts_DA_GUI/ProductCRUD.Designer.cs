
namespace Group4_TravelExperts_DA_GUI
{
    partial class frmProductCRUD
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
            this.lblAllSuppliers = new System.Windows.Forms.Label();
            this.lblProdSuppliers = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.lblProdName = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblAllSuppliersCount = new System.Windows.Forms.Label();
            this.lblProdSuppliersCount = new System.Windows.Forms.Label();
            this.dgvProdSuppliers = new System.Windows.Forms.DataGridView();
            this.dgvAllSuppliers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAllSuppliers
            // 
            this.lblAllSuppliers.AutoSize = true;
            this.lblAllSuppliers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAllSuppliers.Location = new System.Drawing.Point(455, 74);
            this.lblAllSuppliers.Name = "lblAllSuppliers";
            this.lblAllSuppliers.Size = new System.Drawing.Size(93, 19);
            this.lblAllSuppliers.TabIndex = 23;
            this.lblAllSuppliers.Text = "All Suppliers";
            // 
            // lblProdSuppliers
            // 
            this.lblProdSuppliers.AutoSize = true;
            this.lblProdSuppliers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProdSuppliers.Location = new System.Drawing.Point(10, 76);
            this.lblProdSuppliers.Name = "lblProdSuppliers";
            this.lblProdSuppliers.Size = new System.Drawing.Size(173, 19);
            this.lblProdSuppliers.TabIndex = 22;
            this.lblProdSuppliers.Text = "Suppliers of this product";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightCoral;
            this.btnExit.Location = new System.Drawing.Point(798, 30);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 22);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(10, 30);
            this.txtProdName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(447, 23);
            this.txtProdName.TabIndex = 15;
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProdName.Location = new System.Drawing.Point(10, 13);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(62, 19);
            this.lblProdName.TabIndex = 14;
            this.lblProdName.Text = "Product";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btnAccept.Location = new System.Drawing.Point(728, 30);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(65, 22);
            this.btnAccept.TabIndex = 24;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblAllSuppliersCount
            // 
            this.lblAllSuppliersCount.AutoSize = true;
            this.lblAllSuppliersCount.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAllSuppliersCount.Location = new System.Drawing.Point(825, 78);
            this.lblAllSuppliersCount.Name = "lblAllSuppliersCount";
            this.lblAllSuppliersCount.Size = new System.Drawing.Size(10, 13);
            this.lblAllSuppliersCount.TabIndex = 25;
            this.lblAllSuppliersCount.Text = ".";
            // 
            // lblProdSuppliersCount
            // 
            this.lblProdSuppliersCount.AutoSize = true;
            this.lblProdSuppliersCount.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProdSuppliersCount.Location = new System.Drawing.Point(411, 79);
            this.lblProdSuppliersCount.Name = "lblProdSuppliersCount";
            this.lblProdSuppliersCount.Size = new System.Drawing.Size(10, 13);
            this.lblProdSuppliersCount.TabIndex = 26;
            this.lblProdSuppliersCount.Text = ".";
            // 
            // dgvProdSuppliers
            // 
            this.dgvProdSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdSuppliers.Location = new System.Drawing.Point(10, 95);
            this.dgvProdSuppliers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProdSuppliers.Name = "dgvProdSuppliers";
            this.dgvProdSuppliers.RowHeadersWidth = 51;
            this.dgvProdSuppliers.RowTemplate.Height = 29;
            this.dgvProdSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdSuppliers.Size = new System.Drawing.Size(424, 325);
            this.dgvProdSuppliers.TabIndex = 27;
            this.dgvProdSuppliers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdSuppliers_CellDoubleClick);
            // 
            // dgvAllSuppliers
            // 
            this.dgvAllSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSuppliers.Location = new System.Drawing.Point(455, 93);
            this.dgvAllSuppliers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAllSuppliers.Name = "dgvAllSuppliers";
            this.dgvAllSuppliers.RowHeadersWidth = 51;
            this.dgvAllSuppliers.RowTemplate.Height = 29;
            this.dgvAllSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllSuppliers.Size = new System.Drawing.Size(391, 327);
            this.dgvAllSuppliers.TabIndex = 28;
            this.dgvAllSuppliers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllSuppliers_CellDoubleClick);
            // 
            // frmProductCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 442);
            this.Controls.Add(this.dgvAllSuppliers);
            this.Controls.Add(this.dgvProdSuppliers);
            this.Controls.Add(this.lblProdSuppliersCount);
            this.Controls.Add(this.lblAllSuppliersCount);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblAllSuppliers);
            this.Controls.Add(this.lblProdSuppliers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.lblProdName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmProductCRUD";
            this.Text = "Product CRUD";
            this.Load += new System.EventHandler(this.frmProductCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAllSuppliers;
        private System.Windows.Forms.Label lblProdSuppliers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblAllSuppliersCount;
        private System.Windows.Forms.Label lblProdSuppliersCount;
        private System.Windows.Forms.DataGridView dgvProdSuppliers;
        private System.Windows.Forms.DataGridView dgvAllSuppliers;
    }
}