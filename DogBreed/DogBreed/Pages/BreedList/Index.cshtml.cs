using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogBreed.Data;
using DogBreed.Models;

namespace DogBreed.Pages.BreedList
{
    public class IndexModel : PageModel
    {
        private readonly DogBreed.Data.DogBreedDbContext _context;

        public IndexModel(DogBreed.Data.DogBreedDbContext context)
        {
            _context = context;
        }

        public IList<Breed> Breed { get;set; }

        public async Task OnGetAsync()
        {
            Breed = await _context.Breeds.ToListAsync();
        }
    }
}
