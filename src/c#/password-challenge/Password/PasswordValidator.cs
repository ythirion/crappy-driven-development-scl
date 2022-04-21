using System.Text.RegularExpressions;

namespace Password;

public static class PasswordValidator
{
    private static bool IsValid(PasswordWithPolicy passwordWithPolicy)
    {
        return passwordWithPolicy.Range
            .Contains(passwordWithPolicy
                .Password
                .Count(p => p == passwordWithPolicy.Letter)
            );
    }
        

    public static int CountValidPasswords(IEnumerable<string> lines)
    {
        return lines
            .Select(line => line.ToPasswordWithPolicy())
            .Count(IsValid);
    }
    
    private static readonly Regex PasswordRegex = new(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");
    public static IEnumerable<string> SplitToLines(this string str)
    {
        return str.Split(Environment.NewLine);
    }

    public static PasswordWithPolicy ToPasswordWithPolicy(this string input)
    {
        return PasswordRegex.Matches(input)
            .ToList()
            .Select(ToPasswordWithPolicy)
            .Single();
    }

    private static IEnumerable<int> ToRange(Match match)
    {
        var start = int.Parse(match.Groups[1].Value);
        var end = int.Parse(match.Groups[2].Value);

        return Enumerable.Range(start, end - start + 1);
    }

    private static PasswordWithPolicy ToPasswordWithPolicy(Match match)
    {
        return new PasswordWithPolicy()
        {
            Password = match.Groups[4].Value,
            Range = ToRange(match),
            Letter = match.Groups[3].Value.First()
        };
    }
}