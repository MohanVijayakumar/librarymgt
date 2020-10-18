using System.Collections.Generic;
using System.Threading.Tasks;

using NPoco;
namespace lmgtpersistence
{
    public class DatabaseWrapper : IDatabaseWrapper
    {
        public DatabaseWrapper(IDatabaseFactoryProvider factoryProvider)
        {
            Db = factoryProvider.Factory.GetDatabase();
        }
        public IDatabase Db {get;private set;}

        public async Task<List<T>> ReturnProcAsync<T>(string sqlStatement,object[] args)
        {
            return await Db.FetchAsync<T>(sqlStatement,args);
        }

        public async Task<List<T>> ReturnProcAsync<T>(string sqlStatement)
        {
            return await Db.FetchAsync<T>(sqlStatement);
        }
    }    
}