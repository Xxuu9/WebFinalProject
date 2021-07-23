using DogBreed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreed.Data
{
    public class DogBreedDbContext: DbContext
    {

        public DogBreedDbContext(DbContextOptions<DogBreedDbContext> options): base(options)
        {
        }

        public DbSet<Breed> Breeds { get; set; }
    }
}
