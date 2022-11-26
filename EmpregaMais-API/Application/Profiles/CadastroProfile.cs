using Application.Requests;
using AutoMapper;
using Infrastructure.Enums;
using Infrastructure.Models;

namespace Application.Profiles
{
    public class CadastroProfile : Profile
    {
        public CadastroProfile()
        {
            CreateMap<CadastroRequest, LoginModel>()
                .ForMember(m => m.NomeUsuario, map => map.MapFrom(m => m.Email))
                .ForMember(m => m.Password, map => map.MapFrom(m => m.Password));

            CreateMap<CadastroRequest, UsuarioModel>()
                .ForMember(m => m.Nome, map => map.MapFrom(m => m.NomeCompleto))
                .ForMember(m => m.CpfCnpj, map => map.MapFrom(m => m.Cpfcnpj));

            CreateMap<CadastroRequest, EnderecoModel>()
                .ForMember(m => m.Cep, map => map.MapFrom(m => m.Cep))
                .ForMember(m => m.Logradouro, map => map.MapFrom(m => m.Logradouro))
                .ForMember(m => m.Complemento, map => map.MapFrom(m => m.Complemento))
                .ForMember(m => m.Uf, map => map.MapFrom(m => m.Uf))
                .ForMember(m => m.Pais, map => map.MapFrom(m => m.Pais));
        }
    }
}
