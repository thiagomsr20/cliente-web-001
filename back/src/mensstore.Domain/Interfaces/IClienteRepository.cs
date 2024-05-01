using mensstore.Core;

namespace mensstore.Interfaces;

public interface IClienteRepository
{
    Cliente? GetById(int id);
    Cliente[] GetAll();
    void Insert(Cliente cliente);
    void Delete(int id);
    void Update(int id, Cliente newcliente);
}
