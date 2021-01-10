using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Proiect_Muresan_Andrei_Cristian.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 2)]
        [Display(Name = "Game Title")]
        public string Denumire { get; set; }
        public string Platform { get; set; }
        [Display(Name = "Version")]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required,StringLength(50, MinimumLength = 3)]
        public string Edition { get; set; }
        [Range(1, 1000)]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleasDate { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
