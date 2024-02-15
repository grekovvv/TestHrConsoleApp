using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime? DateClose { get; set; }
        public bool IsOpen { get; set; }

        /// <summary>
        /// Получаем количество открытых вакансий
        /// </summary>
        /// <returns></returns>
        public int? CountOpenVacancy()
        {
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    return dbContext.Vacancy.Where(v => v.IsOpen == true).Count();
                }
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }


        /// <summary>
        /// Закрываем вакансию
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SetCloseVacancy(int id)
        {
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    // Найти вакансию по Id
                    var vacancyToUpdate = dbContext.Vacancy.FirstOrDefault(v => v.Id == id);

                    if (vacancyToUpdate != null)
                    { 
                        vacancyToUpdate.IsOpen = false;
                        dbContext.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                //лог
                return false;
            }
        }

        public void AddVacancy(Vacancy vacancy)
        {
            //
        }

        public void DeleteVacancy(int id)
        {
            //
        }

        public void UdpateVacancy(Vacancy vacancy)
        {
            //
        }

    }
}
