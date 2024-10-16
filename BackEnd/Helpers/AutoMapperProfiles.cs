using AutoMapper;
using BackEnd.Dtos;
using BackEnd.Extensions;
using BackEnd.Models;

namespace BackEnd.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUsuario, MembroDTO>()
                .ForMember(d => d.Idade, o => o.MapFrom(s =>s.DataDeNascimento.CalularIdade()))
                .ForMember(d => d.FotoUrl, o => o.MapFrom(s => s.Fotos.FirstOrDefault(x => x.IsMain)!.Url));
            CreateMap<Foto, FotoDTO>();
            CreateMap<MembroUpdateDTO, AppUsuario>();
        }
    }
}
