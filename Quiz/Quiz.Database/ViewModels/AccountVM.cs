using Microsoft.AspNetCore.Http;
using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Database.ViewModels
{
    public class AccountVM
    {
        public Accounts account { get; set; } = new Accounts();


        public IEnumerable<Accounts> accounts { get; set; } = new List<Accounts>();

        
    }
}
