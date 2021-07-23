using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogBreed.Data;
using DogBreed.Models;

namespace DogBreed.Pages.BreedList
{
    public class CreateModel : PageModel
    {
        private readonly DogBreed.Data.DogBreedDbContext _context;

        public CreateModel(DogBreed.Data.DogBreedDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Breed Breed { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Breeds.Add(Breed);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
