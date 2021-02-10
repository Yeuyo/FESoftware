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
    public partial class AnalysisSetup : Form
    {
        int Element_Type;
        public AnalysisSetup(int element_Type)
        {
            Element_Type = element_Type;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gaussian Scheme:
            // 0 - 2x2x2
            // 1 - 2x2x3
            // 2 - 3x3x2
            // 3 - 3x3x3
            PreprocessingModelling.getGaussianCoordinates(comboBox1.SelectedIndex);
            int NumbersOfNodes = PreprocessingModelling.getElementNodesNumber(Element_Type);
            int DegreeOfFreedom = 3;
            PreprocessingModelling.removeExcessEtopol(Element_Type);
            int NumbersOfElements = PreprocessingModelling.getNumberOfElements(Element_Type);
            double[,] NodalCoordinates = Analysis.getNodalCoordinates(Element_Type);
            int GaussianNumber = MainInterface.XGaussianCoordinates.GetLength(0);
            double[,] ShapeFunctionDerivatives = Analysis.getShapeFunctionDerivatives(Element_Type, MainInterface.XGaussianCoordinates, MainInterface.YGaussianCoordinates, MainInterface.ZGaussianCoordinates);
            double[,] GlobalStiffnessMatrix = new double[MainInterface.Nodes.Count() * DegreeOfFreedom, MainInterface.Nodes.Count() * DegreeOfFreedom]; //
            for (int i = 0; i < NumbersOfElements; i++)
            {
                double[,] StiffnessMatrix = new double[NumbersOfNodes * DegreeOfFreedom, NumbersOfNodes * DegreeOfFreedom];
                double[,] ElementNodalCoordinates = Analysis.getElementNodalCoordinates(Element_Type, i, NodalCoordinates);
                double[,] Jacobian = Analysis.getJacobian(Element_Type, ElementNodalCoordinates);
                for (int j = 0; j < GaussianNumber; j++)
                {
                    double[,] GaussianJacobian = Analysis.getGaussianJacobian(Element_Type, j, Jacobian);
                    double JacobianDeterminant = Accord.Math.Matrix.Determinant(GaussianJacobian);
                    double[,] GaussianShapeFunctionDerivative = Analysis.getGaussianShapeFunctionDerivatives(j, ShapeFunctionDerivatives);
                    double[,] ShapeFunctionDerivativeWRTCoordinates = Accord.Math.Matrix.Solve(GaussianJacobian, GaussianShapeFunctionDerivative);
                    double[,] StrainDisplacementMatrix = Analysis.getStrainDisplacementMatrix(Element_Type, ShapeFunctionDerivativeWRTCoordinates);
                    double[,] ConstitutiveMatrix = Analysis.getConstitutiveMatrix(i);
                    StiffnessMatrix = Analysis.addStiffnessMatrix(StiffnessMatrix, StrainDisplacementMatrix, ConstitutiveMatrix, JacobianDeterminant, j);
                }
                GlobalStiffnessMatrix = Analysis.addGlobalStiffnessMatrix(Element_Type, i, GlobalStiffnessMatrix, StiffnessMatrix);
            }
            Analysis.calculateDisplacement(GlobalStiffnessMatrix);
            this.Close();
        }
    }
}
