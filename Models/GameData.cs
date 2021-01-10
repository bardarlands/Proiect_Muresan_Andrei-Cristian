using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Muresan_Andrei_Cristian.Models
{
    public class GameData
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Genre> Genres { get;set }
        public IEnumerable<GameGenre> GameGenres { get; set; }
    }
}
