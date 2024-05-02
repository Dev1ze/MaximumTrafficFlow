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

        public Listing(List<int> singleList)
        {
            SingleList = singleList;
        }

        public List<List<int>> List { get; set; }
        public List<int> SingleList { get; set; }

        public override string ToString()
        {
            if(List != null)
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

            else if(SingleList != null)
            {
                string text = "";
                foreach(var item in SingleList)
                {
                    text += item.ToString() + "\t";
                }
                return text;
            }
            else return string.Empty;
        }

        private int width;

        public int Width
        {
            get 
            {
                int longestList = 0;
                if (List != null)
                {
                    foreach (var path in List)
                    {
                        if (path.Count > longestList)
                        {
                            longestList = path.Count;
                        }
                    }
                    return longestList;
                }
                else if(SingleList != null)
                {
                    return longestList = SingleList.Count;
                }
                else return 0;
            }
        }

        private int heigth;

        public int Heigth
        {
            get 
            {
                if (List != null) return List.Count;
                else if (SingleList != null) return 2;
                else return 0;
            }
        }


    }
}
