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
    public partial class ElementCreation : Form
    {
        int Nodes_Added;
        int NumberOfNodes;
        public static List<NodesInformation> CurrentEtopolNodes = new List<NodesInformation>();
        public ElementCreation()
        {
            Nodes_Added = 0;
            NumberOfNodes =  PreprocessingModelling.getElementNodesNumber();
            PreprocessingModelling.removeExcessEtopol();
            InitializeComponent();
            dataGridView1.DataSource = MainInterface.Nodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z }).ToList();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0 && Nodes_Added < NumberOfNodes)
            {
                if (selectedRowCount > 1)
                {
                    MessageBox.Show("Please select one row at a time.");
                }
                else
                {
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    if (!CurrentEtopolNodes.Contains(new NodesInformation(MainInterface.Nodes[selectedRowIndex].X, MainInterface.Nodes[selectedRowIndex].Y, MainInterface.Nodes[selectedRowIndex].Z)))
                    {
                        CurrentEtopolNodes.Add(new NodesInformation(MainInterface.Nodes[selectedRowIndex].X, MainInterface.Nodes[selectedRowIndex].Y, MainInterface.Nodes[selectedRowIndex].Z));
                        MainInterface.Etopol.Add(selectedRowIndex);
                        Nodes_Added += 1;
                        if (Nodes_Added == NumberOfNodes)
                        {
                            ElementMaterialSelection addElementMaterial = new ElementMaterialSelection();
                            addElementMaterial.ShowDialog();
                            Nodes_Added = 0;
                            CurrentEtopolNodes.Clear();
                        }
                        dataGridView2.DataSource = CurrentEtopolNodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z }).ToList();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nodes_Added > 0 && Nodes_Added< NumberOfNodes)
            {
                MessageBox.Show("You did not add enough nodes for an element. Nodes you added have been removed.");
                MainInterface.Etopol.RemoveAt(MainInterface.Etopol.Count - Nodes_Added);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainInterface.Etopol.RemoveAt(MainInterface.Etopol.Count - 1);
            CurrentEtopolNodes.RemoveAt(CurrentEtopolNodes.Count - 1);
            dataGridView2.DataSource = CurrentEtopolNodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z }).ToList();
        }
    }
}
