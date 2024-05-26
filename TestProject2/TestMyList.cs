using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmojiLibrary.Tests
{
    [TestClass]
    public class MyListTests
    {
        [TestMethod]
        public void AddToBegin_ShouldAddItemToBeginning()
        {
            var list = new MyList<Emoji>();
            var emoji = new Emoji("Улыбка", "<smile>");
            list.AddToBegin(emoji);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Улыбка", list.beg.Data.Name);
            Assert.AreEqual("<smile>", list.beg.Data.Tag);
        }

        [TestMethod]
        public void AddToEnd_ShouldAddItemToEnd()
        {
            var list = new MyList<Emoji>();
            var emoji = new Emoji("Улыбка", "<smile>");
            list.AddToEnd(emoji);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Улыбка", list.end.Data.Name);
            Assert.AreEqual("<smile>", list.end.Data.Tag);
        }

        [TestMethod]
        public void Constructor_WithSize_ShouldInitializeListWithRandomItems()
        {
            var list = new MyList<Emoji>(5);

            Assert.AreEqual(5, list.Count);
            Assert.IsNotNull(list.beg);
            Assert.IsNotNull(list.end);
        }

        [TestMethod]
        public void Constructor_WithCollection_ShouldInitializeList()
        {
            var emojis = new Emoji[]
            {
                new Emoji("Улыбка", "<smile>"),
                new Emoji("Сияющий", "<happy>"),
                new Emoji("Задумчивый", "<thinking>")
            };
            var list = new MyList<Emoji>(emojis);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("Улыбка", list.beg.Data.Name);
            Assert.AreEqual("<smile>", list.beg.Data.Tag);
            Assert.AreEqual("Задумчивый", list.end.Data.Name);
            Assert.AreEqual("<thinking>", list.end.Data.Tag);
        }

        [TestMethod]
        public void FindItem_ShouldReturnCorrectItem()
        {
            var list = new MyList<Emoji>();
            var emoji1 = new Emoji("Улыбка", "<smile>");
            var emoji2 = new Emoji("Сияющий", "<happy>");
            list.AddToEnd(emoji1);
            list.AddToEnd(emoji2);

            var foundItem = list.FindItem(emoji2);

            Assert.IsNotNull(foundItem);
            Assert.AreEqual("Сияющий", foundItem.Data.Name);
            Assert.AreEqual("<happy>", foundItem.Data.Tag);
        }

        [TestMethod]
        public void RemoveItem_ShouldRemoveSpecifiedItem()
        {
            var list = new MyList<Emoji>();
            var emoji1 = new Emoji("Улыбка", "<smile>");
            var emoji2 = new Emoji("Сияющий", "<happy>");
            list.AddToEnd(emoji1);
            list.AddToEnd(emoji2);

            var result = list.RemoveItem(emoji1);

            Assert.IsTrue(result);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Сияющий", list.beg.Data.Name);
            Assert.AreEqual("<happy>", list.beg.Data.Tag);
        }

        [TestMethod]
        public void RemoveAllItems_ShouldRemoveAllOccurrencesOfItem()
        {
            var list = new MyList<Emoji>();
            var emoji = new Emoji("Улыбка", "<smile>");
            list.AddToEnd(emoji);
            list.AddToEnd(new Emoji("Сияющий", "<happy>"));
            list.AddToEnd(emoji);

            list.RemoveAllItems(emoji);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Сияющий", list.beg.Data.Name);
            Assert.AreEqual("<happy>", list.beg.Data.Tag);
        }

        [TestMethod]
        public void AddKItemsToBeg_ShouldAddKItemsToBeginning()
        {
            var list = new MyList<Emoji>();
            list.AddKItemsToBeg(5);

            Assert.AreEqual(5, list.Count);
            Assert.IsNotNull(list.beg);
            Assert.IsNotNull(list.end);
        }

        [TestMethod]
        public void DeepClone_ShouldReturnDeepCopyOfList()
        {
            var list = new MyList<Emoji>();
            list.AddToEnd(new Emoji("Улыбка", "<smile>"));
            list.AddToEnd(new Emoji("Сияющий", "<happy>"));

            var clonedList = list.DeepClone();

            Assert.AreEqual(list.Count, clonedList.Count);
            Assert.AreEqual(list.beg.Data.Name, clonedList.beg.Data.Name);
            Assert.AreEqual(list.beg.Data.Tag, clonedList.beg.Data.Tag);
            Assert.AreEqual(list.end.Data.Name, clonedList.end.Data.Name);
            Assert.AreEqual(list.end.Data.Tag, clonedList.end.Data.Tag);
            Assert.AreNotSame(list.beg, clonedList.beg);
            Assert.AreNotSame(list.end, clonedList.end);
        }

        [TestMethod]
        public void PrintList_ShouldPrintAllItems()
        {
            var list = new MyList<Emoji>();
            list.AddToEnd(new Emoji("Улыбка", "<smile>"));
            list.AddToEnd(new Emoji("Сияющий", "<happy>"));

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                list.PrintList();
                var result = sw.ToString().Trim();

                Assert.IsTrue(result.Contains("Улыбка"));
                Assert.IsTrue(result.Contains("<smile>"));
                Assert.IsTrue(result.Contains("Сияющий"));
                Assert.IsTrue(result.Contains("<happy>"));
            }
        }
    }
}
