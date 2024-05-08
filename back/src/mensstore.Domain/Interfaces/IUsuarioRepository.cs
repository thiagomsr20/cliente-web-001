namespace mensstore.Core;

public interface IUsuarioRepository
{
    Usuario? GetByEmail(string email);
    void Register(Usuario usuario);
    void Delete(string email);
    List<Usuario> GetAll();
}
