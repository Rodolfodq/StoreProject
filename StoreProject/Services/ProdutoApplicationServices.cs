using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject.DTO;
using StoreProject.Model;
using StoreProject.Repositories.Interface;
using StoreProject.Services.Interface;

namespace StoreProject.Services
{
    public class ProdutoApplicationServices : IProdutoApplicationServices
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoApplicationServices(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProdutoReadDTO> CreateProduto(ProdutoCreateDTO produtoDto)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(produtoDto);
                await _repository.Add(produto);
                await _repository.SaveChanges();

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
                await _repository.Remove(id);
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
                IEnumerable<Produto> produtos = await _repository.GetAll();

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
                Produto produto = await _repository.GetById(id);
                return _mapper.Map<ProdutoReadDTO>(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProduto(int id, ProdutoUpdateDTO produtoDto)
        {
            try
            {
                Produto produto = await _repository.GetById(id);
                if (produto == null)
                    return false;

                _mapper.Map(produtoDto, produto);
                await _repository.Update(produto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoReadDTO>> GetProductByName(string name)
        {
            try
            {
                IEnumerable<Produto> produtos = await _repository.Search(x => x.Nome.Contains(name)).ToListAsync();
                return _mapper.Map<IEnumerable<ProdutoReadDTO>>(produtos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
