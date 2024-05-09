using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public static class MatrixConverter
    {
        public static Matrix BuildMatrix(List<Edge> edges)
        {
            int matrixSize = GetMatrixSize(edges);
            int[,] array = new int[matrixSize, matrixSize];
            foreach(var edge in edges)
            {
                array[edge.StartIndex, edge.EndIndex] = edge.ValueStream;
            }
            return new Matrix(array);

        }

        private static int GetMatrixSize(List<Edge> edges)
        {
            int maxValue = 0;
            foreach (var edge in edges) 
            { 
                if(edge.StartIndex > maxValue)
                {
                    maxValue = edge.StartIndex;
                }
                if (edge.EndIndex > maxValue)
                {
                    maxValue = edge.EndIndex;
                }
            }
            return maxValue + 1;
        }
    }
}
