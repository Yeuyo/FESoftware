using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FESoftware
{
    public class Functions
    {
        public static double[,] MatMul(double[,] matA, double[,] matB)
        {
            int MatARowNumbers = matA.GetLength(0);
            int MatAColNumbers = matA.GetLength(1);
            int MatBRowNumbers = matB.GetLength(0);
            int MatBColNumbers = matB.GetLength(1);

            //if !(MatAColNumbers == MatBRowNumbers)
            //{
            //    // Can't run
            //}

            double[,] ResultMat = new double[MatARowNumbers, MatBColNumbers];
            for (int i = 0; i < MatARowNumbers; i++)
            {
                for (int j = 0; j < MatBColNumbers; j++)
                {
                    for (int k = 0; k < MatAColNumbers; k++)
                    {
                        ResultMat[i, j] += matA[i, k] * matB[k, j];
                    }
                }
            }
            return ResultMat;
        }

        //double[,] matA = new double[,] { { 1, 0 }, { 2, 3 }, { 3, 3 } };
        //double[,] matB = new double[,] { { 1, 2, 6 }, { 2, 3, 4 } };
        //double[,] ResultMat = Functions.MatMul(matA, matB);
    }
}
