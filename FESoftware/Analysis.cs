using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESoftware
{
    public class Analysis
    {
        public static double[,] getShapeFunction(double[,] xsi, double[,] eta, double[,] zet)
        {
            int NumberofNodes = PreprocessingModelling.getElementNodesNumber();
            int GaussianNumber = xsi.GetLength(0);
            double[,] ShapeFunction = new double[GaussianNumber, NumberofNodes];
            if (GaussianNumber == 8)
            {
                for(int i = 0; i < GaussianNumber; i++)
                {
                    ShapeFunction[i, 0] = 0.125 * (1 - xsi[i, 0]) * (1 - eta[i, 0]) * (1 - zet[i, 0]);
                    ShapeFunction[i, 1] = 0.125 * (1 - xsi[i, 0]) * (1 - eta[i, 0]) * (1 + zet[i, 0]);
                    ShapeFunction[i, 2] = 0.125 * (1 + xsi[i, 0]) * (1 - eta[i, 0]) * (1 + zet[i, 0]);
                    ShapeFunction[i, 3] = 0.125 * (1 + xsi[i, 0]) * (1 - eta[i, 0]) * (1 - zet[i, 0]);
                    ShapeFunction[i, 4] = 0.125 * (1 - xsi[i, 0]) * (1 + eta[i, 0]) * (1 - zet[i, 0]);
                    ShapeFunction[i, 5] = 0.125 * (1 - xsi[i, 0]) * (1 + eta[i, 0]) * (1 + zet[i, 0]);
                    ShapeFunction[i, 6] = 0.125 * (1 + xsi[i, 0]) * (1 + eta[i, 0]) * (1 + zet[i, 0]);
                    ShapeFunction[i, 7] = 0.125 * (1 + xsi[i, 0]) * (1 + eta[i, 0]) * (1 - zet[i, 0]);
                }
            }
            // TODO: Fill in the other Shape Functions.
            return ShapeFunction;
        }

        public static double[,] getShapeFunctionDerivatives(double[,] xsi, double[,] eta, double[,] zet)
        {
            int GaussianNumber = xsi.GetLength(0);
            double[,] ShapeFunctionDerivatives = new double[3 * GaussianNumber, GaussianNumber];
            if (GaussianNumber == 8)
            {
                for (int i = 0; i < GaussianNumber; i++)
                {
                    for (int j = 0; j < GaussianNumber; j++)
                    {
                        ShapeFunctionDerivatives[(3 * (j + 1)) - 3, i] = (Math.Sign(xsi[i, 0]) * (1 + Math.Sign(eta[i, 0]) * eta[j, 0]) * (1 + Math.Sign(zet[i, 0]) * zet[j, 0])) / 8;
                        ShapeFunctionDerivatives[(3 * (j + 1)) - 2, i] = (Math.Sign(eta[i, 0]) * (1 + Math.Sign(xsi[i, 0]) * xsi[j, 0]) * (1 + Math.Sign(zet[i, 0]) * zet[j, 0])) / 8;
                        ShapeFunctionDerivatives[(3 * (j + 1)) - 1, i] = (Math.Sign(zet[i, 0]) * (1 + Math.Sign(xsi[i, 0]) * xsi[j, 0]) * (1 + Math.Sign(eta[i, 0]) * eta[j, 0])) / 8;
                    }
                }
            }
            // TODO: Fill in the other Shape Function Derivatives.
            return ShapeFunctionDerivatives;
        }

        public static double[,] getGaussianShapeFunctionDerivatives(int gaussianBeingCalculated, double[,] ShapeFunctionDerivatives)
        {
            int GaussianNumber = MainInterface.XGaussianCoordinates.GetLength(0);
            int k = 0;
            double[,] GaussianShapeFunctionDerivatives = new double[3, GaussianNumber];
            for (int i = gaussianBeingCalculated * 3; i < (gaussianBeingCalculated + 1) * 3; i++)
            {
                for (int j = 0; j < GaussianNumber; j++)
                {
                    GaussianShapeFunctionDerivatives[k, j] = ShapeFunctionDerivatives[i, j];
                }
                k += 1;
            }
            return GaussianShapeFunctionDerivatives;
        }
        public static double[,] getNodalCoordinates()
        {
            int NumbersOfNodes = PreprocessingModelling.getElementNodesNumber();
            int NumbersOfElements = PreprocessingModelling.getNumberOfElements();
            double[,] NodalCoordinates = new double[NumbersOfElements * NumbersOfNodes, 3];
            for (int i = 0; i < NumbersOfElements * NumbersOfNodes; i++)
            {
                NodalCoordinates[i, 0] = MainInterface.Nodes[MainInterface.Etopol[i]].X;
                NodalCoordinates[i, 1] = MainInterface.Nodes[MainInterface.Etopol[i]].Y;
                NodalCoordinates[i, 2] = MainInterface.Nodes[MainInterface.Etopol[i]].Z;
            }
            return NodalCoordinates;
        }

        public static double[,] getElementNodalCoordinates(int elementBeingCalculated, double[,] nodalCoordinates)
        {
            int NumbersOfNodes = PreprocessingModelling.getElementNodesNumber();
            double[,] ElementNodalCoordinates = new double[NumbersOfNodes, 3];
            int j = 0;
            for (int i = elementBeingCalculated * NumbersOfNodes; i < (elementBeingCalculated + 1) * NumbersOfNodes; i++)
            {
                ElementNodalCoordinates[j, 0] = nodalCoordinates[i, 0];
                ElementNodalCoordinates[j, 1] = nodalCoordinates[i, 1];
                ElementNodalCoordinates[j, 2] = nodalCoordinates[i, 2];
                j += 1;
            }
            return ElementNodalCoordinates;
        }
        public static double[,] getJacobian(double[,] nodalCoordinates)
        {
            double[,] ShapeFunctionDerivatives = getShapeFunctionDerivatives(MainInterface.XGaussianCoordinates, MainInterface.YGaussianCoordinates, MainInterface.ZGaussianCoordinates);
            double[,] Jacobian = Accord.Math.Matrix.Dot(ShapeFunctionDerivatives, nodalCoordinates);
            return Jacobian;
        }

        public static double[,] getGaussianJacobian(int gaussianBeingCalculated, double[,] jacobian)
        {
            double[,] GaussianJacobian = new double[3, 3];
            int j = 0;
            for (int i = gaussianBeingCalculated * 3; i < (gaussianBeingCalculated + 1) * 3; i++)
            {
                GaussianJacobian[j, 0] = jacobian[i, 0];
                GaussianJacobian[j, 1] = jacobian[i, 1];
                GaussianJacobian[j, 2] = jacobian[i, 2];
                j += 1;
            }
            return GaussianJacobian;
        }
        public static double[,] getStrainDisplacementMatrix(double[,] shapeFunctionDerivativeWRTCoordinates)
        {
            int NumbersOfNodes = PreprocessingModelling.getElementNodesNumber();
            int DegreeOfFreedom = 3;
            double[,] StrainDisplacementMatrix = new double[6, NumbersOfNodes * DegreeOfFreedom]; //TODO: Account for 9 rows situations and other cases too.
            for (int i = 0; i < NumbersOfNodes; i ++)
            {
                int j = (3 * (i + 1)) - 3;
                StrainDisplacementMatrix[0, j] = shapeFunctionDerivativeWRTCoordinates[0, i];
                StrainDisplacementMatrix[1, j + 1] = shapeFunctionDerivativeWRTCoordinates[1, i];
                StrainDisplacementMatrix[2, j + 2] = shapeFunctionDerivativeWRTCoordinates[2, i];
                StrainDisplacementMatrix[3, j] = shapeFunctionDerivativeWRTCoordinates[1, i];
                StrainDisplacementMatrix[3, j + 1] = shapeFunctionDerivativeWRTCoordinates[0, i];
                StrainDisplacementMatrix[4, j + 1] = shapeFunctionDerivativeWRTCoordinates[2, i];
                StrainDisplacementMatrix[4, j + 2] = shapeFunctionDerivativeWRTCoordinates[1, i];
                StrainDisplacementMatrix[5, j] = shapeFunctionDerivativeWRTCoordinates[2, i];
                StrainDisplacementMatrix[5, j + 2] = shapeFunctionDerivativeWRTCoordinates[0, i];
            }
            return StrainDisplacementMatrix;
        }

        public static double[,] getConstitutiveMatrix(int elementBeingCalculated)
        {
            double[,] Iz = new double[6, 6]
            {
                {1, 1, 1, 0, 0, 0 },
                {1, 1, 1, 0, 0, 0 },
                {1, 1, 1, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0 }
            };
            double[,] I2 = new double[6, 6]
            {
                {1, 0, 0, 0, 0, 0 },
                {0, 1, 0, 0, 0, 0 },
                {0, 0, 1, 0, 0, 0 },
                {0, 0, 0, 0.5, 0, 0 },
                {0, 0, 0, 0, 0.5, 0 },
                {0, 0, 0, 0, 0, 0.5 }
            };
            double ElementYoungModulus = MainInterface.Materials[MainInterface.Etopol_Material[elementBeingCalculated]].YoungModulus;
            double ElementPoissonRatio = MainInterface.Materials[MainInterface.Etopol_Material[elementBeingCalculated]].PoissonRatio;
            double[,] ConstitutiveMatrix = new double[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    ConstitutiveMatrix[i, j] = (ElementYoungModulus / ((1 + ElementPoissonRatio) * (1 - 2 * ElementPoissonRatio))) * (ElementPoissonRatio * Iz[i, j] + ((1 - 2 * ElementPoissonRatio) * I2[i, j]));
                }
            }
            return ConstitutiveMatrix;
        }

        public static double[,] addStiffnessMatrix(double[,] existingStiffnessMatrix, double[,] strainDisplacementMatrix, double[,] constitutiveMatrix, double jacobianDeterminant, int gaussianBeingCalculated)
        {
            int StiffnessMatrixSize = existingStiffnessMatrix.GetLength(0);
            double[,] newStiffnessMatrix = Accord.Math.Matrix.Dot(Accord.Math.Matrix.Dot(Accord.Math.Matrix.Transpose(strainDisplacementMatrix), constitutiveMatrix), strainDisplacementMatrix);
            double[,] StiffnessMatrix = new double[StiffnessMatrixSize, StiffnessMatrixSize];
            for (int i = 0; i < StiffnessMatrixSize; i++)
            {
                for (int j = 0; j < StiffnessMatrixSize; j++)
                {
                    StiffnessMatrix[i, j] = existingStiffnessMatrix[i, j] + newStiffnessMatrix[i, j] * jacobianDeterminant * MainInterface.GaussianWeights[gaussianBeingCalculated];
                }
            }
            return StiffnessMatrix;
        }

        public static double[,] addGlobalStiffnessMatrix(int elementBeingCalculated, double[,] existingGlobalStiffnessMatrix, double[,] stiffnessMatrix)
        {
            int NumbersOfNodes = PreprocessingModelling.getElementNodesNumber();
            int LocalStiffnessMatrixSize = stiffnessMatrix.GetLength(0);
            int[] GlobalStiffnessMatrixLocation = new int[LocalStiffnessMatrixSize];
            for (int i = 0; i < NumbersOfNodes; i ++)
            {
                GlobalStiffnessMatrixLocation[i * 3] = MainInterface.Etopol[(NumbersOfNodes * elementBeingCalculated) + i] * 3;
                GlobalStiffnessMatrixLocation[(i * 3) + 1] = GlobalStiffnessMatrixLocation[i * 3] + 1;
                GlobalStiffnessMatrixLocation[(i * 3) + 2] = GlobalStiffnessMatrixLocation[i * 3] + 2;
            }
            for (int i = 0; i < LocalStiffnessMatrixSize; i ++)
            {
                for (int j = 0; j < LocalStiffnessMatrixSize; j ++)
                {
                    existingGlobalStiffnessMatrix[GlobalStiffnessMatrixLocation[i], GlobalStiffnessMatrixLocation[j]] += stiffnessMatrix[i, j];
                }
                
            }
            return existingGlobalStiffnessMatrix;
        }

        public static double[,] calculateDisplacement(double[,] globalStiffnessMatrix)
        {
            int TotalDegreeOfFreedom = MainInterface.Nodes.Count() * 3;
            double[,] ExternalForce = new double[TotalDegreeOfFreedom,1];
            int[] FreeDegreeOfFreedom = new int[TotalDegreeOfFreedom];
            int LockedDegreeOfFreedom = 0;
            for (int i = 0; i < TotalDegreeOfFreedom; i += 3)
            {
                if (MainInterface.Nodes[Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3))].XBoundaryCondition == 1)
                {
                    FreeDegreeOfFreedom[i] = 1;
                    LockedDegreeOfFreedom += 1;
                }
                if (MainInterface.Nodes[Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3))].YBoundaryCondition == 1)
                {
                    FreeDegreeOfFreedom[i + 1] = 1;
                    LockedDegreeOfFreedom += 1;
                }
                if (MainInterface.Nodes[Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3))].ZBoundaryCondition == 1)
                {
                    FreeDegreeOfFreedom[i + 2] = 1;
                    LockedDegreeOfFreedom += 1;
                }
                ExternalForce[i, 0] = MainInterface.Nodes[Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3))].XLoading;
                ExternalForce[i + 1, 0] = MainInterface.Nodes[Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3))].YLoading;
                ExternalForce[i + 2, 0] = MainInterface.Nodes[Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3))].ZLoading;
            }
            double[,] FilteredExternalForce = new double[TotalDegreeOfFreedom - LockedDegreeOfFreedom, 1];
            double[,] FilteredBoundaryConditionDisplacement = new double[LockedDegreeOfFreedom, 1];
            int k = 0;
            for (int i = 0; i < TotalDegreeOfFreedom; i += 3)
            {
                int NodesLocator = Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3));
                if (MainInterface.Nodes[NodesLocator].XBoundaryCondition == 1)
                {
                    FilteredBoundaryConditionDisplacement[k, 0] = MainInterface.Nodes[NodesLocator].XDefinedDisplacement;
                    k += 1;
                }
                if (MainInterface.Nodes[NodesLocator].YBoundaryCondition == 1)
                {
                    FilteredBoundaryConditionDisplacement[k, 0] = MainInterface.Nodes[NodesLocator].YDefinedDisplacement;
                    k += 1;
                }
                if (MainInterface.Nodes[NodesLocator].ZBoundaryCondition == 1)
                {
                    FilteredBoundaryConditionDisplacement[k, 0] = MainInterface.Nodes[NodesLocator].ZDefinedDisplacement;
                    k += 1;
                }
            }
            k = 0;
            for (int i = 0; i < TotalDegreeOfFreedom; i++)
            {
                if (FreeDegreeOfFreedom[i] != 1)
                {
                    FilteredExternalForce[k, 0] = ExternalForce[i, 0];
                    k += 1;
                }
            }
            double[,] FilteredStiffnessMatrix = new double[TotalDegreeOfFreedom - LockedDegreeOfFreedom, TotalDegreeOfFreedom - LockedDegreeOfFreedom];
            double[,] StiffnessMatrixCorrectionForExternalForce = new double[TotalDegreeOfFreedom - LockedDegreeOfFreedom, LockedDegreeOfFreedom];
            k = 0;
            for (int i = 0; i < TotalDegreeOfFreedom; i++)
            {
                int l = 0;
                int m = 0;
                if (FreeDegreeOfFreedom[i] != 1)
                {
                    for (int j = 0; j < TotalDegreeOfFreedom; j++)
                    {
                        if (FreeDegreeOfFreedom[j] != 1)
                        {
                            FilteredStiffnessMatrix[k, l] = globalStiffnessMatrix[i, j];
                            l += 1;
                        }
                        else
                        {
                            StiffnessMatrixCorrectionForExternalForce[k, m] = globalStiffnessMatrix[i, j];
                            m += 1;
                        }
                    }
                    FilteredExternalForce[k, 0] = ExternalForce[i, 0];
                    k += 1;
                }
            }
            double[,] FilteredExternalForceCorrection = Accord.Math.Matrix.Dot(StiffnessMatrixCorrectionForExternalForce, FilteredBoundaryConditionDisplacement);
            double[,] CorrectedFilteredExternalForce = new double[TotalDegreeOfFreedom - LockedDegreeOfFreedom, 1];
            for (int i = 0; i < TotalDegreeOfFreedom - LockedDegreeOfFreedom; i++)
            {
                CorrectedFilteredExternalForce[i, 0] = FilteredExternalForce[i, 0] - FilteredExternalForceCorrection[i, 0];
            }
            double[,] FilteredDisplacement = Accord.Math.Matrix.Solve(FilteredStiffnessMatrix, CorrectedFilteredExternalForce);
            double[,] Displacement = new double[TotalDegreeOfFreedom, 1];
            k = 0;
            int n = 0;
            for (int i = 0; i < TotalDegreeOfFreedom; i++)
            {
                if (FreeDegreeOfFreedom[i] != 1)
                {
                    Displacement[i, 0] = FilteredDisplacement[k, 0];
                    k += 1;
                }
                else
                {
                    Displacement[i, 0] = FilteredBoundaryConditionDisplacement[n, 0];
                    n += 1;
                }
            }
            for (int i =0; i < TotalDegreeOfFreedom; i += 3)
            {
                PreprocessingModelling.addNodesDisplacement(Convert.ToInt32(Math.Floor(Convert.ToDouble(i) / 3)), Displacement[i, 0], Displacement[i + 1, 0], Displacement[i + 2, 0]);
            }
            return Displacement;
        }
    }
}
