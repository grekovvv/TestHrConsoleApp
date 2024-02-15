using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    /// <summary>
    /// Тестовые задачи
    /// </summary>
    public class TestTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public TimeSpan TimeToSolve { get; set; }
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        public int employeeId { get; set; }
        //Составитель задачи
        public Employee? employee { get; set; }
        public int employeeId_in { get; set; }
        //Человек, который внём задачу в бд
        public Employee? employee_in { get; set; }


        public void AddTestTask(TestTask testTask)
        {
            //
        }

        public void DeleteTestTask(int id)
        {
            //
        }

        public void UdpateTestTask(TestTask testTask)
        {
            //
        }
    }

    
}
