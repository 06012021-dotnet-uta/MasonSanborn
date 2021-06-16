using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class RpsRound
    {
        public int RoundId { get; set; }
        public int? GameId { get; set; }
        public int PlayerId { get; set; }
        public int? Player1Id { get; set; }
        public int? Player2Id { get; set; }

        public virtual Game Game { get; set; }
    }
}
