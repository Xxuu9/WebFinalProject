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

        public static List<string> MergeLists(List<String> StringList1, List<String> StringList2)
        {
            List<string> MergedList = new List<string>();

            MergedList = (List<string>)StringList1.Zip(StringList2, (string1, string2) => $"{string1} {string2}");

            return MergedList;
        }



    }
}
