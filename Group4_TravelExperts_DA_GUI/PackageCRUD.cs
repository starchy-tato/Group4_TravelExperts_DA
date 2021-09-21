using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace Group4_TravelExperts_DA_GUI
{
    public partial class frmPackageCRUD : Form
    {
        public Package package = null;
        public string formAction = "";
        public frmPackageCRUD()
        {
            InitializeComponent();
        }

        private void frmPackageCRUD_Load(object sender, EventArgs e)
        {
            
            // Refresh Grids on load of form
            RefreshGrids();

            if (formAction == "Add") // Add
            {
                this.Text = "Add Product";
                btnAccept.Text = "&Add";

            }
            else
            {
                this.Text = "Update Package";
                if (package == null) // check if a product was defined
                {
                    MessageBox.Show("Sent product does not exist.", "Update Error");
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close(); // close this form
                }
                // display current product for update
                txtPkgeName.Text = package.PkgName;
                txtPkgeDesc.Text = package.PkgDesc;
                dtpPkgStartDate.Value = package.PkgStartDate.Value;
                dtpPkgEndDate.Value = package.PkgEndDate.Value;
                txtPkgeBasePrice.Text = Math.Round(package.PkgBasePrice, 2).ToString();
                txtPkgeCommission.Text = Math.Round(package.PkgAgencyCommission.Value, 2).ToString();
                //txtPkgeBasePrice.Text = package.PkgBasePrice.ToString();
                //txtPkgeCommission.Text = package.PkgAgencyCommission.ToString();
                btnAccept.Text = "&Update";
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string basePriceString = txtPkgeBasePrice.Text.Replace("$", "");
            string agencyCommisionString = txtPkgeCommission.Text.Replace("$", "");
            if (formAction == "Add")
            {
                // Validate entered information before adding a new product

                if(Validator.IsPresent(txtPkgeName) &&
                    Validator.IsPresent(txtPkgeDesc) &&
                    Validator.IsPresent(txtPkgeBasePrice) &&
                    Validator.IsNonNegativeDecimal(txtPkgeBasePrice) &&
                    Validator.IsPresent(txtPkgeCommission) &&
                    Validator.IsNonNegativeDecimal(txtPkgeCommission) &&
                    Validator.IsValidPackageDates(dtpPkgStartDate, dtpPkgEndDate) &&
                    Validator.IsValidCommissionAmount(txtPkgeBasePrice, txtPkgeCommission))
                {
                    package = new Package();
                    package.PkgName = txtPkgeName.Text;
                    package.PkgStartDate = dtpPkgStartDate.Value;
                    package.PkgEndDate = dtpPkgEndDate.Value;
                    package.PkgDesc = txtPkgeDesc.Text;
                    package.PkgBasePrice = Convert.ToDecimal(txtPkgeBasePrice.Text);
                    package.PkgAgencyCommission = Convert.ToDecimal(txtPkgeCommission.Text);
                    // get confirmation
                    DialogResult answer = MessageBox.Show($"Are you sure to create this new package?",
                            "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (answer == DialogResult.Yes) // confirmed
                        {
                            try
                            {
                                // if success, add package to database and clear the product object.
                                PackageProductManager.AddPackage(package);
                                package = null;
                                // Ask user if they want to continue entering more packages
                                DialogResult more = MessageBox.Show($"Continue entering packages?",
                            "Confirm continue adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (more == DialogResult.Yes)
                                {
                                    // Continue entering packages unti user hits cancel button
                                    txtPkgeName.Text = string.Empty;
                                }
                                else this.DialogResult = DialogResult.Cancel;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error when adding package: {ex.Message + "****" + ex.InnerException}",
                                                ex.GetType().ToString());
                            }
                        }
                        else // not confirmed
                        {
                            // only cancel the dialog box, but will allow user to continue adding more products
                            MessageBox.Show("Add cancelled");
                            //this.DialogResult = DialogResult.Cancel;
                        }
                }              
            }
            else
            {
                /*
                 * Process update of product
                 */
                if (package == null) // no current customer
                {
                    MessageBox.Show("There is no valid package to modify", "Package Modification Error");
                    return;
                }
                // Validate updated values
                if (Validator.IsPresent(txtPkgeName) &&
                    Validator.IsPresent(txtPkgeDesc) &&
                    Validator.IsPresent(txtPkgeBasePrice) &&
                    Validator.IsNonNegativeDecimal(txtPkgeBasePrice) &&
                    Validator.IsPresent(txtPkgeCommission) &&
                    Validator.IsNonNegativeDecimal(txtPkgeCommission) &&
                    Validator.IsValidPackageDates(dtpPkgStartDate, dtpPkgEndDate) &&
                    Validator.IsValidCommissionAmount(txtPkgeBasePrice, txtPkgeCommission))
                {
                    package.PkgName = txtPkgeName.Text;
                    package.PkgStartDate = dtpPkgStartDate.Value;
                    package.PkgEndDate = dtpPkgEndDate.Value;
                    package.PkgDesc = txtPkgeDesc.Text;
                    package.PkgBasePrice = Convert.ToDecimal(txtPkgeBasePrice.Text);
                    package.PkgAgencyCommission = Convert.ToDecimal(txtPkgeCommission.Text);
                    // get confirmation from user
                    DialogResult answer = MessageBox.Show($"Are you sure to update Package: {package.PkgName}?",
                    "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes) // confirmed
                    {
                        try
                        {
                            PackageProductManager.UpdatePackage(package);
                            package = null;
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error when updating package: {ex.Message}",
                                            ex.GetType().ToString());
                        }
                    }
                    else // confirmation to cancel operation
                    {
                        MessageBox.Show("Package update cancelled");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }
        public void RefreshGrids()
        {
            if (package == null) return;
            else
            {
                // Product Supplier DataGridView
                dgvPkgeProducts.DataSource = PackageProductManager.GetPackageProductSuppliers(package.PackageId);
                //dgvProdSuppliers.Columns[0].Width = 0;
                dgvPkgeProducts.Columns[0].Visible = false;
                dgvPkgeProducts.Columns[1].Width = 150;
                dgvPkgeProducts.Columns[1].HeaderText = "Product";
                dgvPkgeProducts.Columns[2].Width = 300;
                dgvPkgeProducts.Columns[2].HeaderText = "Supplier";
                dgvPkgeProducts.AutoGenerateColumns = false;
                //dgvProdSuppliers.Sort(dgvProdSuppliers.Columns[1], ListSortDirection.Ascending);
                dgvPkgeProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                dgvPkgeProducts.ClearSelection();

                // All Supplier DataGridView

                dgvAllProducts.DataSource = PackageProductManager.GetAllSupplierProducts();
                dgvAllProducts.Columns[0].Visible = false;
                dgvAllProducts.Columns[1].Width = 150;
                dgvAllProducts.Columns[1].HeaderText = "Product";
                dgvAllProducts.Columns[2].Width = 300;
                dgvAllProducts.Columns[2].HeaderText = "Supplier";
                dgvAllProducts.AutoGenerateColumns = false;
                //dgvProdSuppliers.Sort(dgvProdSuppliers.Columns[1], ListSortDirection.Ascending);
                dgvAllProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvAllProducts.ClearSelection();

            }
        }

        private void dgvAllProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPkgeProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPkgeProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow aRow = dgvPkgeProducts.SelectedRows[0];
            try
            {
                // Try remove a ProductSupplier record by submitting its primary key value
                if (PackageProductManager.RemovePkgProdSupplier(package.PackageId, Convert.ToInt32(aRow.Cells[0].Value)))
                    MessageBox.Show("Product was successfully removed from this package.");
                else
                    MessageBox.Show("That product is not part of the current package.");
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                MessageBox.Show("Product cannot be removed from this package at this time ...", "Unable to remove selected product");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product cannot be removed from this package at this time ...", "Unable to selected product");
            }

            RefreshGrids();
        }

        private void dgvAllProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            PackagesProductsSupplier newPPS = null;
            newPPS = new PackagesProductsSupplier();
            DataGridViewRow aRow = dgvAllProducts.SelectedRows[0];
            try
            {
                // Try adding a new ProductSupplier record by inserting (ProductId, SupplierId)
                if (PackageProductManager.AddProductSupplier(package.PackageId, Convert.ToInt32(aRow.Cells[0].Value)))
                    MessageBox.Show($"Prouct has been added for package {aRow.Cells[0].Value.ToString()}");
                else
                    MessageBox.Show("Product is already part of this package.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when adding Product Supplier record ======>" + ex.Message);
            }
            RefreshGrids();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if (dgvAllProducts.CurrentRow.Index == -1) return;

            PackagesProductsSupplier newPPS = null;
            newPPS = new PackagesProductsSupplier();
            DataGridViewRow aRow = dgvAllProducts.SelectedRows[0];
            try
            {
                // Try adding a new ProductSupplier record by inserting (ProductId, SupplierId)
                if (PackageProductManager.AddProductSupplier(package.PackageId, Convert.ToInt32(aRow.Cells[0].Value)))
                    MessageBox.Show($"Prouct has been added for package {aRow.Cells[0].Value.ToString()}");
                else
                    MessageBox.Show("Product is already part of this package.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when adding Product Supplier record ======>" + ex.Message);
            }
            RefreshGrids();
        }

        private void btnRemoveProd_Click(object sender, EventArgs e)
        {
            if (dgvPkgeProducts.CurrentRow.Index == -1) return;
            DataGridViewRow aRow = dgvPkgeProducts.SelectedRows[0];
            try
            {
                // Try remove a ProductSupplier record by submitting its primary key value
                if (PackageProductManager.RemovePkgProdSupplier(package.PackageId, Convert.ToInt32(aRow.Cells[0].Value)))
                    MessageBox.Show("Product was successfully removed from this package.");
                else
                    MessageBox.Show("That product is not part of the current package.");
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                MessageBox.Show("Product cannot be removed from this package at this time ...", "Unable to remove selected product");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product cannot be removed from this package at this time ...", "Unable to selected product");
            }

            RefreshGrids();
        }
    }// class
}// namespace
