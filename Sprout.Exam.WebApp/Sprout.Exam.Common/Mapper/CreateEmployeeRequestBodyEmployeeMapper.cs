using AutoMapper;
using Sprout.Exam.Common.Models.DTO;
using Sprout.Exam.Common.Models.Request;

namespace Sprout.Exam.Common.Mapper
{
    public class CreateEmployeeRequestBodyEmployeeMapper : Profile
    {
        public CreateEmployeeRequestBodyEmployeeMapper()
        {
            CreateMap<CreateEmployeeRequestBody, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Tin, opt => opt.MapFrom(src => src.Tin))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        }
    }
}
