using AutoMapper;
using Sprout.Exam.Common.Models.DTO;
using Sprout.Exam.Common.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Common.Mapper
{
    public class UpdateEmployeeRequestEmployeeMapper : Profile
    {
        public UpdateEmployeeRequestEmployeeMapper()
        {
            CreateMap<UpdateEmployeeRequest, Employee>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.fullName))
                .ForMember(dest => dest.Tin, opt => opt.MapFrom(src => src.tin))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => DateTime.Parse(src.birthdate)))
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.typeId))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        }
    }
}
