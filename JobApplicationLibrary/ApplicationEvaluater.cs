using JobApplicationLibrary.Models;
using JobApplicationLibrary.Services;
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
        private List<string> techStackList = new() { "C#", "RabbitMQ", "Microservice", "Visual Studio" };
        private const int autoAcceptedYearsOfExperience = 15;
        private IdentityValidator identityValidator;

        public ApplicationEvaluater(IdentityValidator identityValidator)
        {
            this.identityValidator = identityValidator;
        }

        // Bu kısım bizim için unit of work kavramı yani çalışma alanımız
        public ApplicationResult Evaluate(JobApplication form)
        {
            if (form.Applicant.Age < minAge)
                return ApplicationResult.AutoRejected;

            var validIdentity = identityValidator.IsValid(form.Applicant.IdentityNumber);

            if (!validIdentity)
                return ApplicationResult.TransferredToHR;

            var sr = GetTechStackSimilarityRate(form.TechStackList);

            if (sr < 25)
                return ApplicationResult.AutoRejected;

            if (sr > 75 && form.YearsOfExperience >= autoAcceptedYearsOfExperience)
                return ApplicationResult.AutoAccepted;

            return ApplicationResult.AutoAccepted;
        }

        private int GetTechStackSimilarityRate(List<string> techStacks)
        {
            var matchedCount = techStacks
                .Where(i => techStackList
                .Contains(i, StringComparer.OrdinalIgnoreCase))
                .Count();

            return (int)((double)matchedCount / techStackList.Count) * 100;
        }


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
