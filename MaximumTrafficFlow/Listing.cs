using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public class Listing : IDataStructure
    {
        public Listing(List<List<int>> list) 
        { 
            List = list;
        }

        public List<List<int>> List { get; set; }

        public override string ToString()
        {
            string text = "";
            string row = "";
            for (int i = 0; i < List.Count; i++)
            {
                for (int j = 0; j < List[i].Count; j++)
                {
                    if (j == 0)
                    {
                        row += List[i][j].ToString() + "\t";
                    }
                    else row += List[i][j].ToString() + "\t";
                }
                text += row + "\r\n";
                row = "";
            }
            return text;
        }

        private int width;

        public int Width
        {
            get 
            {
                int longestList = 0;
                foreach (var path in List)
                {
                    if (path.Count > longestList)
                    {
                        longestList = path.Count;
                    }
                }
                return longestList;
            }
        }

        private int heigth;

        public int Heigth
        {
            get 
            {
                return List.Count; 
            }
        }


    }
}
