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
    public partial class NewAnalysisChoice : Form
    {
        public NewAnalysisChoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainInterface.Element = MainInterface.ElementType.eight_Noded_Hexahedral;
            MainInterface mainForm = new MainInterface();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
