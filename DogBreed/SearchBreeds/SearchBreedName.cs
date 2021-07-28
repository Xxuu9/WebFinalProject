using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchBreeds
{
    public class SearchBreedName
    {
        public static bool CheckStringContain(string BreedName, string SearchValue)
        {
            if (!String.IsNullOrEmpty(BreedName) && !String.IsNullOrEmpty(SearchValue) && BreedName.ToLower().Contains(SearchValue.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> SearchStrings(List<String> StringList, string SearchValue)
        {

            List<string> ResultList = new List<string>();

            foreach (var Element in StringList)
            {
                if (CheckStringContain(Element, SearchValue))
                {
                    ResultList.Add(Element);
                }
            }

            return ResultList;
        }

        public static List<string> MergeLists(List<string> StringList1, List<string> StringList2)
        {
            List<string> MergedList = new List<string>();

            MergedList = StringList1.Zip(StringList2, (string1, string2) => $"{string1} {string2}").ToList();

            return MergedList;
        }



    }
}
