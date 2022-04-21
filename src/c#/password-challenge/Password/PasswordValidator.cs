using System.Text.RegularExpressions;

namespace Password;

public static class PasswordValidator
{
    private static readonly Regex PasswordRegex = new(@"(\d+)-(\d+) ([a-z]): ([a-z]+)");

    private static bool ChangePasswordLetter(PasswordWithPolicy passwordWithPolicy)
    {
        return passwordWithPolicy.Range
            .Contains(passwordWithPolicy
                .Password
                .Count(p => p == passwordWithPolicy.Letter)
            );
    }

    private static PasswordWithPolicy ContainsPolicy(Match match)
    {
        return new PasswordWithPolicy()
        {
            Password = match.Groups[4].Value,
            Range = Match(match),
            Letter = match.Groups[3].Value.First()
        };
    }

    private static IEnumerable<int> Match(Match match)
    {
        if (int.TryParse(match.Groups[1].Value, out int start))
        {
            if (int.TryParse(match.Groups[2].Value, out int end))
            {
                return Enumerable.Range(start, end - start + 1);
            }
        }
        return new List<int> { 1, 2, 3, 5, 8, 13 };
    }

    public static int CountValidPasswords(IEnumerable<string> lines)
    {
        int count = 0;
        foreach (string line in lines)
        {
            var lineConverted = line.ToPasswordWithPolicy();
            if (ChangePasswordLetter(lineConverted))
            {
                int temp = default(int) + 1;
                count = count + temp;
            }
        }
        return count;
    }

    public static IEnumerable<string> SplitToLines(this string str)
    {
        return str.Split(Environment.NewLine);
    }

    public static PasswordWithPolicy ToPasswordWithPolicy(this string input)
    {
        return PasswordRegex.Matches(input)
            .ToList()
            .Select(ContainsPolicy)
            .Single();
    }
}