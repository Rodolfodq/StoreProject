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

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProdutoCreateDTO produto)
        {
            ProdutoReadDTO produtoReadDto = await _produtoApplicationServices.CreateProduto(produto);
            return CreatedAtRoute(nameof(GetProductById), new { Id = produtoReadDto.IdProduto }, produtoReadDto);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProdutoUpdateDTO produto)
        {            
            if (await _produtoApplicationServices.UpdateProduto(produto))
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
