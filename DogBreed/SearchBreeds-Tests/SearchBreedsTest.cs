using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            bool result = SearchBreeds.SearchBreedName.checkStringContain(string1, string2);
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        [TestCategory("Contain")]
        [DataRow("Dog", "og ")]
        public void CheckStringContainNorm2(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.checkStringContain(string1, string2);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        [DataRow("", "d")]
        [DataRow("Dog", "")]
        [TestCategory("Contain")]
        public void CheckStringContainEmpty(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.checkStringContain(string1, string2);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        [TestCategory("Contain")]
        [DataRow(null, "dog")]
        [DataRow("Dog", null)]
        public void CheckStringContainNull(string string1, string string2)
        {
            bool result = SearchBreeds.SearchBreedName.checkStringContain(string1, string2);
            Assert.AreEqual(false, result);

        }


        [TestMethod]
        [TestCategory("Merge")]
        public void MergeListsNorm()
        {
            List<string> list1 = new List<string>{ "Dog1", "Dog2", "Dog3" };
            List<string> list2 = new List<string>{ "", "subDog2", "subDog3" };

            List<string> answer = new List<string> { "Dog1 ", "Dog2 subDog2", "Dog3 subDog3" };

            List<string> result;

            result = SearchBreeds.SearchBreedName.mergeLists(list1, list2);

            Assert.AreEqual(true, answer.SequenceEqual(result));

        }


        [TestMethod]
        [TestCategory("Search")]
        public void SearchStringsNorm()
        {
            List<string> list1 = new List<string> { "Dog1 ", "Dog2 subDog2", "Dog3 subDog3" };
            string string1 = "Dog1";
            List<string> answer = new List<string> { "Dog1 "};

            List<string> result;

            result = SearchBreeds.SearchBreedName.searchStrings(list1, string1);

            Assert.AreEqual(true, answer.SequenceEqual(result));

        }
    }
}
