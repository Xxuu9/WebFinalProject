using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchBreeds
{
    public class SearchBreedName
    {
        public static bool checkStringContain(string breedName, string searchValue)
        {
            if (!String.IsNullOrEmpty(breedName) && !String.IsNullOrEmpty(searchValue) && breedName.ToLower().Contains(searchValue.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> searchStrings(List<String> stringList, string searchValue)
        {

            List<string> resultList = new List<string>();

            foreach (var element in stringList)
            {
                if (checkStringContain(element, searchValue))
                {
                    resultList.Add(element);
                }
            }

            return resultList;
        }

        public static List<string> mergeLists(List<string> stringList1, List<string> stringList2)
        {
            List<string> mergedList = new List<string>();

            mergedList = stringList1.Zip(stringList2, (string1, string2) => $"{string1} {string2}").ToList();

            return mergedList;
        }




    }
}
