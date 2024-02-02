namespace Tamagotchi.Models
{
    public class PokemonSpecies
    {
        public int Count { get; set; }
        public string Next { get; set; } = string.Empty;
        public string Previous  { get; set; } = string.Empty;
        public List<Pokemon> Results { get; set; } = new List<Pokemon>();
    }
}