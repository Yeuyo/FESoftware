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
    public partial class BoundaryConditionEdit : Form
    {
        int Selection;
        public BoundaryConditionEdit(int selection)
        {
            Selection = selection;
            InitializeComponent();
            textBox1.Text = MainInterface.Nodes[Selection].XBoundaryCondition.ToString();
            textBox2.Text = MainInterface.Nodes[Selection].YBoundaryCondition.ToString();
            textBox3.Text = MainInterface.Nodes[Selection].ZBoundaryCondition.ToString();
            textBox4.Text = MainInterface.Nodes[Selection].XDefinedDisplacement.ToString();
            textBox5.Text = MainInterface.Nodes[Selection].YDefinedDisplacement.ToString();
            textBox6.Text = MainInterface.Nodes[Selection].ZDefinedDisplacement.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreprocessingModelling.addNodesBoundaryCondition(Selection, Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text));
            PreprocessingModelling.addNodesDefinedDisplacement(Selection, Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text));
            this.Close();
        }
    }
}
