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
    public partial class MainInterface : Form
    {
        public enum ElementType
        {
            eight_Noded_Hexahedral
        }
        public static ElementType Element;
        public static List<NodesInformation> Nodes = new List<NodesInformation>();
        public static List<MaterialsInfo> Materials = new List<MaterialsInfo>();
        public static List<int> Etopol = new List<int>();
        public static List<int> Etopol_Material = new List<int>();
        public static double[,] XGaussianCoordinates;
        public static double[,] YGaussianCoordinates;
        public static double[,] ZGaussianCoordinates;
        public static double[] GaussianWeights;
        public MainInterface()
        {
            InitializeComponent();
        }

        private void addNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodesCreation addNodeForm = new NodesCreation();
            addNodeForm.ShowDialog();
            dataGridView1.DataSource = Nodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z }).ToList(); // Consider using tree view so can show elements
        }

        private void addElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElementCreation addElementForm = new ElementCreation();
            addElementForm.ShowDialog();
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialsSetting editMaterials = new MaterialsSetting();
            editMaterials.ShowDialog();
        }

        private void loadingBoundaryConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadsAndBoundaryConditions editLoadsAndBoundaryConditions = new LoadsAndBoundaryConditions();
            editLoadsAndBoundaryConditions.ShowDialog();
        }

        private void runAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Make sure you can't have free nodes (nodes that are not in element) when you run.
            AnalysisSetup analysisSetup = new AnalysisSetup();
            analysisSetup.ShowDialog();
            dataGridView2.DataSource = MainInterface.Nodes.Select(vector => new { X = vector.X, Y = vector.Y, Z = vector.Z, XDisplacement = vector.XDisplacement, YDisplacement = vector.YDisplacement, ZDisplacement = vector.ZDisplacement }).ToList();
        }

        private void loadAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreprocessingModelling.addNodes(0, 0, 0);
            PreprocessingModelling.addNodes(0.5, 0, 0);
            PreprocessingModelling.addNodes(1, 0, 0);
            PreprocessingModelling.addNodes(0, 1, 0);
            PreprocessingModelling.addNodes(0.5, 1, 0);
            PreprocessingModelling.addNodes(1, 1, 0);
            PreprocessingModelling.addNodes(0, 0, 1);
            PreprocessingModelling.addNodes(0.5, 0, 1);
            PreprocessingModelling.addNodes(1, 0, 1);
            PreprocessingModelling.addNodes(0, 1, 1);
            PreprocessingModelling.addNodes(0.5, 1, 1);
            PreprocessingModelling.addNodes(1, 1, 1);
            MainInterface.Etopol.Add(0);
            MainInterface.Etopol.Add(6);
            MainInterface.Etopol.Add(7);
            MainInterface.Etopol.Add(1);
            MainInterface.Etopol.Add(3);
            MainInterface.Etopol.Add(9);
            MainInterface.Etopol.Add(10);
            MainInterface.Etopol.Add(4);
            MainInterface.Etopol.Add(1);
            MainInterface.Etopol.Add(7);
            MainInterface.Etopol.Add(8);
            MainInterface.Etopol.Add(2);
            MainInterface.Etopol.Add(4);
            MainInterface.Etopol.Add(10);
            MainInterface.Etopol.Add(11);
            MainInterface.Etopol.Add(5);
            MainInterface.Etopol_Material.Add(0);
            MainInterface.Etopol_Material.Add(0);
            PreprocessingModelling.addNodesLoading(2, 1000, 0, 0);
            PreprocessingModelling.addNodesLoading(5, 1000, 0, 0);
            PreprocessingModelling.addNodesLoading(8, 1000, 0, 0);
            PreprocessingModelling.addNodesLoading(11, 1000, 0, 0);
            PreprocessingModelling.addNodesBoundaryCondition(0, 1, 1, 1);
            PreprocessingModelling.addNodesBoundaryCondition(3, 1, 1, 1);
            PreprocessingModelling.addNodesBoundaryCondition(6, 1, 1, 1);
            PreprocessingModelling.addNodesBoundaryCondition(9, 1, 1, 1);
            PreprocessingModelling.addNodesDefinedDisplacement(6, 0, 0, -0.25);
            PreprocessingModelling.addMaterials(1.ToString(), 70000000, 0.33, 0);
        }
    }
}
