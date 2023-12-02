using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNode
{
    public class Node<T> 
    {
        public T Data;
        public Node<T> Left;
        public Node<T> Right;

        public Node()
        {
            
        }

        public Node(T data)
        {
            Data = data;
        }

        
    }
    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> _root;

        public BinaryTree()
        {
            _root = null;
        }

        public void Insert(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                return;
            }
            InsertRec(_root, new Node<T>(data));

        }

        private void InsertRec(Node<T> root, Node<T> newNode)
        {
            if (root == null)
            {
                root = newNode;

            }

            int compareResult = newNode.Data.CompareTo(root.Data);

            if (compareResult < 0)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                }
                else
                {
                    InsertRec(root.Left, newNode);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                }
                else
                {
                    InsertRec(root.Right, newNode);
                }
            }
        }

        private void DisplayTree(Node<T> root)
        {
            if (root == null)
                return;
            DisplayTree(root.Left);
            System.Console.Write(root.Data + " ");
            DisplayTree(root.Right);
        }

        public void DisplayTree()
        {
            DisplayTree(_root);
        }

        public bool Search(T key)
        {
            return SearchRecursive(_root, key);
        }

        private bool SearchRecursive(Node<T> node, T key)
        {
            if(node == null)
            {
                return false;
            }
            int compareResult = key.CompareTo(node.Data);
            if(compareResult == 0)
            {
                return true;
            }
            if (compareResult < 0)
            {
             return SearchRecursive(node.Left, key);
            }
            else 
            {
              return SearchRecursive(node.Right, key);
            }
        }
        public void Delete(T key)
        {
            _root = DeleteRecursive(_root, key);
        }

        private Node<T> DeleteRecursive(Node<T> node, T key)
        {
            if (node == null)
            {
                return null; // Key not found
            }
            int compareResult = key.CompareTo(node.Data);
            if (compareResult < 0)
            {
                node.Left = DeleteRecursive(node.Left, key); // Delete in the left subtree
            }
            else if (compareResult > 0)
            {
                node.Right = DeleteRecursive(node.Right, key); // Delete in the right subtree
            }
            else
            {
                // Node with only one child or no child
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                node.Data = FindMinValue(node.Right);

                // Delete the inorder successor
                node.Right = DeleteRecursive(node.Right, node.Data);
            }
            return node;
        }

        private T FindMinValue(Node<T> node)
        {
            T minValue = node.Data;
            while (node.Left != null)
            {
                minValue = node.Left.Data;
                node = node.Left;
            }
            return minValue;
        }

        private int CalculateHeight(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = CalculateHeight(node.Left);
            int rightHeight = CalculateHeight(node.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public int Height()
        {
            return CalculateHeight(_root);
        }
    }
}
