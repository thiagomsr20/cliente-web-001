namespace mensstore.Core.Interfaces;

public interface IUsuarioRepository
{
    Usuario? GetByName(string name);
    bool Register(Usuario usuario);
    bool Delete(string name);
    List<Usuario> GetAll();
    bool Update(string name, Usuario usuario);
}
