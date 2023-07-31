using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common.Enums;
using System;

namespace Sprout.Exam.Business
{
    public class Salary : ISalary
    {
        private readonly Func<EmployeeType, ICalculator> _calculator;

        public Salary(Func<EmployeeType, ICalculator> calculator)
        {
            _calculator = calculator;
        }

        public decimal Compute(EmployeeType type, decimal days) => _calculator(type).CalculateSalary(days);
    }
}
