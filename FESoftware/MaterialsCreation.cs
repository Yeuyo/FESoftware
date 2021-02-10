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
    public partial class MaterialsCreation : Form
    {
        int Mode;
        int Selection;
        public MaterialsCreation(int mode, int selection)
        {
            Mode = mode;
            Selection = selection;
            InitializeComponent();
            if (Selection != -1)
            {
                textBox1.Text = MainInterface.Materials[selection].Name;
                textBox2.Text = MainInterface.Materials[selection].YoungModulus.ToString();
                textBox3.Text = MainInterface.Materials[selection].PoissonRatio.ToString();
                textBox4.Text = MainInterface.Materials[selection].Rho.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Mode == 0)
            {
                PreprocessingModelling.addMaterials(textBox1.Text, Convert.ToSingle(textBox2.Text), Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));
            }
            else
            {
                PreprocessingModelling.editMaterials(Selection, textBox1.Text, Convert.ToSingle(textBox2.Text), Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));
            }
            this.Close();
        }
    }
}
