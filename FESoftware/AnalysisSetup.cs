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
        public AnalysisSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreprocessingModelling.getGaussianCoordinates(comboBox1.SelectedIndex);
            int NumbersOfNodes = PreprocessingModelling.getElementNodesNumber();
            int DegreeOfFreedom = 3;
            PreprocessingModelling.removeExcessEtopol();
            int NumbersOfElements = PreprocessingModelling.getNumberOfElements();
            double[,] NodalCoordinates = Analysis.getNodalCoordinates();
            int GaussianNumber = MainInterface.XGaussianCoordinates.GetLength(0);
            double[,] ShapeFunctionDerivatives = Analysis.getShapeFunctionDerivatives(MainInterface.XGaussianCoordinates, MainInterface.YGaussianCoordinates, MainInterface.ZGaussianCoordinates);
            double[,] GlobalStiffnessMatrix = new double[MainInterface.Nodes.Count() * DegreeOfFreedom, MainInterface.Nodes.Count() * DegreeOfFreedom]; //
            for (int i = 0; i < NumbersOfElements; i++)
            {
                double[,] StiffnessMatrix = new double[NumbersOfNodes * DegreeOfFreedom, NumbersOfNodes * DegreeOfFreedom];
                double[,] ElementNodalCoordinates = Analysis.getElementNodalCoordinates(i, NodalCoordinates);
                double[,] Jacobian = Analysis.getJacobian(ElementNodalCoordinates);
                for (int j = 0; j < GaussianNumber; j++)
                {
                    double[,] GaussianJacobian = Analysis.getGaussianJacobian(j, Jacobian);
                    double JacobianDeterminant = Accord.Math.Matrix.Determinant(GaussianJacobian);
                    double[,] GaussianShapeFunctionDerivative = Analysis.getGaussianShapeFunctionDerivatives(j, ShapeFunctionDerivatives);
                    double[,] ShapeFunctionDerivativeWRTCoordinates = Accord.Math.Matrix.Solve(GaussianJacobian, GaussianShapeFunctionDerivative);
                    double[,] StrainDisplacementMatrix = Analysis.getStrainDisplacementMatrix(ShapeFunctionDerivativeWRTCoordinates);
                    double[,] ConstitutiveMatrix = Analysis.getConstitutiveMatrix(i);
                    StiffnessMatrix = Analysis.addStiffnessMatrix(StiffnessMatrix, StrainDisplacementMatrix, ConstitutiveMatrix, JacobianDeterminant, j);
                }
                GlobalStiffnessMatrix = Analysis.addGlobalStiffnessMatrix(i, GlobalStiffnessMatrix, StiffnessMatrix);
            }
            Analysis.calculateDisplacement(GlobalStiffnessMatrix);
            this.Close();
        }
    }
}
