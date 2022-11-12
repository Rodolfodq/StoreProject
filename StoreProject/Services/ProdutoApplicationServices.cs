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
        public async Task<ProdutoReadDTO> CreateProduto(ProdutoCreateDTO produtoDto)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(produtoDto);
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();

                ProdutoReadDTO produtoReadDTO = _mapper.Map<ProdutoReadDTO>(produto);
                return produtoReadDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(int id)
        {
            try
            {
                Produto produto = await _context.Produtos.Where(x => x.IdProduto == id).FirstOrDefaultAsync();
                if (produto == null)
                    return false;
                
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<bool> UpdateProduto(ProdutoUpdateDTO produtoDto)
        {
            try
            {
                Produto produto = await _context.Produtos.Where(x => x.IdProduto == produtoDto.IdProduto).FirstOrDefaultAsync();
                if (produto == null)
                    return false;

                _mapper.Map(produtoDto, produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
