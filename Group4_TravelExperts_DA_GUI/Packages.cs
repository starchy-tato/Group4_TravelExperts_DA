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
        public frmPackages()
        {
            InitializeComponent();
        }

        private void frmPackages_Load(object sender, EventArgs e)
        {
            PopulatePackages();
            dgvPackages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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

                dgvPackages.Columns[0].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvPackages.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvPackages.Columns[2].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvPackages.Columns[3].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvPackages.Columns[4].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvPackages.Columns[5].DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvPackages.Columns[6].DefaultCellStyle.Font = new Font("Segoe UI", 12);

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
    }
}
