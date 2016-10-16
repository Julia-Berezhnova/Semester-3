using System.Collections.Generic;
using System.Collections;
using System;

namespace MyPrivateBinarySearchTree
{
    /// <summary>
    /// Realization of interface IBinarySearchTree<T> 
    /// where T is a comparable type
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class BinarySearchTree<T>: IBinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree()
        {
            root = null;
        }

        public BinarySearchTree(T data)
        {
            root = new Node<T>(data, null);
        }

        public bool Insert(T data)
        {
            if (root == null)
            {
                root = new Node<T>(data, null);
                return true;
            }
            return Insert(data, ref root);
        }

        public bool Contains(T data)
        {
            return Contains(data, ref root);
        }

        public bool Remove(T data)
        {
            if (root == null)
            {
                return false;
            }
            return Remove(data, root);
        }

        public void Print()
        {
            InfixTraverse(root);
        }
        
        private bool Insert(T data, ref Node<T> current)
        {
            if (data.CompareTo(current.data) > 0)
            {
                if (current.right != null)
                {
                    Node<T> temp = current.right;
                    return Insert(data, ref temp);
                }
                else
                {
                    current.right = new Node<T>(data, current);
                }
            }
            if (data.CompareTo(current.data) < 0)
            {
                if (current.left != null)
                {
                    Node<T> temp = current.left;
                    return Insert(data, ref temp);
                }
                else
                {
                    current.left = new Node<T>(data, current);
                }
            }
            if (data.CompareTo(current.data) == 0)
            {
                return false;
            }
            return false;
        }

        private bool Contains(T data, ref Node<T> current)
        {
            if (current == null)
            {
                return false;
            }
            if ((data.CompareTo(current.data) == 0))
            {
                return true; 
            }
            else if (data.CompareTo(current.data) > 0)
            {
                Node<T> temp = current.right;
                return Contains(data, ref temp);
            }
            else 
            {
                Node<T> temp = current.left;
                return Contains(data, ref temp);
            }
            
        }

        private bool Remove(T data, Node<T> current)
        {
            if ((data.CompareTo(current.data) > 0))
            {
                return Remove(data, current.right);
            }
            if ((data.CompareTo(current.data) < 0))
            {
                return Remove(data, current.left);
            }
            if ((data.CompareTo(current.data) == 0))
            {
                if (current.left == null && current.right == null)
                {
                    if (current.parent != null)
                    {
                        if (current.parent.left == current)
                        {
                            current.parent.left = null;
                        }
                        else
                        {
                            current.parent.right = null;
                        }
                    }
                    current = null;
                    return true;
                }
                else if (current.left == null)
                {
                    if (current.parent != null)
                    { 
                        if (current.parent.left == current)
                        {
                            current.parent.left = current.right;
                        }
                        else
                        {
                            current.parent.right = current.right;
                        }
                    }
                    current = current.right;
                    return true;
                }
                else if (current.right == null)
                {
                    if (current.parent != null)
                    {
                        if (current.parent.left == current)
                        {
                            current.parent.left = current.left;
                        }
                        else
                        {
                            current.parent.right = current.left;
                        }
                    }
                    current = current.left;
                    return true;
                }
                else
                {
                    if (current.right.left == null)
                    {
                        if (current.parent.left == current)
                        {
                            current.parent.left = current.right;
                        }
                        else
                        {
                            current.parent.right = current.right;
                        }
                        current = current.right;
                    }
                    else
                    {
                        Node<T> temp = current.right;
                        while (temp.left != null)
                        {
                            temp = temp.left;
                        }
                        current.data = temp.data;
                        Remove(temp.data, current.right);
                        return true;
                    }
                }
            }
            return false;
        }

        private void InfixTraverse(Node<T> node)
        {
            if (node == null)
                return;
            else
            {
                InfixTraverse(node.left);
                Console.Write(node.data + " ");
                InfixTraverse(node.right);
            }
        }

        private class Node<T> 
        {
            public Node(T data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }

            public Node(T data, Node<T> parent)
            {
                this.data = data;
                this.left = null;
                this.right = null;
                this.parent = parent;
            }

            public T data { get; set; }
            
            public Node<T> left { get; set; }

            public Node<T> right { get; set; }

            public Node<T> parent { get; set; }
        }

        private Node<T> root;
        
        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator(root);
        }

        private IEnumerator GetAnotherEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAnotherEnumerator();
        }

        private class BSTEnumerator : IEnumerator<T>
        {
            private Node<T> first;

            private bool Reseted;

            private Node<T> CurrentNode;
            
            public BSTEnumerator(Node<T> root)
            {
                first = root;
                while (first != null && first.left != null)
                {
                    first = first.left;
                }
                Reset();               
            }

            public T Current
            {
                get
                {
                    return CurrentNode.data;
                }
            }
            
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }


            public void Reset()
            {
                CurrentNode = null;
                Reseted = true;           
            }

            public bool MoveNext()
            {
                if (Reseted)
                {
                    CurrentNode = first;
                    Reseted = false;
                }
                else if (CurrentNode.right == null)
                {
                    while (CurrentNode.parent != null && CurrentNode == CurrentNode.parent.right)
                    {
                        CurrentNode = CurrentNode.parent;
                    }
                    CurrentNode = CurrentNode.parent;
                }
                else
                {
                    CurrentNode = CurrentNode.right;
                    while (CurrentNode.left != null)
                    {
                        CurrentNode = CurrentNode.left;
                    }
                }
                return (CurrentNode != null);
            }
            
            public void Dispose() { }
        }
    }
}
