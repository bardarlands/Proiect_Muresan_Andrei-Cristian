using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Muresan_Andrei_Cristian.Data;
using Proiect_Muresan_Andrei_Cristian.Models;

namespace Proiect_Muresan_Andrei_Cristian.Pages.Games
{
    public class EditModel : GameGenresPageModel

    {
        private readonly Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext _context;

        public EditModel(Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.Include(b => b.Publisher)
                .Include(b => b.GameGenres).ThenInclude(b => b.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            Game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);

            if (Game == null)
            {
                return NotFound();
            }
            PopulateAssignedGenreData(_context, Game);

            ViewData["PublisherID"] = new SelectList(_context.Set<Models.Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenre)
        {
            if (id==null)
            {
                return NotFound();
            }

            var gameToUpdate = await _context.Game.Include(i => i.Publisher).Include(i => i.GameGenres).ThenInclude(i => i.Genre).FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Game>(gameToUpdate,"Game",i => i.Denumire, i => i.Platform,i => i.Price, i => i.ReleasDate, i => i.Publisher))
            {
                UpdateGameGenres(_context, selectedGenre, gameToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
           UpdateGameGenres(_context, selectedGenre, gameToUpdate);
            PopulateAssignedGenreData(_context, gameToUpdate);
            return Page();
        }
    }
}
