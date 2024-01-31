using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GameId { get; set; }
        public string GameBoard { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public DateTime DateAndTimeCreated { get; set; }   
    }
}
