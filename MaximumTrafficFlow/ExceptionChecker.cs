using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public static class ExceptionChecker
    {
        public static event Action<string> OnNoneExsistNode;
        public static event Action<string> OnEmptyFields;
        public static event Action<string> OnExistEdge;
        public static event Action<string> OnIdenticalNode;
        public static event Action<string> OnInputStock;
        public static event Action<string> OnOutputIstock;
        public static event Action<string> OnIsolatedNode;
        public static event Action<string> OnDeleteNode;
        public static event Action<string> OnExsistGraph;

        private static bool CheckExsistNode(List<Node> nodes, string indexFrom, string indexTo)
        {
            if (indexFrom != "" && indexTo != "")
            {
                int startIndex = int.Parse(indexFrom);
                int endIndex = int.Parse(indexTo);
                if (nodes.Count == 0)
                {
                    OnNoneExsistNode?.Invoke("Указаны несуществующие узлы");
                    return true;
                }
                else if (startIndex > nodes[nodes.Count - 1].Number | startIndex < nodes[0].Number)
                {
                    OnNoneExsistNode?.Invoke("Указаны несуществующие узлы");
                    return true;
                }
                else if (endIndex < nodes[0].Number | endIndex > nodes[nodes.Count - 1].Number)
                {
                    OnNoneExsistNode?.Invoke("Указаны несуществующие узлы");
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
                    OnEmptyFields?.Invoke("Не все поля заполнены");
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
                OnIdenticalNode?.Invoke("Такое ребро уже есть");
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
                    OnExistEdge?.Invoke("Такое ребро уже есть");
                    return true;
                }
            }
            return false;
        }//Проверка существование ребер"
        private static bool CheckInputStock(string indexTo)
        {
            if(int.Parse(indexTo) == 1)
            {
                OnInputStock?.Invoke("В сток не должны входить рерба");
                return true;
            }
            return false;
        }
        private static bool CheckOutputIstock(List<Node> nodes, string indexFrom)
        {
            if (nodes.Count == int.Parse(indexFrom))
            {
                OnOutputIstock?.Invoke("Из истока не должны выходить ребра");
                return true;
            }
            return false;
        }
        public static bool CheckIsolatedkNode(List<Node> nodes)
        {
            for(int i = 1; i < nodes.Count - 1; i++)
            {
                if (nodes[i].IndexFrom == - 1 || nodes[i].IndexTo == -1)
                {
                    OnIsolatedNode?.Invoke($"Не должно быть изолированных вершин. Вершина {i + 2}");
                    return true;
                }
            }
            return false;
        }
        public static bool CheckDeleteNode(List<Node> nodes, string deletedIndex)
        {

            if (int.Parse(deletedIndex) > nodes.Count || int.Parse(deletedIndex) <= 0)
            {
                OnDeleteNode?.Invoke("Таких вершин не существует");
                return true;
            }
            return false;
        }
        public static bool CheckExsistGraph(List<Edge> edges)
        {
            if(edges.Count < 2)
            {
                OnExsistGraph?.Invoke("Граф должен состоять из нелскольких ребер");
                return true;
            }
            return false;
        }
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
            else if (CheckInputStock(indexTo))
            {
                return;
            }
            else if (CheckOutputIstock(nodes, indexFrom))
            {
                return;
            }
        }
    }
}
