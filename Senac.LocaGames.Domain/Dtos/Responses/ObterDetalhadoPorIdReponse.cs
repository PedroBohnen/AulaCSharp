namespace Senac.LocaGames.Domain.Dtos.Responses;

public class ObterDetalhadoPorIdReponse
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public bool Disponivel { get; set; }
    public string Responsavel { get; set; }
    public DateTime? DataEntrega { get; set; }
    public string Categoria { get; set; }
    public bool IsEmAtraso { get; internal set; }
}
