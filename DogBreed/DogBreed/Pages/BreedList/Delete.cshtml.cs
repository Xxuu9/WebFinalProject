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
    public class DeleteModel : PageModel
    {
        private readonly DogBreed.Data.DogBreedDbContext _context;

        public DeleteModel(DogBreed.Data.DogBreedDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breed = await _context.Breeds.FindAsync(id);

            if (Breed != null)
            {
                _context.Breeds.Remove(Breed);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
