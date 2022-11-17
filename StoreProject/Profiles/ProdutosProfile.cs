using AutoMapper;
using StoreProject.DTO;
using StoreProject.Model;

namespace StoreProject.Profiles
{
    public class ProdutosProfile : Profile
    {
        public ProdutosProfile()
        {
            CreateMap<Produto, ProdutoReadDTO>().ForMember(
                dest => dest.IdProduto, opt => opt.MapFrom(src => src.Id)
                ).ReverseMap();
            CreateMap<ProdutoUpdateDTO, Produto>().ReverseMap();
        }
    }
}
