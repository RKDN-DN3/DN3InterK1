namespace Quiz.Database.Repositories
{
    public interface IUnitOfWork
    {
        IQuestionRepository Question { get; }
        IQuestionBankRepository Question_Bank { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
