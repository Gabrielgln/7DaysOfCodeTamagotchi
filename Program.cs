using Newtonsoft.Json;
using RestSharp;
using TamagotchiApp.Models;

var client = new RestClient($"https://pokeapi.co/api/v2/pokemon-species/");
var request = new RestRequest("", Method.Get);
var response = client.Execute(request, Method.Get);

var pokemonSpecies = JsonConvert.DeserializeObject<PokemonSpecies>(response.Content);

for (int i = 0; i < pokemonSpecies.Results.Count; i++){
    Console.WriteLine($"{i+1} - {pokemonSpecies.Results[i].Name}");
}

int escolha;

while(true){
    Console.WriteLine("\n");
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

if(response.StatusCode == System.Net.HttpStatusCode.OK){
    Console.WriteLine(response.Content);
}else{
    Console.WriteLine(response.ErrorMessage);
}

