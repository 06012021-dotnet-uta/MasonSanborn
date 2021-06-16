using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Player
    {
        public Player()
        {
            Games = new HashSet<Game>();
        }

        public int PlayerId { get; set; }
        public string PlayerFname { get; set; }
        public string PlayerLname { get; set; }
        public int PlayerAge { get; set; }
        public string PlayerAddress { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
