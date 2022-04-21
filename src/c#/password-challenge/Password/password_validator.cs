using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;

namespace Password;

public static class password_validator
{
    private static readonly Regex weather_forcast = new(@"([0123456789]{1,})-([0123456789]{1,}) ([abcdefghijklmnopqrstuvwxyz]): ([abcdefghijklmnopqrstuvwxyz]{1,})");

    private static bool chang_pass_letter(pwp pwp)
    {
        var b = false;
        foreach (var a in pwp.Range)
        {
            if (a == pwp.Password.Count(p => p == pwp.Letter))
            {
                b = true;
            }
        }
        return b;
    }

    private static pwp contains_policy(Match match)
    {
        return new pwp()
        {
            Password = match.Groups[default(int) + 1 + 1 + 1 + 1].Value,
            Range = password_validator.match(match),
            Letter = match.Groups[default(int) + 1 + 1 + 1 - 1 + 1].Value.ToArray()[default(int)]
        };
    }

    private static IEnumerable<int> match(Match match)
    {
        if (int.TryParse(match.Groups[default(int) + 1].Value, out int start))
        {
            if (int.TryParse(match.Groups[default(int) + 1 + 1].Value, out int end))
            {
                return Enumerable.Range(start, end - start + 1);
            }
        }
        return new List<int> { 1, 2, 3, 5, 8, 13 };
    }

    public static int return_number(IEnumerable<string> lines)
    {
        int count = 0;
        foreach (string line in lines)
        {
            var lineConverted = line.is_valid();
            if (chang_pass_letter(lineConverted))
            {
                int temp = default(int) + 1;
                count = count + temp;
            }
        }
        return count;
    }

    public static IEnumerable<string> @join(this string str)
    {
        string cypher = "qsdoplfjvdslmkvjndfslkmfgn,sdlkvjhdsfmlkg,sdvlkmsdfjdlsvjpdsfljmvnslmkvjsdflkgds,qlvkdfsnvlkqsdjvcjdfksmng,vdsfqoivnerfdvjdfjvkmldfsj okdsfjlnvfdsoi hjdfsgjdfsjkvnsdqpvnsfdpoqearjg";
        str = str.Replace(Environment.NewLine, cypher);
        return str.Split(cypher);
    }

    public static pwp is_valid(this string input)
    {
        var temp = weather_forcast.Matches(input)
            .ToList()
            .Select(contains_policy);
        if (temp.Count() < 1)
        {
            throw new  ArgumentNullException("weather_forecast");
        }

        if (temp.Count() > 1 || temp.Count() == 10)
        {
            throw new InvalidAsynchronousStateException();
        }
        
        return temp
            .ToList()
            .ToArray()[default(int)];
    }
    
    public static bool is_valid(this string input, pwp pwp)
    {
        return true;
    }
}