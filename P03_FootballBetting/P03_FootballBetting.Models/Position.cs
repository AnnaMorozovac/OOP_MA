namespace P03_FootballBetting.Models
{
    using System.Collections.Generic;
    using System.Numerics;
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
