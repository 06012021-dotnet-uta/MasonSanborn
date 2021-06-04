namespace RockPaperScissorsV1
{
    public class Player
    {
        public string Name {get; set;}

        public Player()
        {
            Name = "Default Name";
        }
        public Player(string Name)
        {
            this.Name = Name;
        }
    }
}
