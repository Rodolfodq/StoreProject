using StoreProject.DTO;

namespace StoreProject.Services
{
    public interface IProdutoApplicationServices
    {
        Task<IEnumerable<ProdutoReadDTO>> GetAllProducts();
        Task<ProdutoReadDTO> GetProdutoById(int id);
        Task<ProdutoReadDTO> CreateProduto(ProdutoCreateDTO produto);
        Task<bool> UpdateProduto(ProdutoUpdateDTO produto);
        Task<bool> DeleteProduto(int id);

    }
}
