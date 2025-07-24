using System.Data;

namespace Senac.LocaGames.Infra.Data.DataBaseConfiguration
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}