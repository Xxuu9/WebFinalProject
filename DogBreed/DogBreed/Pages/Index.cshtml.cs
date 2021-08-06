using DogBreed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchBreeds;

namespace DogBreed.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


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

        public List<string> AllBreedList = new List<string>();

        public List<string> ResultList = new List<string>();



        public async Task OnPostAsync(string SearchValue, string BreedType)
        {
            IfSubmit = true;

            Breeds = await _context.Breeds.ToListAsync();

            MainBreedList = Breeds.Select(breed => breed.BreedName).ToList();  // The list of all main breed names
            SubBreedList = Breeds.Select(breed => breed.SubBreedName).ToList();  // The list of all sub breed names

            AllBreedList = SearchBreedName.mergeLists(MainBreedList, SubBreedList);

            switch (BreedType)
            {
                case "both":
                    ResultList = SearchBreedName.searchStrings(AllBreedList, SearchValue);
                    break;
                case "main_breed":
                    ResultList = SearchBreedName.searchStrings(MainBreedList, SearchValue);
                    break;
                case "sub_breed":
                    ResultList = SearchBreedName.searchStrings(SubBreedList, SearchValue);
                    break;
                default:
                    break;
            }
            if (ResultList.Count != 0)
            {
                ResultSet = true;
            }

            ResultList = ResultList.Distinct().ToList();

            //return RedirectToPage("./Index");
        }
    }
}
