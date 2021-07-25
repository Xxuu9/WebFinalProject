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

        public IndexModel(ILogger<IndexModel> logger, DogBreed.Data.DogBreedDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public void OnGet()
        {

        }

        private readonly Data.DogBreedDbContext _context;

        public IList<Breed> Breeds { get; set; }

        public List<string> BreedList = new List<string>();

        public List<string> SubBreedList = new List<string>();

        public List<string> ResultList = new List<string>();


        public async Task OnPostAsync(string searchValue, string breedType)
        {

            Breeds = await _context.Breeds.ToListAsync();

            BreedList = Breeds.Select(breed => breed.BreedName).ToList();  // The list of all main breed names
            SubBreedList = Breeds.Select(breed => breed.SubBreedName).ToList();  // The list of all sub breed names
            var AllBreedList = BreedList.Zip(SubBreedList, (breed, subBreed) => $"{breed} {subBreed}");  //The list of all (main breed name + sub breed name)s

            switch (breedType)
            {
                case "both":
                    // search what user typed in the list
                    foreach (var AllBreed in AllBreedList)
                    {
                        if (AllBreed.Contains(searchValue)){
                            // TODO upper case and lower case
                            ResultList.Add(AllBreed);
                        }
                    }

                    
                    if (ResultList.Count != 0) {
                        ResultSet = true;
                    }
                    break;
                case "main_breed":
                    break;
                case "sub_breed":
                    break;
                default:
                    break;
            }

            //return RedirectToPage("./Index");
        }
    }
}
