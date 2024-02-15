using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class ProbationPeriod
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CandidateReviews { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int employeeId { get; set; }
        public int employeeIdAsCandidate { get; set; }
        public Employee employee { get; set; }
    }

}
