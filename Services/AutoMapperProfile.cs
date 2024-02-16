using AutoMapper;
using Tamagotchi.Models;

namespace Tamagotchi.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<PokemonDetail, PokemonDto>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities.Select(x => new Habilidade{Nome = x.Ability.Name})));
        }
        
    }
}