using System.Text.Json.Serialization;

namespace Senac.LocaGames.Domain.Dtos;

public class ErroResponse
{
    public string Mensagem { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Codigo { get; set; }
}

