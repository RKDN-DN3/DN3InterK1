using Quiz.Database.ViewModels;

namespace Quiz.Database.Repositories
{
    public interface IExamination_CategoryVMRepository
    {
        public IEnumerable<Examination_CategoryVM> GetAll();
    }
}
