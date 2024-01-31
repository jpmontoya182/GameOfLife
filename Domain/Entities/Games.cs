using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{  
    public class Games
    {
        public int Id { get; set; }

        public Guid GameId { get; set; }
        public string GameBoard { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public DateTime DateAndTimeCreated { get; set; }
    }
}
