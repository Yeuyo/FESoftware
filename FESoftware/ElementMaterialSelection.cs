using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FESoftware
{
    public partial class ElementMaterialSelection : Form
    {
        public ElementMaterialSelection()
        {
            InitializeComponent();
            dataGridView1.DataSource = MainInterface.Materials.Select(vector => new { Name = vector.Name, YoungModulus = vector.YoungModulus, PoissonRatio = vector.PoissonRatio, Rho = vector.Rho }).ToList();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (selectedRowCount > 1)
                {
                    MessageBox.Show("Please select one row at a time.");
                }
                else
                {
                    MainInterface.Etopol_Material.Add(dataGridView1.SelectedRows[0].Index);
                    this.Close();
                }
            }
        }
    }
}
