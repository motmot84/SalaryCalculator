using Sprout.Exam.Business.Interface;
using Sprout.Exam.Common;
using System;

namespace Sprout.Exam.Business
{
    public class RegularEmployee : ICalculator
    {
        private readonly CalendarDays _days = new CalendarDays();

        public decimal CalculateSalary(decimal days)
        {
            var absDays = Math.Abs(days);
            var workingDays = _days.GetWorkingDaysInMonth();

            if (absDays >= workingDays)
            {
                return 0;
            }

            var workedDays = workingDays - absDays;
            var salary = Math.Round(
                AppConstants.REGULAR_EMPLOYEE_RATE - (AppConstants.REGULAR_EMPLOYEE_RATE / workedDays) - (AppConstants.REGULAR_EMPLOYEE_RATE * AppConstants.TAX_RATE)
                , 2);
            
            return salary;
        }
    }
}
