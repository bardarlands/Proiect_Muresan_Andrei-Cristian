using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Muresan_Andrei_Cristian.Data;
using Proiect_Muresan_Andrei_Cristian.Models;

namespace Proiect_Muresan_Andrei_Cristian.Pages.Publisher
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext _context;

        public CreateModel(Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Publisher Publisher { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
