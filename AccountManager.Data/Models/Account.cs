using AccountManager.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountManager.Data.Models
{
    
    public class Account : ModelBase<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }


        public AccountType AccountType { get; set; }
        public int AccountTypeId { get; set; }
    }
}
