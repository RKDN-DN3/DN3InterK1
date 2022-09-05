namespace Quiz.Database.Repositories
{
    public interface IUnitOfWork
    {
        IQuestionRepository Question { get; }

        IQuestionBankRepository QuestionBank { get; }

        IAccountRepository Account { get; }

        IExaminationRepository Examination{ get; }
        IExamination_CategoryVMRepository Examination_CategoryVM { get; }

        void Save();
    }
}