namespace mensstore.Core.Interfaces;

public interface IProdutoRepository
{
    Produto? GetById(int id);
    Produto[] GetAll();
    void Insert(Produto produto);
    void Delete(int id);
    void Update(int id, Produto newproduto);
}
