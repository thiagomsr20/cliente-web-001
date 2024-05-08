using mensstore.Core;
using mensstore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MyBCrypt = BCrypt.Net.BCrypt;

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

        if (string.IsNullOrEmpty(usuario.Name) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Password))
            return BadRequest("The name, email and password information cant be empty");

        var usuarioExistente = _usuarioRepository.GetByEmail(usuario.Email);
        if(usuarioExistente is not null)
            return BadRequest("Email already exists");

        string hasPasspowrd = MyBCrypt.EnhancedHashPassword(usuario.Password);

        novoUsuario.Name = usuario.Name;
        novoUsuario.Email = usuario.Email;
        novoUsuario.PasswordHash = hasPasspowrd;

        _usuarioRepository.Register(novoUsuario);

        return Ok(novoUsuario);
    }

    [HttpPost("login")]
    public ActionResult<Usuario> Login(UsuarioDto usuario)
    {
        var usuarioExistente = _usuarioRepository.GetByEmail(usuario.Email);

        if(usuarioExistente is null)
            return NotFound("Email not exist");

    

        if(MyBCrypt.Verify(usuario.Password, usuarioExistente.PasswordHash))
            return BadRequest("Incorrect password");


        return Ok(usuarioExistente);
    }

    [HttpGet]
    public ActionResult<Usuario> Get()
    {
        return Ok(_usuarioRepository.GetAll());
    }
}
