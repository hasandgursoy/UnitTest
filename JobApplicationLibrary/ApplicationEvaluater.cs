using JobApplicationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationLibrary
{
    public class ApplicationEvaluater
    {
        private const int minAge = 18;
        // Bu kısım bizim için unit of work kavramı yani çalışma alanımız
        public ApplicationResult Evaluate(JobApplication form)
        {
            if (form.Applicant.Age < minAge)
            {
                return ApplicationResult.AutoRejected;
            }
            return ApplicationResult.AutoAccepted;
        }

        public enum ApplicationResult
        {
            AutoRejected,
            TransferredToHR,
            TransferredToLead,
            TransferredToCTO,
            AutoAccepted
        }
    }
}
