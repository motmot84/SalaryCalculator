using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Common.Models.Response
{
    public class EmployeeEntityResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Birthdate { get; set; }
        public string TIN { get; set; }
        public int TypeId { get; set; }
    }
}
