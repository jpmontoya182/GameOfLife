using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ResponseBase
    {
        public Guid GameId { get; set; }
        public List<int[]>? NewBoard { get; set; }
    }
}
