using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTreeNode<T>: IComparable<BinaryTreeNode<T>> where T: IComparable {
        public T Value {get; private set;}
        public BinaryTreeNode<T> Left {get; set;}
        public BinaryTreeNode<T> Right {get; set;}

        public BinaryTreeNode(T value) {
            this.Value = value;
        }

        /// <summary>
        /// Compares current BinaryTreeNode to provided
        /// </summary>
        /// <param name="other">The node value to compare to</param>
        /// <returns> 1 if the current node value is greater than provided, 
        /// -1 if less, 0 if they are equal </returns>
        public int CompareTo(BinaryTreeNode<T> other){
            return Value.CompareTo(other.Value);
        }
    }
}