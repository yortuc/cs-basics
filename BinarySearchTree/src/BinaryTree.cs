using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Tree traversal types:
    ///     A. Breadth first
    ///     B. Depth first
    ///         1. Inorder
    ///         2. Preorder
    ///         3. Postorder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IEnumerable<T> where T: IComparable
    {
        private BinaryTreeNode<T> _head;
        private int _count;
        public int Count {
            get { return _count; }
        }

        public void Add(BinaryTreeNode<T> node) {
            if(_head == null) {
                _head = node;
            }
            else{
                AddToParent(node, _head);
            }
            _count++;
        }

        private void AddToParent(BinaryTreeNode<T> node, BinaryTreeNode<T> parent){
            if(node.CompareTo(parent) > 0) {
                // node is bigger or equal to parent
                if(parent.Right == null) 
                    parent.Right = node;
                else 
                    AddToParent(node, parent.Right);
            }
            else{
                // node is smaller than parent
                if(parent.Left == null) {
                    parent.Left = node;
                }
                else{
                    AddToParent(node, parent.Left);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Inorder traversal by default
        /// </summary>
        /// <returns>T: current value</returns>
        public IEnumerator<T> GetEnumerator() {
            return GetValues(_head).GetEnumerator();
        }

        private IEnumerable<T> GetValues(BinaryTreeNode<T> node){
            GetValues(node.Left).GetEnumerator();
            yield return node.Value;
            GetValues(node.Right).GetEnumerator();
        }

        public List<TResult> InOrderTraversal<TResult>(Func<T, TResult> action){
            return _head != null ? InOrderTraversal(action, _head) : new List<TResult>();
        }

        private List<TResult> InOrderTraversal<TResult>(Func<T, TResult> action, BinaryTreeNode<T> node){
            var left = node.Left != null ? InOrderTraversal(action, node.Left) : new List<TResult>();
            var curr = action(node.Value);
            var right = node.Right != null ? InOrderTraversal(action, node.Right) : new List<TResult>();
            var result = new List<TResult>();
            result.AddRange(left);
            result.Add(curr);
            result.AddRange(right);
            return result;
        }

        public bool Contains(T value){
            return CheckNodeValues(_head, value);
        }

        private bool CheckNodeValues(BinaryTreeNode<T> node, T value){
            if(node == null) return false;
            
            return node.Value.CompareTo(value) == 0 ||
                    CheckNodeValues(node.Left, value) ||
                    CheckNodeValues(node.Right, value);
        }

        public BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent){
            BinaryTreeNode<T> curNode = _head;
            parent = null;

            while(curNode != null) {
                int compare = value.CompareTo(curNode.Value);

                if(compare == 0) {
                    // this is the node we are looking for
                    break;
                }
                else if(compare < 0) {
                    // value we are looking for is lower than this val, go left
                    parent = curNode;
                    curNode = curNode.Left;
                }
                else if(compare > 0){
                    parent = curNode;
                    curNode = curNode.Right;
                }
            }
            return curNode;
        }

        /// <summary>
        /// Removes given value from tree
        /// 1. The node to be removed  has no right child
        ///     move the left child of node in place of node removed
        /// </summary>
        /// <returns>true if value found and removed, 
        /// false if value is not exist </returns>
        public void Remove(T value){
            // if its head
            if(_head.Value.CompareTo(value) == 0) {
                _head = null;
                return;
            }

            // find the node we want to remove
            BinaryTreeNode<T> node, parent;
            node = FindWithParent(value, out parent);

            // 1. node has no child, just remove
            if(node.Left == null && node.Right == null){
                if(parent.Left == node){
                    parent.Left = null;
                }
                else{
                    parent.Right = null;
                }
            }
            // 2. node has right child, 
            // swap node to be removed and right child
            else if(node.Left == null && node.Right != null) {
                if(parent.Left == node){ 
                    parent.Left = null;
                }
                else{
                    parent.Right = null;
                }
            }
        }
    }
}
