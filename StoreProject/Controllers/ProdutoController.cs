using Microsoft.AspNetCore.Mvc;
using StoreProject.DTO;
using StoreProject.Services;
using System.Collections.Generic;

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
            if(produtos != null)
                return Ok(produtos);
            return NotFound();
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProdutoReadDTO produto = await _produtoApplicationServices.GetProdutoById(id);

            if (produto != null)
                return Ok(produto);
            return NotFound();
        }

    }
}
