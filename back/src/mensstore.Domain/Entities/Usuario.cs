﻿namespace mensstore.Core;

public class Usuario
{
    public string? Name { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
