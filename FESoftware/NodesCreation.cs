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
    public partial class NodesCreation : Form
    {
        public NodesCreation()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            PreprocessingModelling.addNodes(Convert.ToDouble(xCoordinate.Text), Convert.ToDouble(yCoordinate.Text), Convert.ToDouble(zCoordinate.Text));
            this.Close();
        }
    }
}