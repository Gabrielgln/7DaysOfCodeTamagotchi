using Tamagotchi.Views;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class PokemonController
    {
        private PokemonView PokemonView { get; set; }
        private PokemonApiService PokemonApiService { get; set; }
        private List<Pokemon> Pokemons { get; set; }
        private List<PokemonDto> PokemonsAdotados { get; set; }

        public PokemonController(){
            PokemonView = new PokemonView();
            PokemonApiService = new PokemonApiService();
            Pokemons = PokemonApiService.ObterEspeciesDisponiveis();
            PokemonsAdotados = new List<PokemonDto>();
        }
        public void Play(){
            PokemonView.MostrarMensagemDeBoasVindas();
            while(true){
                PokemonView.MostrarMenuPrincipal();
                int escolha = PokemonView.ObterEscolhaDoJogador(3);
                switch(escolha){
                    case 1:
                        PokemonView.MostrarMenuDeAdocao(Pokemons);
                        int indiceEspecie = PokemonView.ObterEspecieEscolhida(Pokemons);
                        while(true){
                            PokemonView.MostrarMenuDeOpcoes(Pokemons[indiceEspecie].Name);
                            escolha = PokemonView.ObterEscolhaDoJogador(3);
                            switch(escolha){
                                case 1:
                                    var pokemonDetail = PokemonApiService.ObterDetalhesDaEspecie(Pokemons[indiceEspecie]);
                                    PokemonView.MostrarDetalhesDaEspecie(pokemonDetail);
                                    break;
                                case 2:
                                    pokemonDetail = PokemonApiService.ObterDetalhesDaEspecie(Pokemons[indiceEspecie]);
                                    if(PokemonView.ConfirmarAdocao()){
                                        var pokemonDto = new PokemonDto();
                                        pokemonDto.AtualizarPokemon(pokemonDetail);
                                        PokemonsAdotados.Add(pokemonDto);
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
                        if(PokemonsAdotados.Count == 0){
                            Console.WriteLine("Você não tem nenhum Pokémon adotado.");
                            break;
                        }
                        Console.WriteLine("Escolha um Pokémon para interagir:");
                        for(int i=0; i < PokemonsAdotados.Count; i++){
                            Console.WriteLine($"{i+1}. {PokemonsAdotados[i].Nome}");
                        }
                        int indicePokemon = PokemonView.ObterEscolhaDoJogador(PokemonsAdotados.Count);
                        PokemonDto pokemonEscolhido = PokemonsAdotados[indicePokemon-1];
                        int opcaoInteracao = 0;
                        while(opcaoInteracao != 6){
                            PokemonView.MostrarMenuInteracao(pokemonEscolhido);
                            opcaoInteracao = PokemonView.ObterEscolhaDoJogador(6);
                            switch(opcaoInteracao){
                                case 1:
                                    pokemonEscolhido.MostrarStatus();
                                    break;
                                case 2:
                                    pokemonEscolhido.Alimentar();
                                    break;
                                case 3:
                                    pokemonEscolhido.Brincar();
                                    break;
                                case 4:
                                    pokemonEscolhido.Descansar();
                                    break;
                                case 5:
                                    pokemonEscolhido.DarCarinho();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        PokemonView.MostrarPokemonsAdotados(PokemonsAdotados);
                        break;
                    case 4:
                        Console.WriteLine("Obrigado por jogar! Até a próxima!");
                        return;
                }
            }
        }
    }
}