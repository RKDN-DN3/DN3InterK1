﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Exam_History_Detail : BaseEntity
    {
        
        [StringLength(10)]
        [Display(Name = "ID Exam")]
        public Guid ID_Exam { get; set; }


        
        [StringLength(100)]
        [EmailAddress]
        public string Email_User { get; set; }

       
        [DataType(DataType.Date)]
        [Display(Name = "Date_Do_Exam")]
        public DateTime Date_Do_Exam { get; set; }

        
        [StringLength(10)]
        [Display(Name = "ID Question")]
        public string ID_Question { get; set; }



        [Required]
        [StringLength(10)]
        [Display(Name = "ID Answer Chose")]
        public string ID_Answer_Chose { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }

        public virtual Exam_History Exam_History { get; set; }
    }
}