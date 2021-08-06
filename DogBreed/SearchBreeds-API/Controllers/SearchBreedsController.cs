using DogBreed.Data;
using DogBreed.Models;
using DogBreed.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchBreeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchBreeds_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchBreedsController : ControllerBase
    {

        private readonly DogBreedDbContext _context;


        public SearchBreedsController(DogBreedDbContext context)
        {
            _context = context;

        }

        public List<string> searchResult;

        public IList<Breed> Breeds { get; set; }


        public List<string> mainBreedList = new List<string>();

        public List<string> subBreedList = new List<string>();

        public List<string> allBreedList = new List<string>();

        [HttpGet]
        public async Task<List<String>> searchAsync(string searchValue, string breedType)
        {

            Breeds = await _context.Breeds.ToListAsync();


            mainBreedList = Breeds.Select(breed => breed.BreedName).ToList();  // The list of all main breed names
            subBreedList = Breeds.Select(breed => breed.SubBreedName).ToList();  // The list of all sub breed names

            allBreedList = SearchBreedName.mergeLists(mainBreedList, subBreedList);


            switch (breedType)
            {
                case "both":
                    searchResult = SearchBreedName.searchStrings(allBreedList, searchValue);
                    break;
                case "main_breed":
                    searchResult = SearchBreedName.searchStrings(mainBreedList, searchValue);
                    break;
                case "sub_breed":
                    searchResult = SearchBreedName.searchStrings(subBreedList, searchValue);
                    break;
                default:
                    searchResult = SearchBreedName.searchStrings(allBreedList, searchValue);
                    break;
            }

            return searchResult;

        }
    }
}
