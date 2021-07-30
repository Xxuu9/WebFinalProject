using DogBreed.Data;
using DogBreed.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public List<string> search(string searchValue, string breedType)
        {

            // DogBreedDbContext _context = new DogBreedDbContext(options);
            // Breeds = _context.Breeds.ToListAsync();
            List<string> mainBreedList = new List<string> { "Dog1", "Dog2", "Dog3" };
            List<string> subBreedList = new List<string> { "", "subDog2", "subDog3" };
            List<string> allBreedList;
            List<string> searchResult;

            allBreedList = SearchBreeds.SearchBreedName.MergeLists(mainBreedList, subBreedList);


            switch (breedType)
            {
                case "both":
                    searchResult = SearchBreeds.SearchBreedName.SearchStrings(allBreedList, searchValue);
                    break;
                case "main_breed":
                    searchResult = SearchBreeds.SearchBreedName.SearchStrings(mainBreedList, searchValue);
                    break;
                case "sub_breed":
                    searchResult = SearchBreeds.SearchBreedName.SearchStrings(subBreedList, searchValue);
                    break;
                default:
                    searchResult = SearchBreeds.SearchBreedName.SearchStrings(allBreedList, searchValue);
                    break;
            }

            return searchResult;

            // return View();
        }
    }
}
