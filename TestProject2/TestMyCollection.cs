using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmojiLibrary.Tests
{
    [TestClass]
    public class MyCollectionTests
    {
        [TestMethod]
        public void Add_ShouldAddItemToEnd()
        {
            var collection = new MyCollection<Emoji>();
            var emoji = new Emoji("Улыбка", "<smile>");
            collection.Add(emoji);

            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual("Улыбка", collection[0].Name);
            Assert.AreEqual("<smile>", collection[0].Tag);
        }

        [TestMethod]
        public void Insert_ShouldInsertItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            var emoji = new Emoji("Задумчивый", "<thinking>");
            collection.Insert(2, emoji);

            Assert.AreEqual(3, collection.Count);
            Assert.AreEqual("Задумчивый", collection[1].Name);
            Assert.AreEqual("<thinking>", collection[1].Tag);
        }

        [TestMethod]
        public void RemoveAt_ShouldRemoveItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Задумчивый", "<thinking>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            collection.RemoveAt(1);

            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual("Сияющий", collection[1].Name);
            Assert.AreEqual("<happy>", collection[1].Tag);
        }

        [TestMethod]
        public void Indexer_Get_ShouldReturnItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            var emoji = collection[1];

            Assert.AreEqual("Сияющий", emoji.Name);
            Assert.AreEqual("<happy>", emoji.Tag);
        }

        [TestMethod]
        public void Indexer_Set_ShouldUpdateItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            collection[1] = new Emoji("Задумчивый", "<thinking>");

            Assert.AreEqual("Задумчивый", collection[1].Name);
            Assert.AreEqual("<thinking>", collection[1].Tag);
        }

        [TestMethod]
        public void CopyTo_ShouldCopyItemsToArray()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            var array = new Emoji[2];
            collection.CopyTo(array, 0);

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual("Улыбка", array[0].Name);
            Assert.AreEqual("<smile>", array[0].Tag);
            Assert.AreEqual("Сияющий", array[1].Name);
            Assert.AreEqual("<happy>", array[1].Tag);
        }

        [TestMethod]
        public void Enumerator_ShouldEnumerateItems()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            var names = new List<string>();
            foreach (var emoji in collection)
            {
                names.Add(emoji.Name);
            }

            CollectionAssert.AreEqual(new List<string> { "Улыбка", "Сияющий" }, names);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllItems()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("Улыбка", "<smile>"));
            collection.Add(new Emoji("Сияющий", "<happy>"));

            collection.Clear();

            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void Contains_ShouldReturnTrueIfItemExists()
        {
            var collection = new MyCollection<Emoji>();
            var emoji = new Emoji("Улыбка", "<smile>");
            collection.Add(emoji);

            Assert.IsTrue(collection.Contains(emoji));
        }

        [TestMethod]
        public void Remove_ShouldRemoveItem()
        {
            var collection = new MyCollection<Emoji>();
            var emoji = new Emoji("Улыбка", "<smile>");
            collection.Add(emoji);

            var result = collection.Remove(emoji);

            Assert.IsTrue(result);
            Assert.AreEqual(0, collection.Count);
        }
    }
}
