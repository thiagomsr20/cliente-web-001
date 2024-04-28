using mensstore.entity;
using mensstore.Interfaces;

namespace mensstore.API;
public class ClienteRepository : IClienteRepository
{
    private static List<Cliente> _clientes = new List<Cliente>();
    public void Insert(Cliente cliente) => _clientes.Add(cliente);
    public void Update(int id, Cliente newcliente){
        var oldcliente = _clientes.FirstOrDefault(x => x.Id == id);
        
        if(oldcliente is not null){
            oldcliente = newcliente;
        }
    }
    public Cliente[] GetAll() => _clientes.ToArray();
    public Cliente? GetById(int id) => _clientes.FirstOrDefault(x => x?.Id == id, null);
    public void Delete(int id) => _clientes.RemoveAll(x => x.Id == id);
}