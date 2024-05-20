using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinCutLibrary
{
    public class Listing
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
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < List.Count; i++)
                {
                    foreach (var item in List[i])
                    {
                        sb.Append(item);
                        sb.Append(' ', 6 - item.ToString().Length);
                    }
                    if(i < List.Count - 1) sb.AppendLine(); // Добавляет новую строку после каждой строки матрицы
                }
                return sb.ToString();
            }

            else if(SingleList != null)
            {
                string text = "";
                foreach(var item in SingleList)
                {
                    text += item.ToString() + "    ";
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
