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
    public partial class MaterialsSetting : Form
    {
        public MaterialsSetting()
        {
            InitializeComponent();
            dataGridView1.DataSource = MainInterface.Materials.Select(vector => new { Name = vector.Name, YoungModulus = vector.YoungModulus, PoissonRatio = vector.PoissonRatio, Rho = vector.Rho }).ToList();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaterialsCreation addMaterials = new MaterialsCreation(0, -1);
            addMaterials.ShowDialog();
            dataGridView1.DataSource = MainInterface.Materials.Select(vector => new { Name = vector.Name, YoungModulus = vector.YoungModulus, PoissonRatio = vector.PoissonRatio, Rho = vector.Rho }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    MaterialsCreation addMaterials = new MaterialsCreation(1, dataGridView1.SelectedRows[0].Index);
                    addMaterials.ShowDialog();
                    dataGridView1.DataSource = MainInterface.Materials.Select(vector => new { Name = vector.Name, YoungModulus = vector.YoungModulus, PoissonRatio = vector.PoissonRatio, Rho = vector.Rho }).ToList();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    MainInterface.Materials.RemoveAt(dataGridView1.SelectedRows[i].Index);
                    // TODO: Need to update elements/etopol information accordingly
                }
                dataGridView1.DataSource = MainInterface.Materials.Select(vector => new { Name = vector.Name, YoungModulus = vector.YoungModulus, PoissonRatio = vector.PoissonRatio, Rho = vector.Rho }).ToList();
            }
        }
    }
}
