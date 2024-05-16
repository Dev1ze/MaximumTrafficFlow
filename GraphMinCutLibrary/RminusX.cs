using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinCutLibrary
{
    public static class RminusX
    {
        static public Matrix StartProcess(Matrix R, Matrix X)
        {
            for (int i = 0; i < R.Arrayy.GetLength(0); i++)
            {
                for (int j = 0; j < R.Arrayy.GetLength(1); j++)
                {
                    R.Arrayy[i, j] -= X.Arrayy[i, j];
                }
            }
            return R;
        }
    }
}
