using NPoco.FluentMappings;
namespace lmgtpersistence.Mapping
{
    public interface IDtoMappings
    {
        Map<T> For<T>();
    }
}