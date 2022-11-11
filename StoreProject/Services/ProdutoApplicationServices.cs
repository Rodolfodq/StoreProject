using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject.DTO;
using StoreProject.Model;

namespace StoreProject.Services
{
    public class ProdutoApplicationServices : IProdutoApplicationServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoApplicationServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task CreateProduto(ProdutoCreateDTO produto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduto(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoReadDTO>> GetAllProducts()
        {
            try
            {
                IEnumerable<Produto> produtos = await _context.Produtos.ToListAsync();

                return _mapper.Map<IEnumerable<ProdutoReadDTO>>(produtos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoReadDTO> GetProdutoById(int id)
        {
            try
            {
                Produto produto = await _context.Produtos.Where(x => x.IdProduto == id).FirstOrDefaultAsync();
                return _mapper.Map<ProdutoReadDTO>(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                return (await _context.SaveChangesAsync() >= 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateProduto(ProdutoCreateDTO produto)
        {
            throw new NotImplementedException();
        }
    }
}
