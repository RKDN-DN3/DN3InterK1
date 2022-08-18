﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Exam_History 
    {
       
        [StringLength(10)]
        [Display(Name = "ID Exam")]
        public Guid ID_Exam { get; set; }
       

        
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string Email_User { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Do Exam ")]
        public DateTime DateDoExam { get; set; }

        [Required]
        [Display(Name = "Mark")]
        public int Mark { get; set; }

        [Required]
        [Display(Name = "Time Do Exam")]
        public int TimeDoExam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Flag IsDelete")]
        public string IsDelete { get; set; }
        
        public Accounts Accounts { get; set; }
        public Examination Examinations { get; set; }
        public virtual ICollection<Exam_History_Detail> Exam_History_Details { get; set; }

    }
    
}