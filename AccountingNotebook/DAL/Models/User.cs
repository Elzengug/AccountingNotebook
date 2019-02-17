using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.DAL.Models
{
    public class User
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Amount { get; set; }
    }
}
