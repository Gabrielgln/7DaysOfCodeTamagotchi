using System.Text.Json.Serialization;

namespace TamagotchiApp.Models
{
    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}