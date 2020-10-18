namespace lmgtpersistence
{
    public class PersistenceStartupForWeb
    {
        public PersistenceStartupForWeb(IDatabaseFactoryProvider databaseFactoryProvider)
        {
            _DatabaseFactoryProvider = databaseFactoryProvider;
        }

        private IDatabaseFactoryProvider _DatabaseFactoryProvider;

        public void Startup()
        {
            _DatabaseFactoryProvider.Setup();   
        }
    }
}