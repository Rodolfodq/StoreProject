using Microsoft.AspNetCore.Mvc;
using StoreProject.DTO;
using StoreProject.Services;

namespace StoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationServices _produtoApplicationServices;

        public ProdutoController(IProdutoApplicationServices produtoApplicationServices)
        {
            _produtoApplicationServices = produtoApplicationServices;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<ProdutoReadDTO> produtos  = await _produtoApplicationServices.GetAllProducts();
            return Ok(produtos);
        }

        [HttpGet("GetProductById/{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProdutoReadDTO produto = await _produtoApplicationServices.GetProdutoById(id);

            if (produto != null)
                return Ok(produto);
            return NotFound("Produto não encontrado!");
        }

        [HttpGet("GetProductByName")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            IEnumerable<ProdutoReadDTO> produtos = await _produtoApplicationServices.GetProductByName(name);
            return Ok(produtos);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProdutoCreateDTO produto)
        {
            ProdutoReadDTO produtoReadDto = await _produtoApplicationServices.CreateProduto(produto);
            return CreatedAtRoute(nameof(GetProductById), new { Id = produtoReadDto.IdProduto }, produtoReadDto);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProdutoUpdateDTO produto)
        {            
            if (await _produtoApplicationServices.UpdateProduto(id, produto))
                return NoContent();
            return NotFound("Produto não encontrado!");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(await _produtoApplicationServices.DeleteProduto(id))
                return NoContent();
            return NotFound("Produto não encontrado!");
        }

    }
}
