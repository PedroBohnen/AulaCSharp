using Senac.LocaGames.Domain.Models;

namespace Senac.LocaGames.Domain.Dtos.Requests;

public class AtualizarRequest
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
}
