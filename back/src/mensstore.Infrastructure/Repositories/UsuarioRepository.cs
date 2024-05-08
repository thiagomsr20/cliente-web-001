using mensstore.Core;

namespace mensstore.Infrastructure;

public class UsuarioRepository : IUsuarioRepository
{
    private static List<Usuario> usuarios = new List<Usuario>();
    public void Delete(string email)
    {
        var usuario = usuarios.First(x => x.Email == email);
        if(usuario is not null)
        {
            int index = usuarios.FindIndex(x => x.Email == email);
            usuarios.RemoveAt(index);
        }
        return;
    }

    public Usuario? GetByEmail(string email) => usuarios.FirstOrDefault(x => x?.Email == email, null);

    public void Register(Usuario usuario) => usuarios.Add(usuario);

    public List<Usuario> GetAll() => usuarios;
}
