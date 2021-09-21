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
    public partial class frmProducts : Form
    {
        private Product product; // Define a local variable to hold the current product
        private List<Product> products; // Define a list to hold product
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            PopulateProducts();
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnUpdate.Enabled = false;
        }

        private void PopulateProducts()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var products = db.Products.Select(p => new
                {
                    p.ProductId,
                    p.ProdName
                }).ToList();


                dgvProducts.DataSource = products;

                dgvProducts.Columns[0].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvProducts.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvProducts.Columns[1].Width = 350;

                dgvProducts.Columns[0].HeaderText = "Id";
                dgvProducts.Columns[1].HeaderText = "Name";

                dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                //dgvProducts.EnableHeadersVisualStyles = false;
                dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                // format the grid itself - alternating backcolor
                dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void LoadProductCRUDForm(string action)
        {

            /*
             * Instantiation of product and CRUD form objects.
             * 
             */
            frmProductCRUD crudForm = new frmProductCRUD
            {
                formAction = action,
                product = this.product
            };

            DialogResult result = crudForm.ShowDialog();

            /*
             * After returning from calling CRUD form, trash the product, update the grid view with 
             * the contents of the products list and deselect any rows plus disable
             * the update buttons.
             */
            product = null;
            PopulateProducts();
            dgvProducts.ClearSelection();
            //btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadProductCRUDForm("Add");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadProductCRUDForm("Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LoadProductCRUDForm("Delete");
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            btnUpdate.Enabled = true;
            product = new Product();
            DataGridViewRow aRow = dgvProducts.SelectedRows[0];
            product.ProductId = Convert.ToInt32(aRow.Cells[0].Value);
            product.ProdName = aRow.Cells[1].Value.ToString();

        }
    }
}
