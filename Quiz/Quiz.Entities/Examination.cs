﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Examination : BaseEntity
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Name Of Exam")]
        public string Name { get; set; }


        [MaxLength]
        [Display(Name = "Short Description")]
        public string ShortDes { get; set; }


        [MaxLength]
        [Display(Name = "Content")]
        public string Content { get; set; }


        [Required]
        [Display(Name = "Time Of Exam")]
        public int Duration { get; set; }


        [Required]
        [Display(Name = "Number Of Questions")]
        public int NumberOfQuestions { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Flag TimeRetricted")]
        public string IsTimeRetricted { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Flag Delete")]
        public string IsDelete { get; set; }

    }
}
