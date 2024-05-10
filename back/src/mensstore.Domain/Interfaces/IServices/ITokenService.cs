namespace mensstore.Core.Interfaces;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}
