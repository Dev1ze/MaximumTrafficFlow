using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphMinCutLibrary
{
    public static class Multitude
    {
        public static List<List<int>> GetMultitude(List<List<int>> list)
        {
            List<List<int>> multitude = new List<List<int>>();
            List<int> resultB = new List<int>();
            resultB = FindMultitudeB(list);
            multitude.Add(RemoveDuplicates(resultB));
            multitude.Add(FindMultitudeA(RemoveDuplicates(resultB)));
            return multitude;
        }

        public static List<List<int>> GetMinimalEdges(List<int> multitudeA, List<int> multitudeB, Matrix connectionsMatrix)
        {
            List<List<int>> minimalEdges = new List<List<int>>();
            for (int i = 0; i < multitudeB.Count; i++)
            {
                for (int j = 0; j < multitudeA.Count; j++)
                {
                    if (connectionsMatrix.Arrayy[multitudeA.ElementAt(j) - 1, multitudeB.ElementAt(i) - 1] > 0)
                    {
                        List<int> oneMinimalEdge = new List<int>();
                        oneMinimalEdge.Add(multitudeA.ElementAt(j));
                        oneMinimalEdge.Add(multitudeB.ElementAt(i));
                        minimalEdges.Add(oneMinimalEdge);
                    }
                    if (connectionsMatrix.Arrayy[multitudeB.ElementAt(i) - 1, multitudeA.ElementAt(j) - 1] > 0)
                    {
                        List<int> oneMinimalEdge = new List<int>();
                        oneMinimalEdge.Add(multitudeB.ElementAt(i));
                        oneMinimalEdge.Add(multitudeA.ElementAt(j));
                        minimalEdges.Add(oneMinimalEdge);
                    }
                }
            }
            return minimalEdges;
        }

        private static List<int> FindMultitudeA(List<int> list)
        {
            List<int> resultA = new List<int>();
            for(int i = list.Last() - 1; i > 0; i--)
            {
                resultA.Add(i);
            }
            return resultA;
        }

        private static List<int> FindMultitudeB(List<List<int>> list)
        {
            List<List<int>> reverseConnectedVertices = new List<List<int>>();
            reverseConnectedVertices = Enumerable.Reverse(list).ToList();
            int target = 0;
            List<int> multitude = new List<int>();
            foreach (var item in reverseConnectedVertices)
            {
                if (item.Count == 1) 
                {
                    multitude.Add(item[0]);
                }
                else if (item.Count > 1) 
                {
                    multitude.Add(item.Last());
                    multitude.Add(item.First());
                    target = item.First();
                    if(target == 1)
                    {
                        List<int> multitudeB = new List<int>();
                        List<int> multitudeA = new List<int>();
                        multitudeA = reverseConnectedVertices.Last();
                        for(int i = reverseConnectedVertices.First()[0]; i > 0; i--)
                        {
                            multitudeB.Add(i);
                        }
                        IEnumerable<int> difference = multitudeB.Except(multitudeA);
                        List<int> resultList = difference.ToList();
                        return resultList;
                    }
                    break;
                }
            }
            foreach (var item in reverseConnectedVertices)
            {
                if (item.Count > 1)
                {
                    for(int i = item.Count - 1; i != 0; i--)
                    {
                        if(item[i] == target)
                        {
                            multitude.Add(item.Last());
                            multitude.Add(item.First());
                            target = item.First();
                        }
                    }
                }
            }
            return multitude;
        }

        private static List<int> RemoveDuplicates(List<int> list)
        {
            HashSet<int> uniqueElements = new HashSet<int>();
            List<int> result = new List<int>();

            foreach (int num in list)
            {
                if (uniqueElements.Add(num))
                {
                    result.Add(num);
                }
            }

            list.Clear();
            list.AddRange(result);
            return result;  
        }

        //public void GetMultitude(List<List<int>> list)
        //{
        //    List<Edge> indexesMinimalPaths = new List<Edge>();
        //    for (int i = 0; i < Node.Edges.Count; i++)
        //    {
        //        int[] itemList = new int[2];
        //        itemList[0] = Node.Edges[i].StartIndex;
        //        itemList[1] = Node.Edges[i].EndIndex;
        //        if (GetCountRepeats(itemList, list.First()) == 1)
        //        {
        //            indexesMinimalPaths.Add(Node.Edges[i]);
        //        }
        //    }
        //    foreach (var edge in indexesMinimalPaths)
        //    {
        //        edge.ColorEdge = Pens.Red;
        //    }
        //    Refresh();
        //}
    }
}
