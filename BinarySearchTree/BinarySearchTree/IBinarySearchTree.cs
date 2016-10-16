using System.Collections.Generic;

namespace MyPrivateBinarySearchTree
{
    /// <summary>
    /// Interface for binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IBinarySearchTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Insertation method
        /// True if data is inserted successfully
        /// False if there exists the same data in the tree
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Insert(T data);

        /// <summary>
        /// True if tree contains needed data
        /// False if it does not
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        /// <summary>
        /// Remover
        /// True if node with given data is removed successfully
        /// False if operation is failed
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Remove(T data);

        /// <summary>
        /// Prints values in ascending order
        /// Using infix traverse
        /// </summary>
        void Print();
    }
}