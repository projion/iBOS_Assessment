using System.ComponentModel.DataAnnotations;

namespace iBOS_api.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int attendanceId { get; set; }
        public int employeeId { get; set; }
        public DateTime attendanceDate { get; set; }
        public bool isPresent { get; set; }
        public bool isAbsent { get; set; }
        public bool isOffday { get; set; }
    }
}
