using Microsoft.AspNetCore.Mvc;
using testes.Models;
using testes.Services;

namespace testes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoService.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _produtoService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            _produtoService.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _produtoService.Update(produto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _produtoService.Delete(id);
            return NoContent();
        }
    }
}
