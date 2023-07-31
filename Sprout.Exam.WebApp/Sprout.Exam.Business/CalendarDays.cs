using System;

namespace Sprout.Exam.Business
{
    internal class CalendarDays
    {
        public int GetWorkingDaysInMonth()
        {
            var getMonth = DateTime.Now.Month - 1 == 0 ?
                12 : DateTime.Now.Month - 1;

            var getYear = DateTime.Now.Month == 1 ? 
                DateTime.Now.Year - 1 : DateTime.Now.Year;

            var monthStart = new DateTime(getYear, getMonth, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);
            var workingDays = 0;

            for (var date = monthStart; date <= monthEnd; date = date.AddDays(1))
            {
                if( date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday ) 
                { 
                    workingDays++;
                }
            }

            return workingDays;
        }
    }
}
