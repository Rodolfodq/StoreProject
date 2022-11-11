using StoreProject.DTO;
using StoreProject.Model;

namespace StoreProject.Services
{
    public interface IProdutoApplicationServices
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<ProdutoReadDTO>> GetAllProducts();
        Task<ProdutoReadDTO> GetProdutoById(int id);
        Task CreateProduto(ProdutoCreateDTO produto);
        Task UpdateProduto(ProdutoCreateDTO produto);
        Task DeleteProduto(Guid id);

    }
}
