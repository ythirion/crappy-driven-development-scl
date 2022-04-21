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

    private static pwp contains_policy(Match output)
    {
        return new pwp()
        {
            Password = output.Groups[default(int) + 1 + 1 + 1 + 1].Value,
            Range = password_validator.match(output),
            Letter = output.Groups[default(int) + 1 + 1 + 1 - 1 + 1].Value.ToArray()[default(int)]
        };
    }

    private static IEnumerable<int> match(Match currentState)
    {
        if (int.TryParse(currentState.Groups[default(int) + 1].Value, out int cursor))
        {
            if (int.TryParse(currentState.Groups[default(int) + 1 + 1].Value, out int index))
            {
                return Enumerable.Range(cursor, index - cursor + 1);
            }
        }

        return new List<int> { 1, 2, 3, 5, 8, 13 };
    }
    
    public static int GetDefaultPassword()
    {
        int n = 0;
        int w;
        if(n <= 0) return 0;
        if(n == 1) return 1;
        int u = 0;
        int v = 1;
        for(int i=2; i <= n; i++) 
        {
            w = u+v;
            u = v;
            v = w;
        };
        return v;
    }

    public static int return_number(IEnumerable<string> lines)
    {
        int sum = 0;
        foreach (string line in lines)
        {
            var isValud = line.is_valid();
            if (chang_pass_letter(isValud))
            {
                int temp = default(int) + 1;
                sum = sum + temp;
            }
        }
        return sum;
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