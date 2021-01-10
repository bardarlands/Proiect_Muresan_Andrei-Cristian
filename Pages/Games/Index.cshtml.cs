using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Muresan_Andrei_Cristian.Data;
using Proiect_Muresan_Andrei_Cristian.Models;

namespace Proiect_Muresan_Andrei_Cristian.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext _context;

        public IndexModel(Proiect_Muresan_Andrei_Cristian.Data.Proiect_Muresan_Andrei_CristianContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }
        public GameData GameD { get; set; }
        public int GameID { get; set; }
        public int GenreID { get; set; }

        public async Task OnGetAsync(int? id,int? genreID)
        {
            GameD = new GameData();
            GameD.Games = await _context.Game.Include(b => b.Publisher).Include(b => b.GameGenres).ThenInclude(b => b.Genre).AsNoTracking().OrderBy(b => b.Denumire).ToListAsync();
            if(id!=null)
            {
                GameID = id.Value;
                Game game = GameD.Games.Where(i => i.ID == id.Value).Single();
                GameD.Genres = game.GameGenres.Select(s => s.Genre);
            }
        }
    }
}
