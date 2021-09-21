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
    public partial class frmPackages : Form
    {
        private Package package; // Define a local variable to hold the current product
        private List<Package> packages; // Define a list to hold product
        public frmPackages()
        {
            InitializeComponent();
        }

        private void frmPackages_Load(object sender, EventArgs e)
        {
            PopulatePackages();
            dgvPackages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnUpdate.Enabled = false;
        }

        private void PopulatePackages()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var packages = db.Packages.Select(p => new
                {
                    p.PackageId,
                    p.PkgName,
                    p.PkgStartDate,
                    p.PkgEndDate,
                    p.PkgDesc,
                    p.PkgBasePrice,
                    p.PkgAgencyCommission
                }).ToList();


                dgvPackages.DataSource = packages;

                dgvPackages.Columns[0].DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvPackages.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvPackages.Columns[2].DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvPackages.Columns[3].DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvPackages.Columns[4].DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvPackages.Columns[5].DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgvPackages.Columns[6].DefaultCellStyle.Font = new Font("Segoe UI", 11);

                // Column Headers
                dgvPackages.Columns[0].HeaderText = "Id";
                dgvPackages.Columns[1].HeaderText = "Name";
                dgvPackages.Columns[2].HeaderText = "Start Date";
                dgvPackages.Columns[3].HeaderText = "End Date";
                dgvPackages.Columns[4].HeaderText = "Description";
                dgvPackages.Columns[5].HeaderText = "Base Price";
                dgvPackages.Columns[6].HeaderText = "Commission";

                dgvPackages.Columns[0].Width = 20;
                dgvPackages.Columns[1].Width = 300;

                dgvPackages.Columns[4].Width = 350; // Description - with in pixels
                dgvPackages.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgvPackages.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";

                dgvPackages.Columns[5].DefaultCellStyle.Format = "c";
                dgvPackages.Columns[6].DefaultCellStyle.Format = "c";

                dgvPackages.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                //dgvProducts.EnableHeadersVisualStyles = false;
                dgvPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                // format the grid itself - alternating backcolor
                dgvPackages.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadPackageCRUDForm(string action)
        {

            /*
             * Instantiation of product and CRUD form objects.
             * 
             */
            frmPackageCRUD crudForm = new frmPackageCRUD
            {
                formAction = action,
                package = this.package
            };

            DialogResult result = crudForm.ShowDialog();

            /*
             * After returning from calling CRUD form, trash the product, update the grid view with 
             * the contents of the products list and deselect any rows plus disable
             * the update buttons.
             */
            package = null;
            PopulatePackages();
            dgvPackages.ClearSelection();
            //btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadPackageCRUDForm("Add");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadPackageCRUDForm("Update");
        }

        private void dgvPackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            btnUpdate.Enabled = true;
            package = new Package();
            DataGridViewRow aRow = dgvPackages.SelectedRows[0];
            package.PackageId = Convert.ToInt32(aRow.Cells[0].Value);
            package.PkgName = aRow.Cells[1].Value.ToString();
            package.PkgStartDate = Convert.ToDateTime(aRow.Cells[2].Value);
            package.PkgEndDate = Convert.ToDateTime(aRow.Cells[3].Value);
            package.PkgDesc = aRow.Cells[4].Value.ToString();
            package.PkgBasePrice = Convert.ToDecimal(aRow.Cells[5].Value);
            package.PkgAgencyCommission = Convert.ToDecimal(aRow.Cells[6].Value);
        }
    }
}
