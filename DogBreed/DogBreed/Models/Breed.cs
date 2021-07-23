using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreed.Models
{
    public class Breed
    {
        [Key]
        [HiddenInput]
        [Required]
        public int DogID { get; set; }

        public string BreedName { get; set; }

        public string SubBreedName { get; set; }
    }
}
