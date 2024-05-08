using mensstore.Core;
using mensstore.Core.Interfaces.Repositories;
using mensstore.Core.Interfaces.Services;
using mensstore.Infrastructure;
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

    [HttpPost("register")]
    public ActionResult<Usuario> Register(UsuarioDto usuario)
    {
        Usuario novoUsuario = new Usuario();

        if (string.IsNullOrEmpty(usuario.Name) || string.IsNullOrEmpty(usuario.Name) || string.IsNullOrEmpty(usuario.Password))
            return BadRequest("The name, email and password information cant be empty");

        var usuarioExists = _usuarioRepository.GetByName(usuario.Name);

        if(usuarioExists is not null)
            return BadRequest("User already exists");

        string hasPasspowrd = BCrypt.Net.BCrypt.HashPassword(usuario.Password);

        novoUsuario.Name = usuario.Name;
        novoUsuario.PasswordHash = hasPasspowrd;

        _usuarioRepository.Register(novoUsuario);

        return Ok(novoUsuario);
    }

    [HttpPost("login")]
    public ActionResult<Usuario> Login(UsuarioDto usuario)
    {
        var usuarioExists = _usuarioRepository.GetByName(usuario.Name ?? string.Empty);

        if(usuarioExists is null)
            return NotFound("User not exist");

        bool verifyPassword = BCrypt.Net.BCrypt.Verify(usuario.Password, usuarioExists.PasswordHash);

        if (!verifyPassword)
            return BadRequest("Incorrect password");

        string token = _tokenService.GenerateToken(usuarioExists);
        return Ok(token);
    }

    [HttpGet]
    public ActionResult<Usuario> Get()
    {
        return Ok(_usuarioRepository.GetAll());
    }
}
