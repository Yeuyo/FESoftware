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
    public partial class LoadsAndBoundaryConditions : Form
    {
        public LoadsAndBoundaryConditions()
        {
            InitializeComponent();
            dataGridView1.DataSource = MainInterface.Nodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z, XLoading = vector.XLoading, YLoading = vector.YLoading, ZLoading = vector.ZLoading, XBoundaryCondition = vector.XBoundaryCondition, YBoundaryCondition = vector.YBoundaryCondition, ZBoundaryCondition = vector.ZBoundaryCondition }).ToList();
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
                    LoadingEdit nodeLoadEdit = new LoadingEdit(dataGridView1.SelectedRows[0].Index);
                    nodeLoadEdit.ShowDialog();
                    dataGridView1.DataSource = MainInterface.Nodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z, XLoading = vector.XLoading, YLoading = vector.YLoading, ZLoading = vector.ZLoading, XBoundaryCondition = vector.XBoundaryCondition, YBoundaryCondition = vector.YBoundaryCondition, ZBoundaryCondition = vector.ZBoundaryCondition, XDefinedDisplacement = vector.XDefinedDisplacement, YDefinedDisplacement = vector.YDefinedDisplacement, ZDefinedDisplacement = vector.ZDefinedDisplacement }).ToList();
                }
            }
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
                    BoundaryConditionEdit nodeBoundaryConditionEdit = new BoundaryConditionEdit(dataGridView1.SelectedRows[0].Index);
                    nodeBoundaryConditionEdit.ShowDialog();
                    dataGridView1.DataSource = MainInterface.Nodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z, XLoading = vector.XLoading, YLoading = vector.YLoading, ZLoading = vector.ZLoading, XBoundaryCondition = vector.XBoundaryCondition, YBoundaryCondition = vector.YBoundaryCondition, ZBoundaryCondition = vector.ZBoundaryCondition, XDefinedDisplacement = vector.XDefinedDisplacement, YDefinedDisplacement = vector.YDefinedDisplacement, ZDefinedDisplacement = vector.ZDefinedDisplacement }).ToList();
                }
            }
        }
    }
}
