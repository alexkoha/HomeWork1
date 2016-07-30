using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strings;

namespace StringsTest
{
    //Nice
    [TestClass]
    public class TestSplitedTools
    {
        [TestMethod]
        public void SplitedTools_SplitToWords_Sentence_With_Three_Words()
        {
            SplitedTools test = new SplitedTools();
            string[] splited = test.SplitToWords("I am Alex");
            string[] target = {"I", "am", "Alex"};
            CollectionAssert.AreEqual(target, splited);
        }

        [TestMethod]
        public void SplitedTools_SplitToWords_Empty_Sentence()
        {
            SplitedTools test = new SplitedTools();
            string[] splited = test.SplitToWords("      ");
            string[] target = {  };
            CollectionAssert.AreEqual(target, splited);
        }

        [TestMethod]
        public void SplitedTools_SplitToWords_Sentence_With_Big_Spaces()
        {
            SplitedTools test = new SplitedTools();
            string[] splited = test.SplitToWords("  I     am        Alex   ");
            string[] target = { "I", "am", "Alex" };
            CollectionAssert.AreEqual(target, splited);
        }

        public void SplitedTools_SplitToWords_Sentence_Complex()
        {
            SplitedTools test = new SplitedTools();
            string[] splited = test.SplitToWords("  I@^&*(     @#am    %$@    Alex!~@#$   ");
            string[] target = { "I@^&*(", "@#am", "%$@", "Alex!~@#$" };
            CollectionAssert.AreEqual(target, splited);
        }


    }
}
