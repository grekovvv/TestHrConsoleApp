using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHrConsoleApp.Models
{
    public class HRSpec
    {
        public int employeeId { get; set; }
        public Employee employee { get; set; }
        public double effectivity { get; set; }

        //кол-во принятых на определённую стадию
        public int? CountAcceptsToSelectStage(int employeeId, int stageId)
        {
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    return dbContext.CandidateStage
                     .Where(cs => cs.SelectionStageId == stageId)
                     .Join(dbContext.Candidate,
                           cs => cs.CandidateId,
                           c => c.Id,
                           (cs, c) => new { CandidateStage = cs, Candidate = c })
                     .Where(x => x.Candidate.employeeId == employeeId)
                     .Select(x => x.Candidate)
                     .Count();

                }
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }

        //кол-во принятых на испытательный срок
        public int? CountAcceptsToProbationPeriod(int employeeId)
        {
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    return dbContext.ProbationPeriod
                     .Join(dbContext.Candidate,
                           cs => cs.employeeIdAsCandidate,
                           c => c.Id,
                           (cs, c) => new { ProbationPeriod = cs, Candidate = c })
                     .Where(x => x.Candidate.employeeId == employeeId)
                     .Select(x => x.Candidate)
                     .Count();

                }
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }

        //кол-во принятых на работу после испытательного срока
        public int? CountAcceptsAfterProbationPeriod(int employeeId)
        {
            try
            {
                using (var dbContext = new StounDbContext())
                {
                    return dbContext.ProbationPeriod
                     .Join(dbContext.Candidate,
                           cs => cs.employeeIdAsCandidate,
                           c => c.Id,
                           (cs, c) => new { ProbationPeriod = cs, Candidate = c })
                     .Where(x => x.Candidate.employeeId == employeeId && x.Candidate.IsHired == true)
                     .Select(x => x.Candidate)
                     .Count();

                }
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }
        /// <summary>
        /// Одна из вариаций эффективности 
        /// кол-во прошедших испытательный срок/
        /// кол-во принятых на испытательный срок * 100
        /// </summary>
        /// <returns></returns>
        public double? HrDepartmentEfficiencyByProbationPeriod(int employeeId)
        {
            try
            {
                return CountAcceptsAfterProbationPeriod(employeeId) /
                    (CountAcceptsToProbationPeriod(employeeId) * 100);
            }
            catch (Exception ex)
            {
                //лог
                return null;
            }
        }

        /*1. ещё это можно привязать к количеству открытых вакансий
        * 2. делать срез активности одного относительно других hr
        * 3. создать отдельную систему по KPI сотрудников и вносить это коэфициентом в эффективность Hr
        * 4. создать дополнительные коэфициенты включения в процесс найма других сотрудников,
        * к примеру, ведущего программиста, который будет собеседовать, ведь его время тоже стоит денег,
        * и если таких включений слишком много, то компания будет терять на этом деньги, а следовательно,
        * эффективность hr будет падать. НО не факт, это уже зона эзоторики и гаданий, так как проблема может быть
        * не в hr, а в других структурах, которые обслуживают этапы.
        * 5. Иметь на руках статистику из других компаний и сравнивать их деятельность hr с вашими hr
        * 6. Добавить дополнительные коэфициенты (MVP), за каждый год, который пораработал найденный сотрудник,
        * НО это уже будет несколько позиций эффектиности, смешивать всё в одну формулу неправильно.
        * 7. Среднее время, затраченное на заполнение открытой вакансии. 
        * 8. Оценка кандидатов об HR (отдельное свойство, которое при желании может стать коэфициентом для эффективности)
        * и тд.
        */


        //Method Add/Del/Update
    }

    //также можно сделать таблицу (HrForDepartment), в которой будет многие-ко-многим связь
    //employee и department. Так как в большой компании HR-специалистов может быть много и
    //каждый будет нанимать в свой отдел.
}
