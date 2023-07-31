namespace Sprout.Exam.Common.Models.Request
{
    public class UpdateEmployeeRequest
    {
        public string fullName { get; set; }
        public string tin { get; set; }
        public string birthdate { get; set; }
        public int typeId { get; set; }
    }
}
