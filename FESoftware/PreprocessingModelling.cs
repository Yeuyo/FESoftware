using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESoftware
{
    public class NodesInformation
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double XLoading { get; set; }
        public double YLoading { get; set; }
        public double ZLoading { get; set; }
        public int XBoundaryCondition { get; set; }
        public int YBoundaryCondition { get; set; }
        public int ZBoundaryCondition { get; set; }
        public double XDefinedDisplacement { get; set; }
        public double YDefinedDisplacement { get; set; }
        public double ZDefinedDisplacement { get; set; }
        public double XDisplacement { get; set; }
        public double YDisplacement { get; set; }
        public double ZDisplacement { get; set; }
        public NodesInformation(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override bool Equals(object obj)
        {
            NodesInformation q = obj as NodesInformation;
            return q != null && q.X == this.X && q.Y == this.Y && q.Z == this.Z && q.XLoading == this.XLoading && q.YLoading == this.YLoading && q.ZLoading == this.ZLoading && q.XBoundaryCondition == this.XBoundaryCondition && q.YBoundaryCondition == this.YBoundaryCondition && q.ZBoundaryCondition == this.ZBoundaryCondition;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode() + this.Z.GetHashCode() + this.XLoading.GetHashCode() + this.YLoading.GetHashCode() + this.ZLoading.GetHashCode() + this.XBoundaryCondition.GetHashCode() + this.YBoundaryCondition.GetHashCode() + this.ZBoundaryCondition.GetHashCode();
        }
    }
    public class MaterialsInfo
    {
        public string Name { get; set; }
        public double YoungModulus { get; set; }
        public double PoissonRatio { get; set; }
        public double Rho { get; set; }
        public MaterialsInfo(string name, double youngModulus, double poissonRatio, double rho)
        {
            Name = name;
            YoungModulus = youngModulus;
            PoissonRatio = poissonRatio;
            Rho = rho;
        }
        public override bool Equals(object obj)
        {
            MaterialsInfo q = obj as MaterialsInfo;
            return q != null && q.Name == this.Name && q.YoungModulus == this.YoungModulus && q.PoissonRatio == this.PoissonRatio && q.Rho == this.Rho;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.YoungModulus.GetHashCode() ^ this.PoissonRatio.GetHashCode() ^ this.Rho.GetHashCode();
        }
    }
    public class PreprocessingModelling
    {
        public static void addNodes(double xCoordinate, double yCoordinate, double zCoordinate)
        {
            if (!MainInterface.Nodes.Contains(new NodesInformation(xCoordinate, yCoordinate, zCoordinate)))
            {
                MainInterface.Nodes.Add(new NodesInformation(xCoordinate, yCoordinate, zCoordinate));
            }
        }

        public static void addNodesLoading(int nodesIndex, double xLoading, double yLoading, double zLoading)
        {
            MainInterface.Nodes[nodesIndex].XLoading = xLoading;
            MainInterface.Nodes[nodesIndex].YLoading = yLoading;
            MainInterface.Nodes[nodesIndex].ZLoading = zLoading;
        }

        public static void addNodesBoundaryCondition(int nodesIndex, int xBoundaryCondition, int yBoundaryCondition, int zBoundaryCondition)
        {
            MainInterface.Nodes[nodesIndex].XBoundaryCondition = xBoundaryCondition;
            MainInterface.Nodes[nodesIndex].YBoundaryCondition = yBoundaryCondition;
            MainInterface.Nodes[nodesIndex].ZBoundaryCondition = zBoundaryCondition;
        }

        public static void addNodesDefinedDisplacement(int nodesIndex, double xDisplacement, double yDisplacement, double zDisplacement)
        {
            MainInterface.Nodes[nodesIndex].XDefinedDisplacement = xDisplacement;
            MainInterface.Nodes[nodesIndex].YDefinedDisplacement = yDisplacement;
            MainInterface.Nodes[nodesIndex].ZDefinedDisplacement = zDisplacement;
        }
        public static void addNodesDisplacement(int nodesIndex, double xDisplacement, double yDisplacement, double zDisplacement)
        {
            MainInterface.Nodes[nodesIndex].XDisplacement = xDisplacement;
            MainInterface.Nodes[nodesIndex].YDisplacement = yDisplacement;
            MainInterface.Nodes[nodesIndex].ZDisplacement = zDisplacement;
        }

        public static void addMaterials(string name, double youngModulus, double poissonRatio, double rho)
        {
            if (!MainInterface.Materials.Contains(new MaterialsInfo(name, youngModulus, poissonRatio, rho)))
            {
                MainInterface.Materials.Add(new MaterialsInfo(name, youngModulus, poissonRatio, rho));
            }
        }

        public static void editMaterials(int materialIndex, string name, double youngModulus, double poissonRatio, double rho)
        {
            MainInterface.Materials[materialIndex].Name = name;
            MainInterface.Materials[materialIndex].YoungModulus = Convert.ToDouble(youngModulus);
            MainInterface.Materials[materialIndex].PoissonRatio = Convert.ToDouble(poissonRatio);
            MainInterface.Materials[materialIndex].Rho = Convert.ToDouble(rho);
        }

        public static int getElementNodesNumber()
        {
            int NumberofNodes = 0;
            switch (MainInterface.Element)
            {
                case MainInterface.ElementType.eight_Noded_Hexahedral:
                    NumberofNodes = 8;
                    break;
                    // TODO: Edit for other element_type appropriately.
            }
            return NumberofNodes;
        }

        public static void removeExcessEtopol()
        {
            // Removing extra Etopol added that did not form a full sets
            int NumberOfNodes = getElementNodesNumber();
            if (MainInterface.Etopol.Count % NumberOfNodes != 0 && MainInterface.Etopol.Count > 0)
            {
                MainInterface.Etopol.RemoveAt(MainInterface.Etopol.Count - MainInterface.Etopol.Count % NumberOfNodes);
            }
        }

        public static int getNumberOfElements()
        {
            int NumberOfNodes = getElementNodesNumber();
            int NumberOfElements = MainInterface.Etopol.Count / NumberOfNodes;
            return NumberOfElements;
        }

        public static void getGaussianCoordinates(int gaussianScheme)
        {
            double g2 = 1 / Math.Sqrt(3);
            double g3 = Math.Sqrt(3 / 5);
            double w1 = 8 / 9;
            double w2 = 5 / 9;
            switch (gaussianScheme)
            {
                case 0: // 2x2x2
                    MainInterface.XGaussianCoordinates = new double[,]
                    {
                        {-g2},
                        {-g2},
                        {g2 },
                        {g2 },
                        {-g2},
                        {-g2},
                        {g2 },
                        {g2 }
                    };
                    MainInterface.YGaussianCoordinates = new double[,]
                    {
                        {-g2},
                        {-g2},
                        {-g2 },
                        {-g2 },
                        {g2},
                        {g2},
                        {g2 },
                        {g2 }
                    };
                    MainInterface.ZGaussianCoordinates = new double[,]
                    {
                        {-g2},
                        {g2},
                        {g2 },
                        {-g2 },
                        {-g2},
                        {g2},
                        {g2 },
                        {-g2 }
                    };
                    MainInterface.GaussianWeights = new double[] { 1, 1, 1, 1, 1, 1, 1, 1 };
                    break;
                case 1: // 2x2x3
                    MainInterface.XGaussianCoordinates = new double[,]
                    {
                        {-g2 },
                        {-g2 },
                        {-g2 },
                        {g2 },
                        {g2 },
                        {g2 },
                        {-g2 },
                        {-g2 },
                        {-g2 },
                        {g2 },
                        {g2 },
                        {g2 }
                    };
                    MainInterface.YGaussianCoordinates = new double[,]
                    {
                        {-g2 },
                        {-g2 },
                        {-g2 },
                        {-g2 },
                        {-g2 },
                        {-g2 },
                        {g2 },
                        {g2 },
                        {g2 },
                        {g2 },
                        {g2 },
                        {g2 }
                    };
                    MainInterface.ZGaussianCoordinates = new double[,]
                    {
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 }
                    };
                    MainInterface.GaussianWeights = new double[] { w2, w1, w2, w2, w1, w2, w2, w1, w2, w2, w1, w2 };
                    break;
                case 2: // 3x3x2
                    MainInterface.XGaussianCoordinates = new double[,]
                    {
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 }
                    };
                    MainInterface.YGaussianCoordinates = new double[,]
                    {
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 }
                    };
                    MainInterface.ZGaussianCoordinates = new double[,]
                    {
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 },
                        {-g2 },
                        {g2 }
                    };
                    MainInterface.GaussianWeights = new double[]
                    { 
                        w2 * w2,
                        w2 * w2,
                        w1 * w2,
                        w1 * w2,
                        w2 * w2,
                        w2 * w2,
                        w2 * w1,
                        w2 * w1,
                        w1 * w1,
                        w1 * w1,
                        w2 * w1,
                        w2 * w1,
                        w2 * w2,
                        w2 * w2,
                        w1 * w2,
                        w1 * w2,
                        w2 * w2,
                        w2 * w2
                    };
                    break;
                case 3: // 3x3x3
                    MainInterface.XGaussianCoordinates = new double[,]
                    {
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 },
                        {-g3 },
                        {0 },
                        {g3 }
                    };
                    MainInterface.YGaussianCoordinates = new double[,]
                    {
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {g3 }
                    };
                    MainInterface.ZGaussianCoordinates = new double[,]
                    {
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {g3 },
                        {-g3 },
                        {-g3 },
                        {-g3 },
                        {0 },
                        {0 },
                        {0 },
                        {g3 },
                        {g3 },
                        {g3 }
                    };
                    MainInterface.GaussianWeights = new double[]
                    {
                        w2 * w2 * w2,
                        w1 * w2 * w2,
                        w2 * w2 * w2,
                        w2 * w2 * w1,
                        w1 * w2 * w1,
                        w2 * w2 * w1,
                        w2 * w2 * w2,
                        w1 * w2 * w2,
                        w2 * w2 * w2,
                        w2 * w1 * w2,
                        w1 * w1 * w2,
                        w2 * w1 * w2,
                        w2 * w1 * w1,
                        w1 * w1 * w1,
                        w2 * w1 * w1,
                        w2 * w1 * w2,
                        w1 * w1 * w2,
                        w2 * w1 * w2,
                        w2 * w2 * w2,
                        w1 * w2 * w2,
                        w2 * w2 * w2,
                        w2 * w2 * w1,
                        w1 * w2 * w1,
                        w2 * w2 * w1,
                        w2 * w2 * w2,
                        w1 * w2 * w2,
                        w2 * w2 * w2
                    };
                    break;
            }
        }
    }
}
