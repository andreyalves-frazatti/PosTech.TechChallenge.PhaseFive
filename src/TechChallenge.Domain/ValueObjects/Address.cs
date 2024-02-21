namespace TechChallenge.Domain.ValueObjects;

public record Address(
    string? Street,
    string? Neighborhood,
    string? Number,
    string? City,
    string? ZipCode,
    string? Country) : IValueObject;
