using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Muresan_Andrei_Cristian.Data;
using Proiect_Muresan_Andrei_Cristian.Models;

namespace Proiect_Muresan_Andrei_Cristian.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext _context;

        public IndexModel(Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genre.ToListAsync();
        }
    }
}
