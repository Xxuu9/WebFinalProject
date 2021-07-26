using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchBreeds_Tests
{
    [TestClass]
    public class SearchBreedsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string string1 = "Dog";
            string string2 = "D";
            bool result = SearchBreeds.SearchBreedName.CheckStringContain(string1, string2);
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string string1 = "Dog";
            string string2 = "d";
            bool result = SearchBreeds.SearchBreedName.CheckStringContain(string1, string2);
            Assert.AreEqual(true, result);

        }
    }
}
