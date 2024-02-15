using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int СhiefId { get; set; }
        public Employee Сhief { get; set; }
        public int NumberOfEmployees { get; set; }



        //Method Add/Del/Update
    }
}
