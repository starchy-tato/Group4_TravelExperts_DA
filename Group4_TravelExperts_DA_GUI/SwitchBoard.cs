using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group4_TravelExperts_DA_GUI
{
    public partial class frmSwitchBoard : Form
    {
        public frmSwitchBoard()
        {
            InitializeComponent();
        }

        private void frmSwitchBoard_Load(object sender, EventArgs e)
        {
            
        }

  

        private void btnPackages_Click(object sender, EventArgs e)
        {
            frmPackages packagesForm = new frmPackages();

            DialogResult result = packagesForm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts productsForm = new frmProducts();

            DialogResult result = productsForm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers suppliersForm = new frmSuppliers();

            DialogResult result = suppliersForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
