namespace mensstore.Core;

public class Usuario
{
    public string? Name { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
}
