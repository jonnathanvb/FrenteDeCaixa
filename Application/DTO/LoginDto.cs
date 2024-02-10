using System.ComponentModel;

namespace Application.DTO;

public class LoginDto
{
    [DefaultValue("admin")]
    public string User { get; set; } = string.Empty;
    
    [DefaultValue("admin")]
    public string Pass { get; set; } = string.Empty;
}