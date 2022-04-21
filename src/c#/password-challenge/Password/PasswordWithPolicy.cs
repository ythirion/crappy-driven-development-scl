namespace Password;

public class PasswordWithPolicy
{
    public string Password { get; set; }
    public IEnumerable<int> Range { get; set; }
    public char Letter { get; set; }
}