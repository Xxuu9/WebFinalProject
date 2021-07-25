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

        public string Result
        {
            get; set;
        }

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

        public List<string> breedList = new List<string>();

        public List<string> subBreedList = new List<string>();


        public async Task OnPostAsync(string searchValue, string breedType)
        {

            Breeds = await _context.Breeds.ToListAsync();

            breedList = Breeds.Select(breed => breed.BreedName).ToList();  // The list of all main breed names
            subBreedList = Breeds.Select(breed => breed.SubBreedName).ToList();  // The list of all sub breed names
            var allBreedList = breedList.Zip(subBreedList, (breed, subBreed) => $"{breed}{subBreed}");  //The list of all (main breed name + sub breed name)s

            switch (breedType)
            {
                case "both":
                    foreach (var allBreed in allBreedList) { 

                    }


                    Result = $"{breedType}: ";
                    ResultSet = true;
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
