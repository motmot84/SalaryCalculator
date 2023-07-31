using System;
using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common;

namespace Sprout.Exam.Business
{
    public class Contractor : ICalculator
    {
        public decimal CalculateSalary(decimal days)
        {
            var absDays = Math.Abs(days);
            var salary = Math.Round(
                absDays * AppConstants.CONTRACTUAL_EMPLOYEE_RATE
                , 2);

            return salary;
        }
    }
}
