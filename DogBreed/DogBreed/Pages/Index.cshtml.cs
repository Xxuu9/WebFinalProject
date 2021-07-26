using DogBreed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreed.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //public List<string> ResultList
        //{
        //    get; set;
        //}

        public bool ResultSet
        {
            get; protected set;
        } = false;

        //Use to not show ""
        public bool IfSubmit 
        {
            get; set;
        } = false;

        public IndexModel(ILogger<IndexModel> logger, DogBreed.Data.DogBreedDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public void OnGet()
        {
            IfSubmit = false;
        }

        private readonly Data.DogBreedDbContext _context;

        public IList<Breed> Breeds { get; set; }

        public List<string> MainBreedList = new List<string>();

        public List<string> SubBreedList = new List<string>();

        public List<string> ResultList = new List<string>();


        private static bool CheckIfContain(string BreedName, string SearchValue) {
            if (!String.IsNullOrEmpty(BreedName) && !String.IsNullOrEmpty(SearchValue) && BreedName.ToLower().Contains(SearchValue.ToLower()))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public async Task OnPostAsync(string SearchValue, string BreedType)
        {
            IfSubmit = true;

            Breeds = await _context.Breeds.ToListAsync();

            MainBreedList = Breeds.Select(breed => breed.BreedName).ToList();  // The list of all main breed names
            SubBreedList = Breeds.Select(breed => breed.SubBreedName).ToList();  // The list of all sub breed names
            var AllBreedList = MainBreedList.Zip(SubBreedList, (breed, subBreed) => $"{breed} {subBreed}");  //The list of all (main breed name + sub breed name)s

            switch (BreedType)
            {
                case "both":
                    // search the dog breed in the list
                    foreach (var AllBreed in AllBreedList)
                    {
                        if (CheckIfContain(AllBreed, SearchValue))
                        {
                            ResultList.Add(AllBreed);
                        }
                    }
                    break;
                case "main_breed":
                    foreach (var MainBreed in MainBreedList)
                    {
                        if (CheckIfContain(MainBreed, SearchValue))
                        {
                            ResultList.Add(MainBreed);
                        }
                    }
                    break;
                case "sub_breed":
                    foreach (var SubBreed in SubBreedList)
                    {
                        if (CheckIfContain(SubBreed, SearchValue))
                        {
                            ResultList.Add(SubBreed);
                        }
                    }
                    break;
                default:
                    break;
            }
            if (ResultList.Count != 0)
            {
                ResultSet = true;
            }

            //return RedirectToPage("./Index");
        }
    }
}
