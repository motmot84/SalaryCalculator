using System;

namespace Sprout.Exam.Common.Models.Request
{
    public class EmployeeRequestBodyBase
    {
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public int TypeId { get; set; }
    }
}
