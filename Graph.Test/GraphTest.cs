using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Graph.Test
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            

            //act
            int[,] actual = MaximumTrafficFlow.XplusDelta.StartProcess(matrixRminusXn, matrixXn);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
