using JobApplicationLibrary.Models;
using static JobApplicationLibrary.ApplicationEvaluater;

namespace JobApplicationLibrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        // Naming Conventions
        // UnitOfWork_Condition_ExpectedResult = Bu �ekilde daha sa�l�kl� cal�sma alan� belirtilmeli
        // Conditon_Result = Bu �ekilde de yap�labilir ama unit of work olursa daha g�zel olur.
        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {
            // Arrange
            var evaluater = new ApplicationEvaluater();
            var form = new JobApplication()
            {
                Applicant = new Applicant
                {
                    Age = 18
                }
            };


            // Action

            var appResult = evaluater.Evaluate(form);

            // Assert

            Assert.That(appResult, Is.EqualTo(ApplicationResult.AutoAccepted));
        }


    }
}