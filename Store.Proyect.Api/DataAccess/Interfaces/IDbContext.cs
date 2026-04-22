namespace Store.Proyect.Api.DataAccess.Interfaces;
using System.Data.Common;

public interface IDbContext
{
    DbConnection Connection { get; }
}


