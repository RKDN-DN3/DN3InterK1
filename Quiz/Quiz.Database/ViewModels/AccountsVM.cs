using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Entities;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Database.ViewModels
{
    public class AccountsVM
    {
        public Accounts account { get; set; } = new Accounts();

        public IEnumerable<Accounts> accounts { get; set; } = new List<Accounts>();
    }
}
