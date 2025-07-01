using System;

namespace PasswordManager.Models;

public class PasswordDto
{
    public required string Name { get; init; }
    public string? Website { get; init; }
    public required string Value { get; init; }
}