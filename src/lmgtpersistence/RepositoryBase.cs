using NPoco;
namespace lmgtpersistence
{
    public class RepositoryBase
    {
        public RepositoryBase(IDatabaseWrapper databaseWrapper)
        {
            _Db = databaseWrapper.Db;
            _DbWrapper = databaseWrapper;
        }

        protected IDatabase _Db;
        protected IDatabaseWrapper _DbWrapper;
    }
}