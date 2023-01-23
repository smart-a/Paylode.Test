namespace Paylode.Test.API.Config;

public class JwtCredentials
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Lifetime { get; set; } = string.Empty;
}