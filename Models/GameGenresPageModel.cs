using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Muresan_Andrei_Cristian.Data;

namespace Proiect_Muresan_Andrei_Cristian.Models
{
    public class GameGenresPageModel : PageModel
    {
        public List<AssignedGenreData> AssignedGenresDataList;

        public void PopulateAssignedGenreData(Proiect_Muresan_Andrei_CristianContext context, Game game)
        {
            var allGenres = context.Genre;
            var gameGenres = new HashSet<int>
            (
                game.GameGenres.Select(c =>c.GameID)
            );
            AssignedGenresDataList = new List<AssignedGenreData>();
            foreach (var cat in allGenres)
            {
                AssignedGenresDataList.Add(new AssignedGenreData
                {
                    GenreID = cat.ID,
                    Name = cat.GenreName,
                    Assigned=gameGenres.Contains(cat.ID)
                });
            }
        }
        public void UpdateGameGenres(Proiect_Muresan_Andrei_CristianContext context,string[] selectedGenres,Game gameToUpdate)
        {
            if (selectedGenres == null)
            {
                gameToUpdate.GameGenres = new List<GameGenre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var gameGenres = new HashSet<int>(gameToUpdate.GameGenres.Select(c => c.Genre.ID));
            foreach(var cat in context.Genre)
            {
                if(selectedGenresHS.Contains(cat.ID.ToString()))
                {
                    if(!gameGenres.Contains(cat.ID))
                    {
                        gameToUpdate.GameGenres.Add(
                            new GameGenre
                            {
                                GameID=gameToUpdate.ID,
                                GenreID=cat.ID
                            });
                    }
                }
                else
                {
                    if(gameGenres.Contains(cat.ID))
                    {
                        GameGenre courseToRemove = gameToUpdate.GameGenres.SingleOrDefault(i => i.GenreID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }

            }
        }
    }
}
