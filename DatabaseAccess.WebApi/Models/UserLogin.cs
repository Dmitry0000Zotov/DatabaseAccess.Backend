using AutoMapper;
using DatabaseAccess.Application.Common.Mappings;
using DatabaseAccess.Application.Products.Commands.CreateProduct;
using DatabaseAccess.Domain;

namespace DatabaseAccess.WebApi.Models
{
    public class UserLogin : IMapWith<Employee>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserLogin, Employee>()
                .ForMember(employee => employee.Login , opt => opt.MapFrom(userLogin => userLogin.Login))
                .ForMember(employee => employee.Password, opt => opt.MapFrom(userLogin => userLogin.Password));
        }
    }
}
