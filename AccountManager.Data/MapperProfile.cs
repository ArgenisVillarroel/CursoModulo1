using AccountManager.Data.Models;
using AccountManager.Data.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Data
{
    public class MapperProfile
        : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountType, ViewModelDTO<int>>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Description, opt => opt.MapFrom(o => $"{o.Code} - {o.Name}"));

            CreateMap<AccountType, AccountDTO>();

            CreateMap<AccountTypeDTO, AccountType>()
                .ForMember(d => d.RowVersion, opt => opt.Ignore())
                .ForMember(d => d.Accounts, opt => opt.Ignore());

            CreateMap<Account, AccountDTO>();

            CreateMap<AccountDTO, Account>()
                .ForMember(d => d.RowVersion, opt => opt.Ignore())
                .ForMember(d => d.AccountTypeId, opt => opt.Ignore());
        }
    }
}
