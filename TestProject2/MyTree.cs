using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmojiLibrary.Tests
{
    [TestClass]
    public class MyTreeTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeTreeWithGivenLength()
        {
            var tree = new MyTree<Emoji>(10);
            Assert.AreEqual(10, tree.Count);
        }

        [TestMethod]
        public void ShowTree_ShouldDisplayTreeStructure()
        {
            var tree = new MyTree<Emoji>(5);
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                tree.ShowTree();
                var result = sw.ToString().Trim();
                Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            }
        }

        [TestMethod]
        public void TreeHeight_ShouldReturnCorrectHeight()
        {
            var tree = new MyTree<Emoji>(7);
            int height = tree.TreeHeight();
            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void AddPoint_ShouldAddNewNodeToTree()
        {
            var tree = new MyTree<Emoji>(3);
            var newEmoji = new Emoji("Сияющий", "<happy>");
            tree.AddPoint(newEmoji);
            Assert.AreEqual(4, tree.Count);
        }

        [TestMethod]
        public void Remove_ShouldRemoveNodeFromTree()
        {
            var tree = new MyTree<Emoji>(3);
            var emojiToRemove = new Emoji("Сияющий", "<happy>");
            tree.AddPoint(emojiToRemove);
            Assert.AreEqual(4, tree.Count);

            tree.Remove(emojiToRemove);
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void TransformToBinarySearchTree_ShouldConvertToBST()
        {
            var tree = new MyTree<Emoji>(5);
            tree.TransformToBinarySearchTree();

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                tree.ShowTree();
                var result = sw.ToString().Trim();
                Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            }
        }

        [TestMethod]
        public void CloneTree_ShouldReturnDeepCopyOfTree()
        {
            var tree = new MyTree<Emoji>(5);
            var clonedTree = tree.CloneTree();

            Assert.AreEqual(tree.Count, clonedTree.Count);
            using (var swOriginal = new System.IO.StringWriter())
            using (var swCloned = new System.IO.StringWriter())
            {
                Console.SetOut(swOriginal);
                tree.ShowTree();
                var originalTreeOutput = swOriginal.ToString().Trim();

                Console.SetOut(swCloned);
                clonedTree.ShowTree();
                var clonedTreeOutput = swCloned.ToString().Trim();

                Assert.AreEqual(originalTreeOutput, clonedTreeOutput);
            }
        }
    }
}
