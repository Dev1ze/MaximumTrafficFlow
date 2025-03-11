using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public static class ExceptionChecker
    {
        public static event Action OnNoneExsistNode;
        public static event Action OnEmptyFields;
        public static event Action OnExistEdge;
        public static event Action OnIdenticalNode;

        private static bool CheckExsistNode(List<Node> nodes, string indexFrom, string indexTo)
        {
            if (indexFrom != "" && indexTo != "")
            {
                int startIndex = int.Parse(indexFrom);
                int endIndex = int.Parse(indexTo);
                if (nodes.Count == 0)
                {
                    OnNoneExsistNode?.Invoke();
                    return true;
                }
                else if (startIndex > nodes[nodes.Count - 1].Number | startIndex < nodes[0].Number)
                {
                    OnNoneExsistNode?.Invoke();
                    return true;
                }
                else if (endIndex < nodes[0].Number | endIndex > nodes[nodes.Count - 1].Number)
                {
                    OnNoneExsistNode?.Invoke();
                    return true;
                }
                else return false;
            }
            else return false;
        } //Проверка существование узлов "Указаны несуществующие узлы"
        private static bool CheckEmptyFields(List<TextBox> textBoxes)
        {
            foreach(TextBox textBox in textBoxes)
            {
                if(textBox.Text.Length == 0)
                {
                    OnEmptyFields?.Invoke();
                    return true;
                }
            }
            return false;
        } //Проверка заполнения всех полей "Не все поля заполнены"
        private static bool CheckExsistEdge(List<Edge> edges, string indexFrom, string indexTo)
        {
            List<int> inputFields = new List<int>() 
            {
                int.Parse(indexFrom) - 1,
                int.Parse(indexTo) - 1,
            };
            if (inputFields[0] == inputFields[1])
            {
                OnIdenticalNode?.Invoke();
                return true;
            }

            foreach(Edge edge in edges)
            {
                List<int> actualEdges = new List<int>()
                {
                    edge.StartIndex,
                    edge.EndIndex,
                };
                if (actualEdges.SequenceEqual(inputFields)) //Проверка на идентичность списков, включая порядок
                {
                    OnExistEdge?.Invoke();
                    return true;
                }
            }
            return false;
        }//Проверка существование ребер "
        public static void CheckAllExceptions(List<Edge> edges, string indexFrom, string indexTo, List<Node> nodes, List<TextBox> textBoxes)
        {
            if (CheckEmptyFields(textBoxes))
            {
                return;
            }
            else if (CheckExsistEdge(edges, indexFrom, indexTo))
            {
                return;
            }
            else if (CheckExsistNode(nodes, indexFrom, indexTo))
            {
                return;
            }
        }
    }
}
