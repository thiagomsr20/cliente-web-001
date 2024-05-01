using mensstore.Core;

namespace mensstore.Interfaces;

public interface IProdutoRepository
{
    Produto? GetById(int id);
    Produto[] GetAll();
    void Insert(Produto produto);
    void Delete(int id);
    void Update(int id, Produto newproduto);
}
