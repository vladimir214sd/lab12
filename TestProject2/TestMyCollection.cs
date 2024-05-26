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
            var emoji = new Emoji("������", "<smile>");
            collection.Add(emoji);

            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual("������", collection[0].Name);
            Assert.AreEqual("<smile>", collection[0].Tag);
        }

        [TestMethod]
        public void Insert_ShouldInsertItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("�������", "<happy>"));

            var emoji = new Emoji("����������", "<thinking>");
            collection.Insert(2, emoji);

            Assert.AreEqual(3, collection.Count);
            Assert.AreEqual("����������", collection[1].Name);
            Assert.AreEqual("<thinking>", collection[1].Tag);
        }

        [TestMethod]
        public void RemoveAt_ShouldRemoveItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("����������", "<thinking>"));
            collection.Add(new Emoji("�������", "<happy>"));

            collection.RemoveAt(1);

            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual("�������", collection[1].Name);
            Assert.AreEqual("<happy>", collection[1].Tag);
        }

        [TestMethod]
        public void Indexer_Get_ShouldReturnItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("�������", "<happy>"));

            var emoji = collection[1];

            Assert.AreEqual("�������", emoji.Name);
            Assert.AreEqual("<happy>", emoji.Tag);
        }

        [TestMethod]
        public void Indexer_Set_ShouldUpdateItemAtIndex()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("�������", "<happy>"));

            collection[1] = new Emoji("����������", "<thinking>");

            Assert.AreEqual("����������", collection[1].Name);
            Assert.AreEqual("<thinking>", collection[1].Tag);
        }

        [TestMethod]
        public void CopyTo_ShouldCopyItemsToArray()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("�������", "<happy>"));

            var array = new Emoji[2];
            collection.CopyTo(array, 0);

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual("������", array[0].Name);
            Assert.AreEqual("<smile>", array[0].Tag);
            Assert.AreEqual("�������", array[1].Name);
            Assert.AreEqual("<happy>", array[1].Tag);
        }

        [TestMethod]
        public void Enumerator_ShouldEnumerateItems()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("�������", "<happy>"));

            var names = new List<string>();
            foreach (var emoji in collection)
            {
                names.Add(emoji.Name);
            }

            CollectionAssert.AreEqual(new List<string> { "������", "�������" }, names);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllItems()
        {
            var collection = new MyCollection<Emoji>();
            collection.Add(new Emoji("������", "<smile>"));
            collection.Add(new Emoji("�������", "<happy>"));

            collection.Clear();

            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void Contains_ShouldReturnTrueIfItemExists()
        {
            var collection = new MyCollection<Emoji>();
            var emoji = new Emoji("������", "<smile>");
            collection.Add(emoji);

            Assert.IsTrue(collection.Contains(emoji));
        }

        [TestMethod]
        public void Remove_ShouldRemoveItem()
        {
            var collection = new MyCollection<Emoji>();
            var emoji = new Emoji("������", "<smile>");
            collection.Add(emoji);

            var result = collection.Remove(emoji);

            Assert.IsTrue(result);
            Assert.AreEqual(0, collection.Count);
        }
    }
}
