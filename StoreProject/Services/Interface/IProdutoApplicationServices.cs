using StoreProject.DTO;

namespace StoreProject.Services.Interface
{
    public interface IProdutoApplicationServices
    {
        Task<IEnumerable<ProdutoReadDTO>> GetAllProducts();
        Task<ProdutoReadDTO> GetProdutoById(int id);
        Task<ProdutoReadDTO> CreateProduto(ProdutoCreateDTO produto);
        Task<bool> UpdateProduto(int id, ProdutoUpdateDTO produto);
        Task<bool> DeleteProduto(int id);
        Task<IEnumerable<ProdutoReadDTO>> GetProductByName(string name);

    }
}
