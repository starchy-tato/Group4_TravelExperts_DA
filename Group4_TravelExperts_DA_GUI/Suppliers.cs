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
        Supplier supplier = null;
        string formMode = "Add";
        
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            PopulateSuppliers();
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnUpdate.Enabled = false;
            btnAdd.BackColor = Color.GreenYellow;
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
                dgvSuppliers.Columns[0].HeaderText = "Id";
                dgvSuppliers.Columns[1].HeaderText = "Name";
                dgvSuppliers.Columns[1].Width = 300;

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

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            formMode = "Update";
            btnUpdate.Enabled = true;
            btnUpdate.BackColor = Color.GreenYellow;
            btnAdd.BackColor = Color.LightBlue;

            if (e.RowIndex == -1) return;
                DataGridViewRow aRow = dgvSuppliers.SelectedRows[0];

            supplier = new Supplier();
            supplier.SupplierId = Convert.ToInt32(aRow.Cells[0].Value);
            supplier.SupName = aRow.Cells[1].Value.ToString();
            txtSupName.Text = aRow.Cells[1].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(formMode == "Update")
            {
                txtSupName.Text = String.Empty;
                formMode = "Add";
                btnUpdate.Enabled = false;
                dgvSuppliers.ClearSelection();
                btnAdd.BackColor = Color.GreenYellow;
                btnUpdate.BackColor = Color.LightBlue;
            }
            else
            {
                if (Validator.IsPresent(txtSupName))
                {
                    DialogResult answer = MessageBox.Show($"Are you sure to create this new supplier?",
                                "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes) // confirmed
                    {
                        try
                        {
                            Supplier newSupplier = new Supplier();
                            newSupplier.SupName = txtSupName.Text;
                            SupplierManager.AddSupplier(newSupplier);
                            MessageBox.Show($"New Supplier {txtSupName.Text} was created.");
                            PopulateSuppliers();
                            dgvSuppliers.FirstDisplayedScrollingRowIndex = dgvSuppliers.Rows.Count - 1;
                            dgvSuppliers.Rows[dgvSuppliers.Rows.Count - 1].Selected = true;
                            txtSupName.Text = String.Empty;
                            btnUpdate.Enabled = false;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Supplier {txtSupName.Text} " +
                                $"could not be created.=====>> INNER EXCEPTION: ${ ex.InnerException.ToString()} ");
                        }
                    }
                    else
                    {
                        txtSupName.Text = String.Empty;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int currentRowIdx = dgvSuppliers.CurrentRow.Index;

            if (Validator.IsPresent(txtSupName))
            {
                DialogResult answer = MessageBox.Show($"Are you sure to update this supplier?",
                            "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes) // confirmed
                {
                    try
                    {
                        // pass the current supplier with the updated name
                        supplier.SupName = txtSupName.Text;
                        SupplierManager.UpdateSupplier(supplier);
                        MessageBox.Show($"Supplier {txtSupName.Text} was updated.");
                        PopulateSuppliers();
                        dgvSuppliers.FirstDisplayedScrollingRowIndex = currentRowIdx;
                        dgvSuppliers.Rows[currentRowIdx].Selected = true;
                        txtSupName.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Supplier {txtSupName.Text} could not be updated.");
                    }
                }
                else
                {
                    txtSupName.Text = String.Empty;
                    btnUpdate.Enabled = false;
                }

            }
        }

     }  // class
 } // Namespace
