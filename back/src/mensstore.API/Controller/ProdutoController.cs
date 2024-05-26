using mensstore.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mensstore.Core.Interfaces;

namespace mensstore.API;

[ApiController]
[Route("/v1/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepo;
    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepo = produtoRepository;
    }

    [HttpGet]
    public ActionResult<Produto[]> Get()
    {
        var produtos = _produtoRepo.GetAll();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _produtoRepo.GetById(id);
        if (produto is null) return NotFound();

        return Ok(produto);
    }

    [HttpPost, Authorize]
    public ActionResult<Produto> Post(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _produtoRepo.Insert(produto);
            return Ok(produto);
        }
        else
        {
            return BadRequest("Model is not valid");
        }
    }

    [HttpPut("{id}"), Authorize]
    public ActionResult Put(int id, Produto produto)
    {
        if (ModelState.IsValid)
        {
            if (_produtoRepo.GetById(id) is null) return NotFound();

            _produtoRepo.Update(id, produto);
            return Ok();
        }
        return BadRequest("Model is not valid");
    }

    [HttpDelete("{id}"), Authorize]
    public ActionResult Delete(int id)
    {
        if (_produtoRepo.GetById(id) is null) return NotFound();

        _produtoRepo.Delete(id);
        return Ok();
    }
}
