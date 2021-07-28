using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchBreeds_Tests
{
    [TestClass]
    public class SearchBreedsTest
    {
        [TestMethod]
        [DataRow("Dog", "D")]
        [DataRow("Dog", "d")]
        [TestCategory("Contain")]
        public void CheckStringContainNorm(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.CheckStringContain(string1, string2);
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        [TestCategory("Contain")]
        [DataRow("Dog", "og ")]
        public void CheckStringContainNorm2(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.CheckStringContain(string1, string2);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        [DataRow("", "d")]
        [DataRow("Dog", "")]
        [TestCategory("Contain")]
        public void CheckStringContainEmpty(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.CheckStringContain(string1, string2);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        [TestCategory("Contain")]
        [DataRow(null, "dog")]
        [DataRow("Dog", null)]
        public void CheckStringContainNull(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.CheckStringContain(string1, string2);
            Assert.AreEqual(false, result);

        }
    }
}
