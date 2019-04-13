using AccountManager.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.Models
{
    public class AccountType: ModelBase<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
