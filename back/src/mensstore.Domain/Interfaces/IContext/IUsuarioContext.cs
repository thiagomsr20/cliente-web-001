namespace mensstore.Core.Interfaces
{
    internal interface IUsuarioContext
    {
        bool Insert(Usuario usuario);
        bool Delete(string nome);
        Usuario SelectByName(string nome);
        Usuario GetAll();
    }
}
