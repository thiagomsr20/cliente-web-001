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
    public ActionResult Put([FromServices] IProdutoRepository produtoRepo,
    int id, Produto produto)
    {
        if (ModelState.IsValid)
        {
            if (produtoRepo.GetById(id) is null) return NotFound();

            produtoRepo.Update(id, produto);
            return Ok();
        }
        return BadRequest("Model is not valid");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromServices] IProdutoRepository produtoRepo,
        int id)
    {
        if (produtoRepo.GetById(id) is null) return NotFound();

        produtoRepo.Delete(id);
        return Ok();
    }
}
