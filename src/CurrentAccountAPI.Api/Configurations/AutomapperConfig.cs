using AutoMapper;
using CurrentAccountAPI.Domain.DTOs;
using CurrentAccountAPI.Domain.Entity;

namespace CurrentAccountAPI.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Transaction, TransactionDTO>();
        }
    }
}
