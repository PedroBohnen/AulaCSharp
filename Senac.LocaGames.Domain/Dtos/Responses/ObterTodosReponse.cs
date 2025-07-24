using Senac.LocaGames.Domain.Models;

namespace Senac.LocaGames.Domain.Dtos.Responses;

public class ObterTodosReponse
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public bool Disponivel { get; set; }
    public DateTime? DataEntrega { get; set; }
    public string Categoria { get; set; }
    public bool IsEmAtraso { get; internal set; }
}