using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogBreed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DogBreed.Pages.BreedList
{
    public class ShowImageModel : PageModel
    {
        private readonly Data.DogBreedDbContext _context;

        public string imageUrl;

        public ShowImageModel(Data.DogBreedDbContext context)
        {
            _context = context;
        }

        public Breed Breed { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breed = await _context.Breeds.FirstOrDefaultAsync(m => m.DogID == id);

            if (Breed == null)
            {
                return NotFound();
            }

            string dogImageUrl;

            if (Breed.SubBreedName == "")
            {
                dogImageUrl = "https://dog.ceo/api/breed/" + Breed.BreedName + "/images/random";
            }
            else {
                dogImageUrl = "https://dog.ceo/api/breed/" + Breed.BreedName + "/" + Breed.SubBreedName + "/images/random";
            }

            string json = new System.Net.WebClient().DownloadString(dogImageUrl);
            ImageResponse imageResponse = JsonConvert.DeserializeObject<ImageResponse>(json);

            imageUrl = imageResponse.message;

            //return Redirect(imageResponse.message) ;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breed = await _context.Breeds.FirstOrDefaultAsync(m => m.DogID == id);

            if (Breed == null)
            {
                return NotFound();
            }

            string dogImageUrl;

            if (Breed.SubBreedName == "")
            {
                dogImageUrl = "https://dog.ceo/api/breed/" + Breed.BreedName + "/images/random";
            }
            else
            {
                dogImageUrl = "https://dog.ceo/api/breed/" + Breed.BreedName + "/" + Breed.SubBreedName + "/images/random";
            }

            string json = new System.Net.WebClient().DownloadString(dogImageUrl);
            ImageResponse imageResponse = JsonConvert.DeserializeObject<ImageResponse>(json);

            imageUrl = imageResponse.message;

            //return Redirect(imageResponse.message) ;

            return Page();
        }

    }
}
