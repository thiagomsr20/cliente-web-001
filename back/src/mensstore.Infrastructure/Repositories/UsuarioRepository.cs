using mensstore.Core;
using mensstore.Core.Interfaces.Repositories;

namespace mensstore.Infrastructure;

public class UsuarioRepository : IUsuarioRepository
{
    private static List<Usuario> usuarios = new List<Usuario>();
    public void Delete(string name)
    {
        var usuario = usuarios.First(x => x.Name == name);
        if(usuario is not null)
        {
            int index = usuarios.FindIndex(x => x.Name == name);
            usuarios.RemoveAt(index);
        }
        return;
    }

    public Usuario? GetByName(string name) => usuarios.FirstOrDefault(x => x?.Name == name, null);

    public void Register(Usuario usuario) => usuarios.Add(usuario);

    public List<Usuario> GetAll() => usuarios;
}
