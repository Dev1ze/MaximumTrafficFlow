using System;
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

            result = FindMultitude(list);
            return RemoveDuplicates(result);
        }

        public static List<int> FindMultitude(List<List<int>> list)
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
