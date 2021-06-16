using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Game
    {
        public Game()
        {
            RpsRounds = new HashSet<RpsRound>();
        }

        public int GameId { get; set; }
        public int? PlayerId { get; set; }
        public int Score { get; set; }

        public virtual Player Player { get; set; }
        public virtual ICollection<RpsRound> RpsRounds { get; set; }
    }
}
