using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Interface
{
    public interface ISalary
    {
        public decimal Compute(EmployeeType type, decimal days);
    }
}
