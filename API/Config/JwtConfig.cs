namespace API.Config;

public class JwtConfig
{

    /// <summary>
    /// Audience (Aplicativo): O público-alvo do JWT, que geralmente é o aplicativo ou serviço que deve aceitar o token.
    /// </summary>
    public string Aplicativo { get; set; } = string.Empty;
    
    /// <summary>
    /// Issuer (Autenticador): O emissor do JWT, que é geralmente o seu serviço de autenticação ou aplicação. Exemplo:
    /// </summary>
    public string Autenticador { get; set; } = string.Empty;
    
    public string ChaveSecreta { get; set; } = string.Empty;
    public int ValidadeTokenHoras { get; set; } = 0;
}