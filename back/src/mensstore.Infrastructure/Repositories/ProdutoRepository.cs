using mensstore.Core;
using mensstore.Core.Interfaces;
using mensstore.Infrastructure;
using MySql.Data.MySqlClient;

namespace mensstore.API;
public class ProdutoRepository : IProdutoRepository
{
    public Produto? GetById(int id) => GetAll().FirstOrDefault(user => user.Id == id);
    public List<Produto> GetAll()
    {
        List<Produto> produtos = new List<Produto>();

        string query = "SELECT * FROM produto";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);

            conc.Open();
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                var produto = new Produto(
                    id: reader.GetInt32("Id"),
                    nome: reader.GetString("Nome"),
                    descricao: reader.GetString("Descricao"),
                    possuiDesconto: reader.GetInt16("PossuiDesconto").Equals(1) ? true : false,
                    desconto: reader.GetDouble("Desconto"),
                    preco: reader.GetDouble("Preco"),
                    imagem: reader.GetString("Imagem"),
                    quantidade: reader.GetInt32("Quantidade"),
                    categoria: reader.GetString("Categoria"),
                    destaque: reader.GetBoolean("Destaque"),
                    novo: reader.GetInt16("Novo").Equals(1) ? true : false,
                    tamanho: reader.GetString("Tamanho"),
                    cor: reader.GetString("Cor")
                );

                produtos.Add(produto);
            }
        }

        return produtos;
    }
    public bool Insert(Produto produto)
    {
        bool success = false;

        string query = "INSERT INTO mensstore.produto (`Nome`, `Descricao`, `PossuiDesconto`, `Desconto`, `Preco`, `Imagem`, `Quantidade`, `Categoria`, `Destaque`, `Novo`, `Tamanho`, `Cor`)" +
                        $"VALUES (@Nome, @Descricao, @PossuiDesconto, @Desconto, @Preco, @Imagem, @Quantidade, @Categoria, @Destaque, @Novo, @Tamanho, @Cor);";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            comm.Parameters.AddWithValue("@Nome", produto.Nome);
            comm.Parameters.AddWithValue("@Descricao", produto.Descricao);
            comm.Parameters.AddWithValue("@PossuiDesconto", produto.PossuiDesconto);
            comm.Parameters.AddWithValue("@Desconto", produto.Desconto);
            comm.Parameters.AddWithValue("@Preco", produto.Preco);
            comm.Parameters.AddWithValue("@Imagem", produto.Imagem);
            comm.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
            comm.Parameters.AddWithValue("@Categoria", produto.Categoria);
            comm.Parameters.AddWithValue("@Destaque", produto.Destaque);
            comm.Parameters.AddWithValue("@Novo", produto.Novo);
            comm.Parameters.AddWithValue("@Tamanho", produto.Tamanho);
            comm.Parameters.AddWithValue("@Cor", produto.Cor);

            conc.Open();
            int afectedRow = comm.ExecuteNonQuery();

            if (afectedRow != 0)
                success = true;
        }

        return success;
    }
    public bool Delete(int id)
    {
        bool success = false;

        string query = "DELETE FROM mensstore.produto WHERE Id = @Id;";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            comm.Parameters.AddWithValue("@Id", id);

            conc.Open();
            int afectedRow = comm.ExecuteNonQuery();

            if (afectedRow != 0)
                success = true;
        }

        return success;
    }
    public bool Update(int id, Produto newproduto)
    {
        bool success = false;

        string query = "UPDATE mensstore.produto SET Nome = @Nome, Descricao = @Descricao, PossuiDesconto = @PossuiDesconto," +
                        $"Desconto = @Desconto, Preco = @Preco, Imagem = @Imagem, Quantidade = @Quantidade, " +
                        $"Categoria = @Categoria, Destaque = @Destaque, Novo = @Novo, Tamanho = @Tamanho, Cor = @Cor" +
                        $" WHERE Id = @Id;";

        using (MySqlConnection conc = new MySqlConnection(DbCommon.conc))
        {
            MySqlCommand comm = new MySqlCommand(query, conc);
            comm.Parameters.AddWithValue("@Nome", newproduto.Nome);
            comm.Parameters.AddWithValue("@Descricao", newproduto.Descricao);
            comm.Parameters.AddWithValue("@PossuiDesconto", newproduto.PossuiDesconto);
            comm.Parameters.AddWithValue("@Desconto", newproduto.Desconto);
            comm.Parameters.AddWithValue("@Preco", newproduto.Preco);
            comm.Parameters.AddWithValue("@Imagem", newproduto.Imagem);
            comm.Parameters.AddWithValue("@Quantidade", newproduto.Quantidade);
            comm.Parameters.AddWithValue("@Categoria", newproduto.Categoria);
            comm.Parameters.AddWithValue("@Destaque", newproduto.Destaque);
            comm.Parameters.AddWithValue("@Novo", newproduto.Novo);
            comm.Parameters.AddWithValue("@Tamanho", newproduto.Tamanho);
            comm.Parameters.AddWithValue("@Cor", newproduto.Cor);
            comm.Parameters.AddWithValue("@Id", id);

            conc.Open();
            int afectedRow = comm.ExecuteNonQuery();

            if (afectedRow != 0)
                success = true;
        }

        return success;
    }
}