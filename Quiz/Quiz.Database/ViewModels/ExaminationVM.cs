using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Entities;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Database.ViewModels
{
    public class ExaminationVM
    {
        public Examination examination{ get; set; } = new Examination();

        public IEnumerable<Examination_Detail> examination_Details { get; set; } = new List<Examination_Detail>();

        public IEnumerable<List_Question_In_Exam> list_Question_In_Exams { get; set; } = new List<List_Question_In_Exam>();

    }
}
