using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            MergedList = StringList1.Zip(StringList2, (String1, String2) => $"{String1} {String2}").ToList();

            return MergedList;
        }


        //FIXME how to get the data from the database in Library
        //public static Task<List<string>> SearchStringsFromDatabaseAsync(string SearchValue) {
        //    List<string> MainBreedList = new List<string>();
        //    List<string> SubBreedList = new List<string>();
        //    List<string> AllBreedList = new List<string>();
        //    List<string> ResultList = new List<string>();

        //    DogBreed.Data.DogBreedDbContext _context;


        //    object Breeds = _context.Breeds.ToListAsync();



        //    return ResultList;
        //}



    }
}
