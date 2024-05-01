using mensstore.Core;
using Microsoft.AspNetCore.Mvc;

namespace mensstore.API;

[Route("[controller]/v1/authentication")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUsuarioRepository _usuarioRepository;
    public AuthController(ITokenService tokenService, IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    [HttpPost]
    public void Register(Usuario usuario)
    {
        var usuarioRegistrado = _usuarioRepository.GetById(usuario.Id);

        if(usuarioRegistrado is not null)
        {
            _usuarioRepository.Insert();
        }
    }

    [HttpGet]
    public ActionResult<string> GetToken(Usuario usuario)
    {
        var usuarioCadastrado = _usuarioRepository.GetById(2);
        if(usuarioCadastrado is not null)
        {
           string token = _tokenService.GenerateToken(usuario);
           return Ok(token);
        }
        return Unauthorized();
    }
}
