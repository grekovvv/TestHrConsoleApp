using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public int IdAsCandidate { get; set; }

        //Вычисления текучести кадров в компании за всё время
        //Опционально с определённого dateIn
        public double? GetEmployeeTurnoverInCompany(DateTime? dateIn)
        {
            if (dateIn == null)
                dateIn = DateTime.MinValue;
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    return dbContext.Employee
                            .Count(e => e.DateOut != null && e.DateIn > dateIn) /
                                dbContext.Employee
                                   .Count(e => e.DateIn > dateIn) * 100;
                }
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }

        //Вычисления текучести кадров в департаменте
        public double? GetEmployeeTurnoverInDepartment(DateTime? dateIn, DateTime? dateOut, int departmentId)
        {
            if (dateIn == null)
                dateIn = DateTime.MinValue;
            if (dateOut== null)
                dateOut = DateTime.MaxValue;
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    double workTodayEmployee = dbContext.Employee
                            .Where(e => e.DepartmentId == departmentId 
                            && e.DateOut == null
                            && e.DateIn > dateIn).Count();
                    double workOutEmployee = dbContext.Employee
                            .Where(e => e.DepartmentId == departmentId
                            && e.DateOut < dateOut
                            && e.DateIn > dateIn).Count();

                    return workTodayEmployee / (workOutEmployee * 100);
                }
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }


        //Method Add/Del/Update
        public void AddEmployee(Employee employee)
        {
            //
        }

        public void DeleteEmployee(int id)
        {
            //
        }

        public void UdpateEmployee(Employee employee)
        {
            //
        }
    }
}
