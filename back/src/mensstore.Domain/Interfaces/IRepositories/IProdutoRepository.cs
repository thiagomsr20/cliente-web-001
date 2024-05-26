namespace mensstore.Core.Interfaces;

public interface IProdutoRepository
{
    Produto? GetById(int id);
    List<Produto> GetAll();
    bool Insert(Produto produto);
    bool Delete(int id);
    bool Update(int id, Produto newproduto);
}
