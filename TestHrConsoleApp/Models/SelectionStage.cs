using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    /// <summary>
    /// Этапы, по котором проводят кандидата
    /// </summary>
    public class SelectionStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        //Нумерация этапов
        public int Order { get; set; }
        public string CandidateRequirements { get; set; }

        public void AddSelectionStage(SelectionStage selectionStage)
        {
            //
        }

        public void DeleteSelectionStage(int id)
        {
            //
        }

        public void UdpateSelectionStage(SelectionStage selectionStage)
        {
            //
        }
    }
}
