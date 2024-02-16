using Tamagotchi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Tamagotchi
{
    public class PokemonApiService
    {
        public List<Pokemon> ObterEspeciesDisponiveis(){
            try
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon-species/");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request, Method.Get);
                if(response.IsSuccessStatusCode){
                    return JsonConvert.DeserializeObject<PokemonSpecies>(response.Content).Results;
                }
                Console.WriteLine($"Erro ao obter a listagem dos Pokémons: {response.ErrorMessage}");
                return null;

            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"Erro de solicitação: {ex.Message}");
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return null;
            }
        }
        public PokemonDetail ObterDetalhesDaEspecie(Pokemon pokemon){
            try
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.Name}");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request, Method.Get);
                if(response.IsSuccessStatusCode){
                    return JsonConvert.DeserializeObject<PokemonDetail>(response.Content);
                }
                Console.WriteLine($"Erro ao obter detalhes do Pokémon: {response.ErrorMessage}");
                return null;

            }
            catch(HttpRequestException ex){
                Console.WriteLine($"Erro de solicitação: {ex.Message}");
                return null;
            }
            catch(Exception ex){
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return null;
            }
        }
    }
}