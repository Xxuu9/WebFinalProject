using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreed.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Result
        {
            get; set;
        }

        public bool ResultSet
        {
            get; protected set;
        } = false;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(string searchValue, string breedType)
        {
            //_logger.LogInformation($"{Request.Path}:{Request.Method}:{User?.Identity?.Name: \"Anonymous\"}");
            //_logger.LogDebug($"Left number is {leftNumber}");
            //_logger.LogTrace("About to enter switch statement");



            switch (breedType)
            {
                case "both":
                    Result = breedType + "123";
                    ResultSet = true;
                    break;
                case "main_breed":
                    break;
                case "sub_breed":
                    break;
                default:
                    break;
            }
        }
    }
}
