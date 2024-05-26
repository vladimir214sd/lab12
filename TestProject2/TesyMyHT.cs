using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EmojiLibrary.Tests
{
    [TestClass]
    public class MyHashTableTests
    {
        [TestMethod]
        public void AddItem_ShouldAddNewItem()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            var emoji = new Emoji("Улыбка", "<smile>");

            hashTable.AddItem(emoji);

            Assert.IsTrue(hashTable.FindItem(emoji));
        }

        [TestMethod]
        public void AddItem_ShouldResizeAndAddNewItem()
        {
            var hashTable = new MyHashTable<Emoji>(4);
            var emojis = new Emoji[]
            {
                new Emoji("Улыбка", "<smile>"),
                new Emoji("Сияющий", "<happy>"),
                new Emoji("Задумчивый", "<thinking>"),
                new Emoji("Привет", "<wave>")
            };

            foreach (var emoji in emojis)
            {
                hashTable.AddItem(emoji);
            }

            var newEmoji = new Emoji("Праздник", "<celebrate>");
            hashTable.AddItem(newEmoji);

            Assert.AreEqual(8, hashTable.Capacity);
            Assert.IsTrue(hashTable.FindItem(newEmoji));
        }

        [TestMethod]
        public void FindItem_ShouldReturnTrueForExistingItem()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            var emoji = new Emoji("Улыбка", "<smile>");
            hashTable.AddItem(emoji);

            Assert.IsTrue(hashTable.FindItem(emoji));
        }

        [TestMethod]
        public void FindItem_ShouldReturnFalseForNonExistingItem()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            var emoji = new Emoji("Улыбка", "<smile>");

            Assert.IsFalse(hashTable.FindItem(emoji));
        }

        [TestMethod]
        public void RemoveItem_ShouldRemoveExistingItem()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            var emoji = new Emoji("Улыбка", "<smile>");
            hashTable.AddItem(emoji);
            Assert.IsTrue(hashTable.FindItem(emoji));

            hashTable.RemoveItem(emoji);
            Assert.IsFalse(hashTable.FindItem(emoji));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Item not found")]
        public void RemoveItem_ShouldThrowExceptionForNonExistingItem()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            var emoji = new Emoji("Улыбка", "<smile>");
            hashTable.RemoveItem(emoji);
        }

        [TestMethod]
        public void RemoveItem_ShouldRemoveItemFromCollisionChain()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            var emoji1 = new Emoji("Улыбка", "<smile>");
            var emoji2 = new Emoji("Сияющий", "<happy>");
            hashTable.AddItem(emoji1);
            hashTable.AddItem(emoji2);

            Assert.IsTrue(hashTable.FindItem(emoji1));
            Assert.IsTrue(hashTable.FindItem(emoji2));

            hashTable.RemoveItem(emoji1);
            Assert.IsFalse(hashTable.FindItem(emoji1));
            Assert.IsTrue(hashTable.FindItem(emoji2));
        }

        [TestMethod]
        public void Constructor_ShouldInitializeHashTableWithRandomItems()
        {
            var hashTable = new MyHashTable<Emoji>(10);

            int count = hashTable.GetType().GetField("table", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .GetValue(hashTable) as Point<Emoji>[] == null ? 0 :
                                (hashTable.GetType().GetField("table", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .GetValue(hashTable) as Point<Emoji>[]).Count(p => p != null);

            Assert.IsTrue(count > 0);
            Assert.IsTrue(count <= 7); // 70% of the capacity (10)
        }

        [TestMethod]
        public void PrintList_ShouldPrintAllItems()
        {
            var hashTable = new MyHashTable<Emoji>(10);
            hashTable.AddItem(new Emoji("Улыбка", "<smile>"));
            hashTable.AddItem(new Emoji("Сияющий", "<happy>"));

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                hashTable.PrintList();
                var result = sw.ToString().Trim();

                Assert.IsTrue(result.Contains("Улыбка"));
                Assert.IsTrue(result.Contains("<smile>"));
                Assert.IsTrue(result.Contains("Сияющий"));
                Assert.IsTrue(result.Contains("<happy>"));
            }
        }
    }
}
