using mensstore.Core;
using mensstore.Core.Interfaces.Repositories;

namespace mensstore.API;
public class ProdutoRepository : IProdutoRepository
{
    private static Dictionary<int, Produto> _produtos = new Dictionary<int, Produto>() {
        {0,
            new Produto(
            id: 0,
            nome: "Camisa",
            descricao: "Camisa branca",
            possuiDesconto: true,
            desconto: 16,
            preco: 450,
            imagem: "",
            quantidade: 20,
            categoria: "Camisetas",
            destaque: true,
            novo: true,
            tamanho: "P",
            cor: "Branca"
        )},
        {1,
            new Produto(
            id: 1,
            nome: "Calça",
            descricao: "Calça preta",
            possuiDesconto: true,
            desconto: 30,
            preco: 2000,
            imagem: "",
            quantidade: 20,
            categoria: "Calças",
            destaque: false,
            novo: true,
            tamanho: "M",
            cor: "Vermelho"
        )},
        {2,
            new Produto(
            id: 2,
            nome: "Sapato",
            descricao: "Sapato rosa",
            possuiDesconto: true,
            desconto: 20,
            preco: 80,
            imagem: "",
            quantidade: 10,
            categoria: "Sapatos",
            destaque: false,
            novo: false,
            tamanho: "M",
            cor: "Rosa"
        )
        },
        {3,
            new Produto(
                id: 3,
                nome: "Pulseira",
                descricao: "Calça preta",
                possuiDesconto: false,
                desconto: 0,
                preco: 80,
                imagem: "",
                quantidade: 20,
                categoria: "Acessórios",
                destaque: true,
                novo: false,
                tamanho: "P",
                cor: "Preta"
            )
        }
    };
    public void Insert(Produto produto)
    {
        int id = _produtos.Keys.Max() + 1;
        produto.Id = id;
        _produtos.Add(id, produto);
    }
    public void Update(int id, Produto newproduto)
    {
        var oldproduto = _produtos.First(x => x.Value.Id == id).Value;

        if (oldproduto is not null)
        {
            _produtos[oldproduto.Id] = newproduto;
        }
    }
    public Produto[] GetAll() => _produtos.Values.ToArray();
    public Produto? GetById(int id) => _produtos.Values.FirstOrDefault(x => x?.Id == id, null);
    public void Delete(int id) => _produtos.Remove(id);
}