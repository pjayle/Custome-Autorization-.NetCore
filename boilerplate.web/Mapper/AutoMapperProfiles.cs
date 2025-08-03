using AutoMapper;
using boilerplate.web.Models;
using boilerplate.web.Models.Dto;

namespace boilerplate.web.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MPermissions, LoggeInUserRolePermission>().ReverseMap();
        }
    }
}
