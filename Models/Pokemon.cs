using System.Text.Json.Serialization;

namespace Tamagotchi.Models
{
    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}