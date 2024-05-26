using System;

namespace EmojiLibrary
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        TPoint<T> root = null;
        int count = 0;

        public int Count => count;

        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        public void ShowTree()
        {
            Show(root);
        }

        TPoint<T>? MakeTree(int length, TPoint<T>? point)
        {
            T data = new T();
            data.RandomInit();
            TPoint<T> newItem = new TPoint<T>(data);
            if (length == 0)
            {
                return null;
            }
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);

            return newItem;
        }

        void Show(TPoint<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }

        public int TreeHeight()
        {
            return CalculateHeight(root);
        }

        int CalculateHeight(TPoint<T>? tree)
        {
            if (tree == null)
                return 0;

            int leftHeight = CalculateHeight(tree.Left);
            int rightHeight = CalculateHeight(tree.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public void TransformToBinarySearchTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = new TPoint<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        public void AddPoint(T data)
        {
            TPoint<T>? point = root;
            TPoint<T>? current = null;
            bool isExist = false;

            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else // ищем место
                {
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
            }
            //нашли место
            if (isExist)
            {
                return;
            }

            TPoint<T> newPoint = new TPoint<T>(data);
            if (current.Data.CompareTo(data) < 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        void TransformToArray(TPoint<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }
        public void Remove(T data)
        {
            root = RemoveNode(root, data);
        }

        private TPoint<T>? RemoveNode(TPoint<T>? root, T data)
        {
            if (root == null)
                return null;

            int compareResult = data.CompareTo(root.Data);
            if (compareResult < 0)
                root.Left = RemoveNode(root.Left, data);
            else if (compareResult > 0)
                root.Right = RemoveNode(root.Right, data);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // У удаляемого узла два потомка
                TPoint<T>? minRightNode = FindMinNode(root.Right);
                root.Data = minRightNode.Data;
                root.Right = RemoveNode(root.Right, minRightNode.Data);
            }
            return root;
        }

        private TPoint<T>? FindMinNode(TPoint<T>? node)
        {
            while (node?.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public MyTree<T> CloneTree()
        {
            MyTree<T> newTree = new MyTree<T>(0); // Создаем новое дерево
            newTree.root = CloneNode(root); // Клонируем корень исходного дерева
            newTree.count = Count; // Устанавливаем количество элементов в новом дереве
            return newTree;
        }

        private TPoint<T>? CloneNode(TPoint<T>? node)
        {
            if (node == null)
                return null;

            // Клонируем узел и клонируем его левое и правое поддеревья
            TPoint<T> newNode = new TPoint<T>(node.Data);
            newNode.Left = CloneNode(node.Left);
            newNode.Right = CloneNode(node.Right);
            return newNode;
        }
    }
}