using mensstore.entity;
using mensstore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mensstore.API;

[ApiController]
[Route("[controller]/v1")]
public class ProdutoController : ControllerBase
{
    [HttpGet]
    public ActionResult<Produto[]> Get([FromServices] IProdutoRepository produtoRepo)
    {
        var produtos = produtoRepo.GetAll();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get([FromServices] IProdutoRepository produtoRepo,
        int id)
    {
        var produto = produtoRepo.GetById(id);
        if (produto is null) return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<Produto> Post([FromServices] IProdutoRepository produtoRepo,
        Produto produto)
    {
        if (ModelState.IsValid)
        {
            produtoRepo.Insert(produto);
            return Ok(produto);
        }
        else
        {
            return BadRequest("Model is not valid");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Produto> Put([FromServices] IProdutoRepository produtoRepo,
    int id, Produto produto)
    {
        produtoRepo.Update(id, produto);
        if (produto is null) return NotFound();

        return Ok(produto);
    }
}
