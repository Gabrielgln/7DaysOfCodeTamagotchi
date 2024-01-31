using TamagotchiApp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace TamagotchiApp
{
    public class PokemonApiService
    {
        public List<Pokemon> ObterEspeciesDisponiveis(){
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request, Method.Get);

            return JsonConvert.DeserializeObject<PokemonSpecies>(response.Content).Results;
        }

        public PokemonDetail ObterDetalhesDaEspecie(Pokemon pokemon){
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.Name}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request, Method.Get);

            return JsonConvert.DeserializeObject<PokemonDetail>(response.Content);
        }
    }
}