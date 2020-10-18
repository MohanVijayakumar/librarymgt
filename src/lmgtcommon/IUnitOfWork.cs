namespace lmgtcommon
{
    public interface IUnitOfWork
    {
        void Start();

        void Complete();

        void RollBack();
    }
}