using Tamagotchi.Models;

namespace Tamagotchi.Views
{
    public class PokemonView
    {
        public string Name {get; set;} = string.Empty;
        public void MostrarMensagemDeBoasVindas(){
            Console.WriteLine("Bem-vindo ao jogo de adoção de pokemons!");
            Console.Write("Por favor, digite seu nome: ");
            Name = Console.ReadLine();
            Console.WriteLine("Olá, " + Name + "! Vamos começar!");
        }
        public void MostrarMenuPrincipal(){
            Console.WriteLine("--------------------------- MENU ---------------------------");
            Console.WriteLine($"{Name} Você deseja:");
            Console.WriteLine("1. Adoção de pokemons");
            Console.WriteLine("2. Interagir com seu Pokemon");
            Console.WriteLine("3. Ver pokemons adotados");
            Console.WriteLine("4. Sair do Jogo");
        }
        public void MostrarMenuDeAdocao(List<Pokemon> pokemons){
            Console.WriteLine("--------------------- ADOTAR UM POKEMON ---------------------");
            Console.WriteLine($"{Name} Escolha uma espécie:");
            for(int i = 0; i < pokemons.Count; i++){
                Console.WriteLine($"{i+1}. {pokemons[i].Name}");
            }
        }
        public void MostrarMenuDeOpcoes(string pokemonName){
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"{Name} você deseja:");
            Console.WriteLine($"1. Saber mais sobre o {pokemonName}");
            Console.WriteLine($"2. Adotar {pokemonName}");
            Console.WriteLine($"3. Voltar");
        }
        public void MostrarMenuInteracao(PokemonDto pokemonDto)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Interação:");
            Console.WriteLine($"1. Saber como o {pokemonDto.Nome} está");
            Console.WriteLine($"2. Alimentar o {pokemonDto.Nome}");
            Console.WriteLine($"3. Brincar com o {pokemonDto.Nome}");
            Console.WriteLine($"4. Colocar o {pokemonDto.Nome} para mimir");
            Console.WriteLine($"5. Dar carinho ao {pokemonDto.Nome}");
            Console.WriteLine("6. Voltar");
            Console.Write("Escolha uma opção: ");
        }
        public void MostrarDetalhesDaEspecie(PokemonDetail pokemonDetail){
            Console.WriteLine("Detalhes da Espécie:");
            Console.WriteLine($"Nome Pokemon: {pokemonDetail.Name}");
            Console.WriteLine($"Altura: {pokemonDetail.Height}");
            Console.WriteLine($"Peso: {pokemonDetail.Weight}");
            Console.WriteLine("Habilidades:");
            foreach(var abilityDetail in pokemonDetail.Abilities){
                Console.WriteLine(abilityDetail.Ability.Name.ToUpper());
            }
        }
        public int ObterEscolhaDoJogador(int maxOpcao){
            int escolha;
            while(!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > maxOpcao){
                Console.Write($"Escolha inválida. Por favor, escolha uma opção entre 1 e {maxOpcao}: ");
            }
            return escolha;
        }
        public int ObterEspecieEscolhida(List<Pokemon> pokemons){
            int escolha;
            while(true){
                Console.Write("Escolha uma espécie entre os números 1 e "+pokemons.Count+": ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemons.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }
            return escolha-1;
        } 
        public bool ConfirmarAdocao(){
            Console.Write("Você gostaria de adotar este Pokemon? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }
        public void MostrarPokemonsAdotados(List<PokemonDto> pokemonsAdotados){
            Console.WriteLine("Pokemons Adotados:");
            if(pokemonsAdotados.Count == 0){
                Console.WriteLine("Você ainda não adotou nenhum Pokemon.");
            }
            else{
                for(int i = 0; i < pokemonsAdotados.Count; i++){
                    Console.WriteLine($"{i+1}. {pokemonsAdotados[i].Nome}");
                }
            }
        }
    }
}