using TamagotchiApp;
using TamagotchiApp.Models;
using TamagotchiApp.Views;

Menu menu = new Menu();
PokemonApiService pokemonApiService = new PokemonApiService();
List<Pokemon> pokemons = pokemonApiService.ObterEspeciesDisponiveis();
List<PokemonDetail> pokemonsAdotados = new List<PokemonDetail>();

menu.MostrarMensagemDeBoasVindas();
while(true){
    menu.MostrarMenuPrincipal();
    int escolha = menu.ObterEscolhaDoJogador();
    switch(escolha){
        case 1:
            menu.MostrarMenuDeAdocao(pokemons);
            int indiceEspecie = menu.ObterEspecieEscolhida(pokemons);
            while(true){
                menu.MostrarMenuDeOpcoes(pokemons[indiceEspecie].Name);
                escolha = menu.ObterEscolhaDoJogador();
                switch(escolha){
                    case 1:
                        var pokemonDetail = pokemonApiService.ObterDetalhesDaEspecie(pokemons[indiceEspecie]);
                        menu.MostrarDetalhesDaEspecie(pokemonDetail);
                        break;
                    case 2:
                        pokemonDetail = pokemonApiService.ObterDetalhesDaEspecie(pokemons[indiceEspecie]);
                        if(menu.ConfirmarAdocao()){
                            pokemonsAdotados.Add(pokemonDetail);
                            Console.WriteLine($"{menu.Name} Parabéns! Você adotou um {pokemonDetail.Name}!");
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
            menu.MostrarPokemonsAdotados(pokemonsAdotados);
            break;
        case 3:
            Console.WriteLine("Obrigado por jogar! Até a próxima!");
            return;
    }
}

