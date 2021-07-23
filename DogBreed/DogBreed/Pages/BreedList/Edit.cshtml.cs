using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogBreed.Data;
using DogBreed.Models;

namespace DogBreed.Pages.BreedList
{
    public class EditModel : PageModel
    {
        private readonly DogBreed.Data.DogBreedDbContext _context;

        public EditModel(DogBreed.Data.DogBreedDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(Breed.DogID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BreedExists(int id)
        {
            return _context.Breeds.Any(e => e.DogID == id);
        }
    }
}
