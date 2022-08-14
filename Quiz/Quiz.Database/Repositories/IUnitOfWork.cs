namespace Quiz.Database.Repositories
{
    public interface IUnitOfWork
    {
        IQuestionRepository Question { get; }

        //IAccountRepository Account { get; }
        void Save();
    }
}