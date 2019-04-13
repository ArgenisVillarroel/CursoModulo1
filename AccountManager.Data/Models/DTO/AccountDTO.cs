using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountManager.Data.Models.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }

 
        public string Code { get; set; }

 
        public string Name { get; set; }


        public ViewModelDTO<int> AccountType { get; set; }
    }
}
