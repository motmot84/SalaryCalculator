using AutoMapper;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Models.DTO;
using Sprout.Exam.Common.Models.Request;
using Sprout.Exam.Common.Models.Response;
using Sprout.Exam.DataAccess.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeEntityResponse> CreateEmployee(CreateEmployeeRequestBody input)
        {
            var employeeData = _mapper.Map<Employee>(input);
            var result = _employeeRepository.Create(employeeData);

            return _mapper.Map<EmployeeEntityResponse>(result);
        }

        public async Task<EmployeeEntityResponse> GetEmployee(int id)
        {
            var result = await _employeeRepository.GetById(id);
            var response = _mapper.Map<EmployeeEntityResponse>(result);

            return response;
        }

        public async Task<IEnumerable<EmployeeEntityResponse>> GetEmployees()
        {
            var result = await _employeeRepository.GetAll();
            var response = _mapper.Map<IEnumerable<EmployeeEntityResponse>>(result);

            return response;
        }

        public async Task<EmployeeEntityResponse> UpdateEmployee(int id, UpdateEmployeeRequest input)
        {
            var data = _mapper.Map<Employee>(input);
            data.Id = id;

            var result = await _employeeRepository.Update(data);
            var response = _mapper.Map<EmployeeEntityResponse>(result);

            return response;
        }

        public async Task<EmployeeEntityResponse> DeleteEmployee(int id)
        {
            var data = await _employeeRepository.GetById(id);
            data.IsDeleted = true;
            var result = await _employeeRepository.Delete(data);
            var response = _mapper.Map<EmployeeEntityResponse>(result);

            return response;
        }
    }
}
