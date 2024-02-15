using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHrConsoleApp.Models;

namespace TestHrConsoleApp
{
    internal class StounDbContext : DbContext
    {
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CandidateStage> CandidateStage { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<HRSpec> HRSpec { get; set; }
        public DbSet<ProbationPeriod> ProbationPeriod { get; set; }
        public DbSet<TestTask> TestTask { get; set; }
        public DbSet<SelectionStage> SelectionStage { get; set; }
        public DbSet<Vacancy> Vacancy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("STOUN_XX1_DB");
        }
    }
}
