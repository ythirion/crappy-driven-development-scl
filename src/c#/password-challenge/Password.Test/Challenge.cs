using System.Linq;
using FluentAssertions;
using Xunit;

namespace Password.Test;

public class Challenge
{
    private readonly string _input = typeof(Challenge)
        .Assembly
        .GetResourceAsString("passwords.txt");

    // Exercise from AOC 2020 : https://adventofcode.com/2020/day/2
    [Fact]
    public void CountValidPasswords()
        => password_validator.return_number(_input.@join())
            .Should()
            .Be(622);
}