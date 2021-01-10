using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Muresan_Andrei_Cristian.Data;
using Proiect_Muresan_Andrei_Cristian.Models;

namespace Proiect_Muresan_Andrei_Cristian.Pages.Games
{

    public class CreateModel : GameGenresPageModel
    {
        private readonly Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext _context;

        public CreateModel(Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Models.Publisher>(), "ID", "PublisherName");
            var game = new Game();
            game.GameGenres = new List<GameGenre>();
            PopulateAssignedGenreData(_context, game);
            return Page();

        }

        [BindProperty]
        public Game Game { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenre)
        {
            var newGame = new Game();
            if(selectedGenre != null)
            {
                newGame.GameGenres = new List<GameGenre>();
                foreach(var cat in selectedGenre)
                {
                    var catToAdd = new GameGenre
                    {
                        GenreID = int.Parse(cat)
                    };
                    newGame.GameGenres.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Game>(newGame, "Game", i => i.Denumire, i => i.Platform, i => i.Price, i => i.ReleasDate, i => i.Publisher))
            {
                UpdateGameGenres(_context, selectedGenre, newGame);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateGameGenres(_context, selectedGenre, newGame);
            PopulateAssignedGenreData(_context, newGame);
            return Page();
        }
    }
}
