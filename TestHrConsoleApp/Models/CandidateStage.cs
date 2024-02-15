using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class CandidateStage
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int SelectionStageId { get; set; }
        public SelectionStage SelectionStage { get; set; }
        public int? testTaskId;
        public TestTask? testTask;
        public DateTime DateIn { get; set; }
        public DateTime? DatePassed { get; set; }
        public bool? IsCompleted { get; set; }
        public string Comments { get; set; }




        //Method Add/Del/Update
    }
}
