namespace Tamagotchi.Models
{
    public class PokemonDto
    {
        public string Nome {get; set;} = string.Empty;
        public int Altura {get; set;}
        public int Peso {get; set;}
        public List<Habilidade> Habilidades {get; set;}
        public int Alimentacao {get; set;}
        public int Humor {get; set;}
        public int Energia {get; set;}
        public int Saude {get; set;}

        public PokemonDto(){
            var random = new Random();
            Alimentacao = random.Next(15);
            Humor = random.Next(15);
            Energia = random.Next(15);
            Saude = random.Next(15);
        }
        //public void AtualizarPokemon(PokemonDetail pokemonDetail)
        //{
        //    Nome = pokemonDetail.Name;
        //    Altura = pokemonDetail.Height;
        //    Peso = pokemonDetail.Weight;
        //    Habilidades = pokemonDetail.Abilities.Select(x => new Habilidade { Nome = x.Ability.Name }).ToList();
        //}
        public void Alimentar(){
            Alimentacao++;
            Energia--;
            Console.WriteLine("Pokémon Alimentado!");
        }
        public void Brincar(){
            Humor++;
            Energia--;
            Alimentacao--;
            Console.WriteLine("Pokémon Feliz!");
        }
        public void Descansar(){
            Energia++;
            Humor--;
            Console.WriteLine("Pokémon a Mimir!");
        }
        public void DarCarinho(){
            Humor++;
            Saude++;
            Console.WriteLine("Pokémon Amado!");
        }
        public void MostrarStatus(){
            Console.WriteLine($"Status do Pokémon {Nome}:");
            Console.WriteLine($"Alimentação: {Alimentacao}");
            Console.WriteLine($"Humor: {Humor}");
            Console.WriteLine($"Energia: {Energia}");
            Console.WriteLine($"Saúde: {Saude}");
        }
    }
    public class Habilidade
    {
        public string Nome {get; set;} = string.Empty;
    }
}