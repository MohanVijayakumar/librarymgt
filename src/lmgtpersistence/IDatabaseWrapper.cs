using System.Collections.Generic;
using System.Threading.Tasks;

using NPoco;
namespace lmgtpersistence
{
    public interface IDatabaseWrapper
    {
        IDatabase Db {get;}

        Task<List<T>> ReturnProcAsync<T>(string sqlStatement,object[] args);
        Task<List<T>> ReturnProcAsync<T>(string sqlStatement);
    }
}