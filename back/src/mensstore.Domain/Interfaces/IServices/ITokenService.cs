namespace mensstore.Core.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}
