namespace mensstore.Core.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario? GetByName(string name);
    void Register(Usuario usuario);
    void Delete(string name);
    List<Usuario> GetAll();
}
