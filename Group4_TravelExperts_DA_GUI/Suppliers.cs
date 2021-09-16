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
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            PopulateSuppliers();
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnUpdate.Enabled = false;
        }

        private void PopulateSuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var suppliers = db.Suppliers.Select(s => new
                {
                    s.SupplierId,
                    s.SupName
                }).ToList();


                dgvSuppliers.DataSource = suppliers;

                dgvSuppliers.Columns[0].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvSuppliers.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvSuppliers.Columns[1].Width = 350; // Description - with in pixels

                dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                //dgvProducts.EnableHeadersVisualStyles = false;
                dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                // format the grid itself - alternating backcolor
                dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
