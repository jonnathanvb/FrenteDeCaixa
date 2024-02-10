namespace API.Config;

public class AppSettings
{
    public string SqlServer { get; set; } = string.Empty;
    public JwtConfig Jwt { get; set; } = new JwtConfig();
}