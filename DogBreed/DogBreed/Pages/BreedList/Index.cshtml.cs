using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogBreed.Data;
using DogBreed.Models;
using Newtonsoft.Json;

namespace DogBreed.Pages.BreedList
{
    public class IndexModel : PageModel
    {
        private readonly DogBreedDbContext _context;

        private string dogUrl = "https://dog.ceo/api/breeds/list/all";

        public IndexModel(DogBreedDbContext context)
        {
            _context = context;
        }

        public IList<Breed> Breeds { get;set; }

        public async Task OnGetAsync()
        {
            Breeds = await _context.Breeds.ToListAsync();

            if (Breeds.Count == 0) {
                string json = new System.Net.WebClient().DownloadString(dogUrl);
                BreedListResponse breedResponse = JsonConvert.DeserializeObject<BreedListResponse>(json);
                foreach (var item in breedResponse.message)
                {
                    var mainBreed = item.Key;
                    foreach (var subBreed in item.Value)
                    {
                        Breed a = new Breed()
                        {
                            BreedName = mainBreed,
                            SubBreedName = subBreed
                        };
                        _context.Breeds.Add(a);

                    }
                };

                await _context.SaveChangesAsync();

                Breeds = await _context.Breeds.ToListAsync();
            }

        }

    }
}
