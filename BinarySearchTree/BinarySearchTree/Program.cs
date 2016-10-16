using System;

namespace MyPrivateBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("hello");
            bst.Insert("bye");
            foreach (string item in bst)
            {
                Console.WriteLine(item);
            }
        }
    }
}
