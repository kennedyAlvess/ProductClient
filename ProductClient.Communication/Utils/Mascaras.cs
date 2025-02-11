using System.Text.RegularExpressions;

namespace ProductClient.Communication.Utils;

public static partial class Mascaras
{
    public static string MascaraCpf(string cpf)
    {
        return CPFRegex().Replace(cpf, "***.***.$3-$4");
    }

    public static string MascaraEmail(string email)
    {
        return EmailRegex().Replace(email, m =>
                                    m.Groups[1].Value + new string('*', m.Groups[2].Value.Length) + m.Groups[3].Value
                                );
    }

    [GeneratedRegex(@"(\d{3})\.(\d{3})\.(\d{3})-(\d{2})")]
    private static partial Regex CPFRegex();

    [GeneratedRegex(@"(^\w{3})(\w+)(@.*)")]
    private static partial Regex EmailRegex();


}
