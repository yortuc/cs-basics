using NUnit.Framework;
using BinarySearchTree;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void Should_add_one_node_to_tree()
        {
            var tree = new BinaryTree<int>();
            tree.Add(new BinaryTreeNode<int>(5));

            var treeValues = tree.GetEnumerator();
            treeValues.MoveNext();

            Assert.AreEqual(1, tree.Count);
            Assert.AreEqual(5, treeValues.Current);
        }

        [Test]
        public void Should_add_multiples_nodes_to_tree_in_order(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(3);
            var node2 = new BinaryTreeNode<int>(1);
            var node3 = new BinaryTreeNode<int>(4);
            var node4 = new BinaryTreeNode<int>(5);
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);
            tree.Add(node4);

            Assert.AreEqual(node3, node1.Right);
            Assert.AreEqual(node2, node1.Left);
            Assert.AreEqual(node4, node3.Right);
        }

        [Test]
        public void Should_inorder_traverse(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(3);
            var node2 = new BinaryTreeNode<int>(1);
            var node3 = new BinaryTreeNode<int>(4);
            var node4 = new BinaryTreeNode<int>(5);
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);
            tree.Add(node4);

            var result = tree.InOrderTraversal<int>(x => x);
            var expected = new List<int> {
                1, 3, 4, 5
            };

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Should_check_if_tree_contains_node(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(3);
            var node2 = new BinaryTreeNode<int>(1);
            var node3 = new BinaryTreeNode<int>(4);
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);

            Assert.AreEqual(tree.Contains(1), true);
            Assert.AreEqual(tree.Contains(7), false);
        }

        [Test]
        public void Shoul_find_node_with_parent(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(3);
            var node2 = new BinaryTreeNode<int>(1);
            var node3 = new BinaryTreeNode<int>(4);
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);

            BinaryTreeNode<int> parent;
            var node = tree.FindWithParent(1, out parent);

            Assert.AreEqual(parent, node1);
        }

        [Test]
        public void Shoul_remove_root_node(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(3);
            tree.Add(node1);
            
            tree.Remove(3);

            Assert.AreEqual(
                tree.InOrderTraversal<int>(x => x),
                new List<int>()
            );
        }

        [Test]
        public void Shoul_remove_leaf_node(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(3);
            var node2 = new BinaryTreeNode<int>(1);
            var node3 = new BinaryTreeNode<int>(4);
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);
            
            tree.Remove(4);

            Assert.AreEqual(
                tree.InOrderTraversal<int>(x => x),
                new List<int> { 1, 3 }
            );
        }

        [Test]
        public void Should_remove_nonleaf_node(){
            var tree = new BinaryTree<int>();
            var node1 = new BinaryTreeNode<int>(8);
            var node2 = new BinaryTreeNode<int>(5);
            var node3 = new BinaryTreeNode<int>(10);
            var node4 = new BinaryTreeNode<int>(2);
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);
            tree.Add(node4);
            
            tree.Remove(5);

            Assert.AreEqual(
                tree.InOrderTraversal<int>(x => x),
                new List<int> { 2, 8, 10 }
            );
        }
     }
}