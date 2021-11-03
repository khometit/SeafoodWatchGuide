using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The Create Model class provides the structure for how the Create
    /// page should behave.
    /// </summary>
    public class CreateModel : PageModel
    {
        // ILogger variable
        private readonly ILogger<CreateModel> _logger;

        /// <summary>
        /// Constructor method for the Create Page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(ILogger<CreateModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        //Product service object to provide all available services
        public JsonFileProductService ProductService { get; }

        // Getter and Setter method for the Creat page
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Since we are creating a new record in the dataset, we don't need to pull anything for validation
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// Upon clicking Submit, the update is saved and the user is redirected back to the Admin page to 
        /// so they can update more information
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            //Check for input validation, if not valid, return to page
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            //Check if input was just a bunch of numbers in Title
            bool hasLetters = false;
            for (int i = 0; i < Product.Title.Length; i++)
            {
                if (char.IsLetter(Product.Title[i]))
                {
                    hasLetters = true;
                }
            }

            if(hasLetters == false)
            {
                ModelState.AddModelError(string.Empty, "Title must contain letters");
                return Page();
            }


            //If valid, create the card
            ProductService.CreateCard(Product);
            return RedirectToPage("Admin");
        }
    }
}
