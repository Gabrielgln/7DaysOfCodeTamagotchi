namespace TamagotchiApp.Models
{
    public class PokemonDetail
    {
        public string Name {get; set;} = string.Empty;
        public int Height {get; set;}
        public int Weight {get; set;}
        public List<AbilityDetail> Abilities {get; set;} = new List<AbilityDetail>();
    }
    public class AbilityDetail{
        public Ability Ability {get; set;} = new Ability();
        public bool IsHidden {get; set;}
        public int Slot {get; set;}
    }
    public class Ability{
        public string Name {get; set;} = string.Empty;
        public string Url {get; set;} = string.Empty;
    }
}