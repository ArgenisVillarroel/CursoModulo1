using AccountManager.Data;
using AccountManager.Data.DataServices;
using AccountManager.Data.Factory;
using AccountManager.Data.Models;
using AccountManager.Data.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountManager.Test
{
    [TestClass]
    public class AccountTypeData
    {
        
        private AccountTypeDataService dataService;
        private MapperConfiguration mapperConfiguration;
        public AccountTypeData()
        {
            var factory = new AccountManagerDesignTimeFactory();
            AccountManagerDbContext context = factory.CreateDbContext(new string[] { });
            context.Database.Migrate();
            mapperConfiguration = new  MapperConfiguration(option => 
            {
                option.AddProfile<MapperProfile>();

            });
            dataService = new AccountTypeDataService(mapperConfiguration.CreateMapper(), context);

        }

        [TestMethod]
        public void AddOk()
        {
            int rowsAffected = 0;
            AccountTypeDTO accountType = new AccountTypeDTO
            {
                Code = "ACT",
                Name = "Activos"
            };

            
            rowsAffected = dataService.Save(accountType);

            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void EditOk()
        {
            int rowsAffected = 0;
            AccountTypeDTO accountType = dataService.GetByParamneters<AccountTypeDTO>(t => t.Code == "ACT", "Accounts");

            accountType.Name = $"{accountType.Name} Modificado";

            rowsAffected = dataService.Save(accountType);

            Assert.AreNotEqual(0, rowsAffected);
        }
    }
}
