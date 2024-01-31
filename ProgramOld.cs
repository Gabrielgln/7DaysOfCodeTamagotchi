using Newtonsoft.Json;
using RestSharp;
using TamagotchiApp.Models;

public class ProgramOld
{
    public static void MainOld(string[] args)
    {
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request, Method.Get);

        var pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(response.Content);

        for (int i = 0; i < pokemonSpecies.Results.Count; i++){
            Console.WriteLine($"{i+1}. {pokemonSpecies.Results[i].Name}");
        }

        int escolha;

        while(true){
            Console.WriteLine("Escolha um número: ");
            bool result = int.TryParse(Console.ReadLine(), out escolha);
            if(!(result && escolha >= 1 && escolha <= pokemonSpecies.Results.Count)){
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }else{
                break;
            }
        }

        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
        request = new RestRequest("", Method.Get);
        response = client.Execute(request, Method.Get);

        var pokemonDetails = JsonConvert.DeserializeObject<PokemonDetail>(response.Content);
        var pokemonSelected = pokemonSpecies.Results[escolha-1];
        pokemonDetails.Name = pokemonSelected.Name;

        Console.WriteLine($"Nome Pokemon: {pokemonDetails.Name}");
        Console.WriteLine($"Altura: {pokemonDetails.Height}");
        Console.WriteLine($"Peso: {pokemonDetails.Weight}");
        Console.WriteLine("Habilidades:");
        foreach(var abilityDetail in pokemonDetails.Abilities){
            Console.WriteLine(abilityDetail.Ability.Name.ToUpper());
        }
    }
}



