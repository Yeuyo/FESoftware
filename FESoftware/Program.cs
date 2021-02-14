using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord;
using Accord.Math;

namespace FESoftware
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //double[,] matA = new double[,] { { 1, 0 }, { 2, 3 }, { 3, 3 } };
            //double[,] matB = new double[,] { { 1, 2, 6 }, { 2, 3, 4 } };
            //double[,] matC = new double[,] { { 1, 2, 6 }, { 2, 3, 4 }, { 4, 6, 3 } };
            //double[,] matD = new double[,] { { 3 }, { 6 }, { 9 } };
            //double[,] ResultMat = Accord.Math.Matrix.Solve(matC, matD); //Accord.Math.Matrix.Dot(matA, matB);
            //for (int i = 0; i < ResultMat.GetLength(0); i++)
            //{ 
            //    for (int j = 0; j < ResultMat.GetLength(1); j++)
            //    {
            //        Console.WriteLine(ResultMat[i, j]);
            //    }
            //}
            NewAnalysisChoice newAnalysisForm = new NewAnalysisChoice();
            newAnalysisForm.ShowDialog();
            //Application.Run(new Form1());
        }
    }
}
