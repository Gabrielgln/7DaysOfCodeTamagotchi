using Tamagotchi.Views;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class PokemonController
    {
        private PokemonView PokemonView { get; set; }
        private PokemonApiService PokemonApiService { get; set; }
        private List<Pokemon> Pokemons { get; set; }
        private List<PokemonDetail> PokemonsAdotados { get; set; }

        public PokemonController(){
            PokemonView = new PokemonView();
            PokemonApiService = new PokemonApiService();
            Pokemons = PokemonApiService.ObterEspeciesDisponiveis();
            PokemonsAdotados = new List<PokemonDetail>();
        }
        public void Play(){
            PokemonView.MostrarMensagemDeBoasVindas();
            while(true){
                PokemonView.MostrarMenuPrincipal();
                int escolha = PokemonView.ObterEscolhaDoJogador();
                switch(escolha){
                    case 1:
                        PokemonView.MostrarMenuDeAdocao(Pokemons);
                        int indiceEspecie = PokemonView.ObterEspecieEscolhida(Pokemons);
                        while(true){
                            PokemonView.MostrarMenuDeOpcoes(Pokemons[indiceEspecie].Name);
                            escolha = PokemonView.ObterEscolhaDoJogador();
                            switch(escolha){
                                case 1:
                                    var pokemonDetail = PokemonApiService.ObterDetalhesDaEspecie(Pokemons[indiceEspecie]);
                                    PokemonView.MostrarDetalhesDaEspecie(pokemonDetail);
                                    break;
                                case 2:
                                    pokemonDetail = PokemonApiService.ObterDetalhesDaEspecie(Pokemons[indiceEspecie]);
                                    if(PokemonView.ConfirmarAdocao()){
                                        PokemonsAdotados.Add(pokemonDetail);
                                        Console.WriteLine($"{PokemonView.Name} Parabéns! Você adotou um {pokemonDetail.Name}!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────");
                                    }
                                    break;
                                case 3:
                                    break;
                            }
                            if(escolha == 3){
                                break;
                            }
                        }
                        break;
                    case 2:
                        PokemonView.MostrarPokemonsAdotados(PokemonsAdotados);
                        break;
                    case 3:
                        Console.WriteLine("Obrigado por jogar! Até a próxima!");
                        return;
                }
            }
        }
    }
}