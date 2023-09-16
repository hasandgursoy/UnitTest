using JobApplicationLibrary.Models;
using static JobApplicationLibrary.ApplicationEvaluater;

namespace JobApplicationLibrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        // Naming Conventions
        // UnitOfWork_Condition_ExpectedResult = Bu þekilde daha saðlýklý calýsma alaný belirtilmeli
        // Conditon_Result = Bu þekilde de yapýlabilir ama unit of work olursa daha güzel olur.
        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {

            // Arrange
            var evaluater = new ApplicationEvaluater();
            var form = new JobApplication()
            {
                Applicant = new Applicant
                {
                    Age = 18,

                },
                TechStackList = new List<string>() { "" }

            };


            // Action

            var appResult = evaluater.Evaluate(form);

            // Assert

            Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoRejected));
        }

        [Test]
        public void Application_WithNoTechStack_TransferredToAutoRejected()
        {

            // Arrange
            var evaluater = new ApplicationEvaluater();

            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age = 18 },
                TechStackList = new List<string>() { "", "" }
            };


            // Action

            var appResult = evaluater.Evaluate(form);

            // Assert

            Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoRejected));
        }


        [Test]
        public void Application_WithTechstackOver75P_TransferredToAutoAccepted()
        {

            // Arrange
            var evaluater = new ApplicationEvaluater();

            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age = 18 },
                TechStackList = new() { "C#", "RabbitMQ", "Microservice", "Visual Studio" },
                YearsOfExperience = 16
                
            };


            // Action

            var appResult = evaluater.Evaluate(form);

            // Assert

            Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoAccepted));
        }
    }
}