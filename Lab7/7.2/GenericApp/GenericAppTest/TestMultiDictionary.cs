using GenericApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericAppTest
{
    [TestClass]
    public class TestMultiDictionary
    {
        [TestMethod]
        public void MultiDictionary_Count_One_item()
        {
            var test = new MultiDictionary<int,string>();
            test.Add(1,"Alex");

            Assert.AreEqual(1, test.Count);
        }

        [TestMethod]
        public void MultiDictionary_Count_Two_Items_In_Diffrents_Keys()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Avi");

            Assert.AreEqual(2, test.Count);
        }

        [TestMethod]
        public void MultiDictionary_Count_Three_Items_In_Same_Key()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(1, "Avi");
            test.Add(1, "Ido");

            Assert.AreEqual(3, test.Count);
        }

        [TestMethod]
        public void MultiDictionary_Add_One_Value()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(1, test.Keys.Count);
        }

        [TestMethod]
        public void MultiDictionary_Add_Five_Values()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");
            test.Add(3, "Alex");
            test.Add(4, "Alex");
            test.Add(5, "Alex");

            Assert.AreEqual(5, test.Count);
            Assert.AreEqual(5, test.Keys.Count);
        }

        [TestMethod]
        public void MultiDictionary_Remove_Exist_Key()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(true, test.Remove(1));
            Assert.AreEqual(1, test.Count);
        }

        [TestMethod]
        public void MultiDictionary_Remove_Not_Exist_Key()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(false, test.Remove(3));
            Assert.AreEqual(2, test.Count);
        }


        [TestMethod]
        public void MultiDictionary_Remove_Exist_Key_and_Value()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(true, test.Remove(1,"Alex"));
            Assert.AreEqual(1, test.Count);
        }

        [TestMethod]
        public void MultiDictionary_Remove_Not_Exist_Key_and_Value()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(false, test.Remove(3,"Moshe"));
            Assert.AreEqual(2, test.Count);
        }

        [TestMethod]
        public void MultiDictionary_Clear_Not_Empty_List()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            test.Clear();

            Assert.AreEqual(0, test.Count);
            Assert.AreEqual(0, test.Keys.Count);
        }

        [TestMethod]
        public void MultiDictionary_Clear_Empty_List()
        {
            var test = new MultiDictionary<int, string>();


            test.Clear();

            Assert.AreEqual(0, test.Count);
            Assert.AreEqual(0, test.Keys.Count);
        }

        [TestMethod]
        public void MultiDictionary_ContainsKey_Key_Excist()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(true, test.ContainsKey(1));
        }
        [TestMethod]
        public void MultiDictionary_ContainsKey_Key_Not_Excist()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(false, test.ContainsKey(234));
        }

        [TestMethod]
        public void MultiDictionary_Contains_Key_And_Value_Excist()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(true, test.Contains(1,"Alex"));
        }

        [TestMethod]
        public void MultiDictionary_Contains_Key_Exist_Value_Not_Excist()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(false, test.Contains(1, "Moshe"));
        }

        [TestMethod]
        public void MultiDictionary_Contains_Key_Not_Value_Excist()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(false, test.Contains(5, "Alex"));
        }

        [TestMethod]
        public void MultiDictionary_Contains_Key_and_Value_Not_Excist()
        {
            var test = new MultiDictionary<int, string>();
            test.Add(1, "Alex");
            test.Add(2, "Alex");

            Assert.AreEqual(false, test.Contains(5, "Moshe"));
        }



    }


}
