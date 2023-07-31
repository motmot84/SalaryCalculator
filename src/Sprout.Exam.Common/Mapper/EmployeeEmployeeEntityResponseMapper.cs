using AutoMapper;
using Sprout.Exam.Common.Models.DTO;
using Sprout.Exam.Common.Models.Response;

namespace Sprout.Exam.Common.Mapper
{
    public class EmployeeEmployeeEntityResponseMapper : Profile
    {
        public EmployeeEmployeeEntityResponseMapper()
        {
            CreateMap<Employee, EmployeeEntityResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.TIN, opt => opt.MapFrom(src => src.Tin))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId));
        }
    }
}
