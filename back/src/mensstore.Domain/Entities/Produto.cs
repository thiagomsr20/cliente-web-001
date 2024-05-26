using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mensstore.Core;
public class Produto
{
    [JsonPropertyName("Id")]
    [Key]
    public int Id { get; set; }

    [Required]
    [JsonPropertyName("Nome")]
    public string? Nome { get; set; }

    [Length(0, 400)]
    [JsonPropertyName("Descricao")]
    public string? Descricao { get; set; }

    [Required]
    [JsonPropertyName("PossuiDesconto")]
    public bool PossuiDesconto { get; set; }

    [Range(0, 100)]
    [JsonPropertyName("Desconto")]
    public double Desconto { get; set; }

    [Required]
    [JsonPropertyName("Preco")]
    [Range(1, 999999)]
    public double Preco { get; set; }

    [Required]
    [Url]
    [JsonPropertyName("Imagem")]
    public string? Imagem { get; set; }

    [JsonPropertyName("Quantidade")]
    [Required]
    [Range(1, 999999)]
    public int Quantidade { get; set; }

    [JsonPropertyName("Categoria")]
    [Required]
    public string Categoria { get; set; }

    [JsonPropertyName("Destaque")]
    public bool Destaque { get; set; }

    [JsonPropertyName("ProdutoNovo")]
    public bool Novo { get; set; }

    [JsonPropertyName("Tamanho")]
    [Required]
    public string Tamanho { get; set; }

    [JsonPropertyName("Cor")]
    [Required]
    public string Cor { get; set; }

    public Produto(int id, string nome, string descricao, bool possuiDesconto,
    double desconto, double preco, string imagem, int quantidade, string categoria,
    bool destaque, bool novo, string tamanho, string cor)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        PossuiDesconto = possuiDesconto;
        Desconto = desconto;
        Preco = preco;
        Imagem = imagem;
        Quantidade = quantidade;
        Categoria = categoria;
        Destaque = destaque;
        Novo = novo;
        Tamanho = tamanho;
        Cor = cor;

        if (PossuiDesconto) AplicaDesconto();
    }
    private double AplicaDesconto() => Preco - (Preco * Desconto / 100);
}