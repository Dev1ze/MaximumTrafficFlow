using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    static class Multitude
    {
        public static List<int> GetMultitude(List<List<int>> list)
        {
            List<int> result = new List<int>();

            result = FindMultitudeB(list);
            return RemoveDuplicates(result);
        }

        public static List<int> FindMultitudeB(List<List<int>> list)
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

        static List<int> RemoveDuplicates(List<int> list)
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
    }
}
