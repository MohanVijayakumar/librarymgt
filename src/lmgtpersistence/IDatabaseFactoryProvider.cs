using NPoco;
namespace lmgtpersistence
{
    public interface IDatabaseFactoryProvider
    {
        DatabaseFactory Factory {get;}

        void Setup();
    }
}