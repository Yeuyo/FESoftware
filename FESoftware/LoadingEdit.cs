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
    public partial class LoadingEdit : Form
    {
        int Selection;
        public LoadingEdit(int selection)
        {
            Selection = selection;
            InitializeComponent();
            textBox1.Text = MainInterface.Nodes[Selection].XLoading.ToString();
            textBox2.Text = MainInterface.Nodes[Selection].YLoading.ToString();
            textBox3.Text = MainInterface.Nodes[Selection].ZLoading.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreprocessingModelling.addNodesLoading(Selection, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
            this.Close();
        }
    }
}
