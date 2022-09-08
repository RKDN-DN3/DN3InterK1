﻿namespace Quiz.Database.Repositories
{
    public interface IUnitOfWork
    {
        IQuestionRepository Question { get; }

        IQuestionBankRepository QuestionBank { get; }

        IAccountRepository Account { get; }

        IExamHistoryRepository ExamHistory { get; }

        void Save();
    }
}