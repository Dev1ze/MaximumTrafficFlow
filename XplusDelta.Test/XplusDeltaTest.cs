using MaximumTrafficFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace XplusDelta.Test
{
    [TestClass]
    public class XplusDeltaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            int[,] matrixXn = new int[6, 6]
{
                {0,1,2,2,0,0 },
                {-1,0,0,0,1,0 },
                {-2,0,0,0,2,0 },
                {-2,0,0,0,0,2 },
                {0,-1,-2,0,0,3 },
                {0,0,0,-2,-3,0 }
};

            int[,] matrixRminusXn = new int[6, 6]
            {
                {0,6,2,0,0,0 },
                {4,0,8,4,0,0 },
                {8,8,0,0,0,0 },
                {7,9,2,0,8,2 },
                {0,6,4,3,0,2 },
                {0,0,0,8,10,0 }
            };

            int[,] expected = new int[6, 6]
            {
                {0,3,2,2,0,0},
                {-3,0,0,2,1,0},
                {-2,0,0,0,2,0},
                {-2,-2,0,0,0,4},
                {0,-1,-2,0,0,3},
                {0,0,0,-4,-3,0}
            };

            //act
            int[,] actual = MaximumTrafficFlow.XplusDelta.StartProcess(matrixRminusXn, matrixXn);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            int[,] matrixXn = new int[6, 6]
            {
                {0,3,2,2,0,0},
                {-3,0,0,2,1,0},
                {-2,0,0,0,2,0},
                {-2,-2,0,0,0,4},
                {0,-1,-2,0,0,3},
                {0,0,0,-4,-3,0}
            };

            int[,] matrixRminusXn = new int[6, 6]
            {
                {0,4,2,0,0,0 },
                {6,0,8,2,0,0 },
                {8,8,0,0,0,0 },
                {7,11,0,0,8,0 },
                {0,6,4,3,0,2 },
                {0,0,0,10,10,0 }
            };

            int[,] expected = new int[6, 6]
            {
                {0,5,2,2,0,0},
                {-5,0,0,4,1,0},
                {-2,0,0,0,2,0},
                {-2,-4,0,0,2,4},
                {0,-1,-2,-2,0,5},
                {0,0,0,-4,-5,0}
            };

            //act
            int[,] actual = MaximumTrafficFlow.XplusDelta.StartProcess(matrixRminusXn, matrixXn);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
