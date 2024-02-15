using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Resume { get; set; }
        //Ссылка на профиль в социальных сетях(опционально)
        public string? SocialProfile { get; set; }
        //Ссылка на профиль на специализированных сайтах(например, hh.ru)
        public string? JobSiteProfile { get; set; }
        //Кандидат сейчас рассмаритвается или с ним уже закрыт вопрос?
        public bool isActive { get; set; }
        public bool? IsHired { get; set; }
        public int employeeId { get; set; }
        //Hr, который привел
        public Employee? employee { get; set; }





        //Method Add/Del/Update
    }
}
