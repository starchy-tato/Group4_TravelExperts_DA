
namespace Group4_TravelExperts_DA_GUI
{
    partial class frmPackageCRUD
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPkgeName = new System.Windows.Forms.Label();
            this.lblPkgeSDate = new System.Windows.Forms.Label();
            this.lblPkgeEDate = new System.Windows.Forms.Label();
            this.lblPkgeDesc = new System.Windows.Forms.Label();
            this.lblPkgeBasePrice = new System.Windows.Forms.Label();
            this.txtPkgeName = new System.Windows.Forms.TextBox();
            this.txtPkgeDesc = new System.Windows.Forms.TextBox();
            this.txtPkgeBasePrice = new System.Windows.Forms.TextBox();
            this.txtPkgeCommission = new System.Windows.Forms.TextBox();
            this.lblPkgeCommission = new System.Windows.Forms.Label();
            this.dtpPkgStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPkgEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgvPkgeProducts = new System.Windows.Forms.DataGridView();
            this.dgvAllProducts = new System.Windows.Forms.DataGridView();
            this.btnRemoveProd = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPkgeProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(5, 526);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(94, 29);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(125, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPkgeName
            // 
            this.lblPkgeName.AutoSize = true;
            this.lblPkgeName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPkgeName.Location = new System.Drawing.Point(52, 95);
            this.lblPkgeName.Name = "lblPkgeName";
            this.lblPkgeName.Size = new System.Drawing.Size(60, 23);
            this.lblPkgeName.TabIndex = 2;
            this.lblPkgeName.Text = "Name:";
            // 
            // lblPkgeSDate
            // 
            this.lblPkgeSDate.AutoSize = true;
            this.lblPkgeSDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPkgeSDate.Location = new System.Drawing.Point(22, 150);
            this.lblPkgeSDate.Name = "lblPkgeSDate";
            this.lblPkgeSDate.Size = new System.Drawing.Size(90, 23);
            this.lblPkgeSDate.TabIndex = 3;
            this.lblPkgeSDate.Text = "Start Date:";
            // 
            // lblPkgeEDate
            // 
            this.lblPkgeEDate.AutoSize = true;
            this.lblPkgeEDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPkgeEDate.Location = new System.Drawing.Point(28, 210);
            this.lblPkgeEDate.Name = "lblPkgeEDate";
            this.lblPkgeEDate.Size = new System.Drawing.Size(84, 23);
            this.lblPkgeEDate.TabIndex = 4;
            this.lblPkgeEDate.Text = "End Date:";
            // 
            // lblPkgeDesc
            // 
            this.lblPkgeDesc.AutoSize = true;
            this.lblPkgeDesc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPkgeDesc.Location = new System.Drawing.Point(12, 282);
            this.lblPkgeDesc.Name = "lblPkgeDesc";
            this.lblPkgeDesc.Size = new System.Drawing.Size(100, 23);
            this.lblPkgeDesc.TabIndex = 5;
            this.lblPkgeDesc.Text = "Description:";
            // 
            // lblPkgeBasePrice
            // 
            this.lblPkgeBasePrice.AutoSize = true;
            this.lblPkgeBasePrice.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPkgeBasePrice.Location = new System.Drawing.Point(21, 400);
            this.lblPkgeBasePrice.Name = "lblPkgeBasePrice";
            this.lblPkgeBasePrice.Size = new System.Drawing.Size(91, 23);
            this.lblPkgeBasePrice.TabIndex = 6;
            this.lblPkgeBasePrice.Text = "Base Price:";
            // 
            // txtPkgeName
            // 
            this.txtPkgeName.Location = new System.Drawing.Point(125, 94);
            this.txtPkgeName.Name = "txtPkgeName";
            this.txtPkgeName.Size = new System.Drawing.Size(250, 27);
            this.txtPkgeName.TabIndex = 7;
            this.txtPkgeName.Tag = "Package Name";
            // 
            // txtPkgeDesc
            // 
            this.txtPkgeDesc.Location = new System.Drawing.Point(125, 282);
            this.txtPkgeDesc.Multiline = true;
            this.txtPkgeDesc.Name = "txtPkgeDesc";
            this.txtPkgeDesc.Size = new System.Drawing.Size(250, 81);
            this.txtPkgeDesc.TabIndex = 8;
            this.txtPkgeDesc.Tag = "Package Description";
            // 
            // txtPkgeBasePrice
            // 
            this.txtPkgeBasePrice.Location = new System.Drawing.Point(125, 399);
            this.txtPkgeBasePrice.Name = "txtPkgeBasePrice";
            this.txtPkgeBasePrice.Size = new System.Drawing.Size(125, 27);
            this.txtPkgeBasePrice.TabIndex = 9;
            this.txtPkgeBasePrice.Tag = "Base Price";
            // 
            // txtPkgeCommission
            // 
            this.txtPkgeCommission.Location = new System.Drawing.Point(125, 457);
            this.txtPkgeCommission.Name = "txtPkgeCommission";
            this.txtPkgeCommission.Size = new System.Drawing.Size(125, 27);
            this.txtPkgeCommission.TabIndex = 10;
            this.txtPkgeCommission.Tag = "Agency Commission";
            // 
            // lblPkgeCommission
            // 
            this.lblPkgeCommission.AutoSize = true;
            this.lblPkgeCommission.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPkgeCommission.Location = new System.Drawing.Point(5, 457);
            this.lblPkgeCommission.Name = "lblPkgeCommission";
            this.lblPkgeCommission.Size = new System.Drawing.Size(107, 23);
            this.lblPkgeCommission.TabIndex = 11;
            this.lblPkgeCommission.Text = "Commission:";
            // 
            // dtpPkgStartDate
            // 
            this.dtpPkgStartDate.Location = new System.Drawing.Point(125, 150);
            this.dtpPkgStartDate.Name = "dtpPkgStartDate";
            this.dtpPkgStartDate.Size = new System.Drawing.Size(250, 27);
            this.dtpPkgStartDate.TabIndex = 12;
            // 
            // dtpPkgEndDate
            // 
            this.dtpPkgEndDate.Location = new System.Drawing.Point(125, 219);
            this.dtpPkgEndDate.Name = "dtpPkgEndDate";
            this.dtpPkgEndDate.Size = new System.Drawing.Size(250, 27);
            this.dtpPkgEndDate.TabIndex = 13;
            // 
            // dgvPkgeProducts
            // 
            this.dgvPkgeProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPkgeProducts.Location = new System.Drawing.Point(411, 94);
            this.dgvPkgeProducts.Name = "dgvPkgeProducts";
            this.dgvPkgeProducts.RowHeadersWidth = 51;
            this.dgvPkgeProducts.RowTemplate.Height = 29;
            this.dgvPkgeProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPkgeProducts.Size = new System.Drawing.Size(524, 195);
            this.dgvPkgeProducts.TabIndex = 14;
            this.dgvPkgeProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPkgeProducts_CellClick);
            this.dgvPkgeProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPkgeProducts_CellDoubleClick);
            // 
            // dgvAllProducts
            // 
            this.dgvAllProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllProducts.Location = new System.Drawing.Point(1001, 91);
            this.dgvAllProducts.Name = "dgvAllProducts";
            this.dgvAllProducts.RowHeadersWidth = 51;
            this.dgvAllProducts.RowTemplate.Height = 29;
            this.dgvAllProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllProducts.Size = new System.Drawing.Size(543, 389);
            this.dgvAllProducts.TabIndex = 15;
            this.dgvAllProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllProducts_CellClick);
            this.dgvAllProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllProducts_CellDoubleClick);
            // 
            // btnRemoveProd
            // 
            this.btnRemoveProd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveProd.Location = new System.Drawing.Point(941, 144);
            this.btnRemoveProd.Name = "btnRemoveProd";
            this.btnRemoveProd.Size = new System.Drawing.Size(50, 29);
            this.btnRemoveProd.TabIndex = 16;
            this.btnRemoveProd.Text = ">>";
            this.btnRemoveProd.UseVisualStyleBackColor = true;
            this.btnRemoveProd.Click += new System.EventHandler(this.btnRemoveProd_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddProd.Location = new System.Drawing.Point(941, 204);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(50, 29);
            this.btnAddProd.TabIndex = 17;
            this.btnAddProd.Text = "<<";
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // frmPackageCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 652);
            this.Controls.Add(this.btnAddProd);
            this.Controls.Add(this.btnRemoveProd);
            this.Controls.Add(this.dgvAllProducts);
            this.Controls.Add(this.dgvPkgeProducts);
            this.Controls.Add(this.dtpPkgEndDate);
            this.Controls.Add(this.dtpPkgStartDate);
            this.Controls.Add(this.lblPkgeCommission);
            this.Controls.Add(this.txtPkgeCommission);
            this.Controls.Add(this.txtPkgeBasePrice);
            this.Controls.Add(this.txtPkgeDesc);
            this.Controls.Add(this.txtPkgeName);
            this.Controls.Add(this.lblPkgeBasePrice);
            this.Controls.Add(this.lblPkgeDesc);
            this.Controls.Add(this.lblPkgeEDate);
            this.Controls.Add(this.lblPkgeSDate);
            this.Controls.Add(this.lblPkgeName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmPackageCRUD";
            this.Text = "Package Maintenance";
            this.Load += new System.EventHandler(this.frmPackageCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPkgeProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPkgeName;
        private System.Windows.Forms.Label lblPkgeSDate;
        private System.Windows.Forms.Label lblPkgeEDate;
        private System.Windows.Forms.Label lblPkgeDesc;
        private System.Windows.Forms.Label lblPkgeBasePrice;
        private System.Windows.Forms.TextBox txtPkgeName;
        private System.Windows.Forms.TextBox txtPkgeDesc;
        private System.Windows.Forms.TextBox txtPkgeBasePrice;
        private System.Windows.Forms.TextBox txtPkgeCommission;
        private System.Windows.Forms.Label lblPkgeCommission;
        private System.Windows.Forms.DateTimePicker dtpPkgStartDate;
        private System.Windows.Forms.DateTimePicker dtpPkgEndDate;
        private System.Windows.Forms.DataGridView dgvPkgeProducts;
        private System.Windows.Forms.DataGridView dgvAllProducts;
        private System.Windows.Forms.Button btnRemoveProd;
        private System.Windows.Forms.Button btnAddProd;
    }
}