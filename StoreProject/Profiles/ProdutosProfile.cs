using AutoMapper;
using StoreProject.DTO;
using StoreProject.Model;

namespace StoreProject.Profiles
{
    public class ProdutosProfile : Profile
    {
        public ProdutosProfile()
        {
            CreateMap<Produto, ProdutoReadDTO>();
            CreateMap<ProdutoCreateDTO, Produto>();
        }
    }
}
