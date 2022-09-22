using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class GamesGenres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idGameGenre { get; set; }

        [ForeignKey("Games")]
        public int idGame { get; set; }

        [ForeignKey("Genres")]
        public int idGenre { get; set; }
    }
}
