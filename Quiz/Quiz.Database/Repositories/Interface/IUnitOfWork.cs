namespace Quiz.Database.Repositories
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        void Save();
    }
}