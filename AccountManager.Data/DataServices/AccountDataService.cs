using AccountManager.Data.Core;
using AccountManager.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data.DataServices
{
    public class AccountDataService
        : DataServiceBase<Account, int, AccountManagerDbContext>
    {
        public AccountDataService(IMapper mapper, AccountManagerDbContext context) 
            : base(mapper, context)
        {
        }
    }
}
