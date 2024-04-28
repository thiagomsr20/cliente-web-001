using System.Text.Json.Serialization;

namespace mensstore.entity;

public class Cliente
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("Endereco")]
    public string? Endereco { get; set; }

    [JsonPropertyName("CPF")]
    public string? CPF { get; set; }

    public Cliente(int id, string nome, string endereco, string cpf){
        Id = id;
        Nome = nome;
        Endereco = endereco;
        CPF = cpf;
    }
}
