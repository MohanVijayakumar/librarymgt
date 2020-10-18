using lmgtcommon;
namespace lmgtpersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDatabaseWrapper databaseWrapper)
        {
            _DbWrapper = databaseWrapper;
        }

        private IDatabaseWrapper _DbWrapper;
        public void Start()
        {
            _DbWrapper.Db.BeginTransaction();
        }

        public void Complete()
        {
            _DbWrapper.Db.CompleteTransaction();
        }

        public void RollBack()
        {
            _DbWrapper.Db.AbortTransaction();
        }

    }
}