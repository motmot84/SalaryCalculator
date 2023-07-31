using Sprout.Exam.Common.Models.Request;
using Sprout.Exam.Common.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Interface
{
    public interface IEmployeeBusiness
    {
        Task<EmployeeEntityResponse> CreateEmployee(CreateEmployeeRequestBody input);
        Task<EmployeeEntityResponse> GetEmployee(int id);
        Task<IEnumerable<EmployeeEntityResponse>> GetEmployees();
        Task<EmployeeEntityResponse> UpdateEmployee(int id, UpdateEmployeeRequest input);
        Task<EmployeeEntityResponse> DeleteEmployee(int id);
    }
}
