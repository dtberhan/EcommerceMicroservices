using AutoMapper;
using CustomerWebApi.Dtos;
using CustomerWebApi.Models;

namespace CustomerWebApi.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
