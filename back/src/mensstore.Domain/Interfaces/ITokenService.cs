namespace mensstore.Core;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}
