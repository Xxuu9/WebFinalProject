using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreed.Models
{
    public class BreedListResponse
    {
        public Dictionary<string, string[]> message { get; set; }

        public string status { get; set; }
    }
}
