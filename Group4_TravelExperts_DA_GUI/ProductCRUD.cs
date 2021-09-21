using Microsoft.Data.SqlClient;
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
    public partial class frmProductCRUD : Form
    {
        public Product product = null;
        public string formAction = "";

        public frmProductCRUD()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (formAction == "Add")
            {
                // Validate entered information before adding a new product
                if (Validator.IsPresent(txtProdName))
                {
                    product = new Product();
                    product.ProdName = txtProdName.Text;

                    // get confirmation
                    DialogResult answer = MessageBox.Show($"Are you sure to create this new product?",
                        "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes) // confirmed
                    {
                        try
                        {
                            // if success, add product to database and clear the product object.
                            ProductSupplierManager.AddProduct(product);
                            product = null;
                            // Ask user if they want to continue entering more products
                            DialogResult more = MessageBox.Show($"Continue entering products?",
                        "Confirm continue adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (more == DialogResult.Yes)
                            {
                                // Continue entering products unti user hits cancel button
                                txtProdName.Text = string.Empty;
                            }
                            else this.DialogResult = DialogResult.Cancel;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error when adding product: {ex.Message + "****" + ex.InnerException}",
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
                if (product == null) // no current customer
                {
                    MessageBox.Show("There is no valid product to modify", "Product Modification Error");
                    return;
                }
                // Validate updated values
                if (Validator.IsPresent(txtProdName))
                {
                    product.ProdName = txtProdName.Text;
                    // get confirmation from user
                    DialogResult answer = MessageBox.Show($"Are you sure to update product: {product.ProdName}?",
                    "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes) // confirmed
                    {
                        try
                        {
                            ProductSupplierManager.UpdateProduct(product);
                            product = null;
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error when updating product: {ex.Message}",
                                            ex.GetType().ToString());
                        }
                    }
                    else // confirmation to cancel operation
                    {
                        MessageBox.Show("Product update cancelled");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }

        private void frmProductCRUD_Load(object sender, EventArgs e)
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
                this.Text = "Update Product";
                if (product == null) // check if a product was defined
                {
                    MessageBox.Show("Sent product does not exist.", "Update Error");
                    this.DialogResult = DialogResult.Cancel;
                    //this.Close(); // close this form
                }
                // display current product for update
                txtProdName.Text = product.ProdName;
                btnAccept.Text = "&Update";
            }
        }

        public void RefreshGrids()
        {
            if (product == null) return;
            else
            {
                // Product Supplier DataGridView
                dgvProdSuppliers.DataSource = ProductSupplierManager.GetProductSuppliers(product.ProductId);
                //dgvProdSuppliers.Columns[0].Width = 0;
                dgvProdSuppliers.Columns[0].Visible = false;
                dgvProdSuppliers.Columns[1].Width = 450;
                dgvProdSuppliers.Columns[1].HeaderText = "Supplier Name";
                dgvProdSuppliers.AutoGenerateColumns = false;
                //dgvProdSuppliers.Sort(dgvProdSuppliers.Columns[1], ListSortDirection.Ascending);
                dgvProdSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                dgvProdSuppliers.ClearSelection();

                // All Supplier DataGridView

                dgvAllSuppliers.DataSource = ProductSupplierManager.GetAllSuppliers();
                //dgvAllSuppliers.Columns[0].Width = 0;
                //dgvAllSuppliers.Columns[2].Width = 0;
                //dgvAllSuppliers.Columns[3].Width = 0;
                dgvAllSuppliers.Columns[0].Visible = false;
                dgvAllSuppliers.Columns[2].Visible = false;
                dgvAllSuppliers.Columns[3].Visible = false;
                dgvAllSuppliers.Columns[1].Width = 450;
                dgvAllSuppliers.Columns[1].HeaderText = "Supplier Name";
                dgvAllSuppliers.AutoGenerateColumns = false;
                //dgvProdSuppliers.Sort(dgvProdSuppliers.Columns[1], ListSortDirection.Ascending);
                dgvAllSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvAllSuppliers.ClearSelection();

                lblAllSuppliersCount.Text = dgvAllSuppliers.Rows.Count.ToString();
                lblProdSuppliersCount.Text = dgvProdSuppliers.Rows.Count.ToString();
            }
        }

        private void dgvAllSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            ProductsSupplier supplierToAdd = null;
            supplierToAdd = new ProductsSupplier();
            DataGridViewRow aRow = dgvAllSuppliers.SelectedRows[0];
            try
            {
                // Try adding a new ProductSupplier record by inserting (ProductId, SupplierId)
                if(ProductSupplierManager.AddProductSupplier(product.ProductId, Convert.ToInt32(aRow.Cells[0].Value)))
                    MessageBox.Show("Supplier has been added for this product");
                else
                    MessageBox.Show("Product is already being provided by this supplier.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when adding Product Supplier record ======>" + ex.Message);
            }
            RefreshGrids();
        }
            
        
        private void dgvProdSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow aRow = dgvProdSuppliers.SelectedRows[0];
            try
            {
                // Try remove a ProductSupplier record by submitting its primary key value
                if (ProductSupplierManager.RemoveProductSupplier(product.ProductId, Convert.ToInt32(aRow.Cells[0].Value)))
                    MessageBox.Show("Supplier was successfully removed from this product.");
                else
                    MessageBox.Show("Supplier is no longer supplying this product.");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Supplier cannot be removed from this product at this time ...", "Unable to remove this Supplier");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Supplier cannot be removed from this product at this time ...", "Unable to remove this Supplier");
            }
            
            RefreshGrids();
        }
    }// class
}// namespace
