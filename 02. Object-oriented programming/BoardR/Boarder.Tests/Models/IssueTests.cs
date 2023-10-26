namespace Boarder.Tests.Models
{
    using Boarder.Models;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IssueTests
    {
        [TestMethod]
        public void AdvanceStatus_Should_Advance_When_StatusIsOpen()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Issue issue = new Issue(validTitle, validDescription, validDueDate);
            issue.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.Verified, issue.Status);
        }

        [TestMethod]
        public void AdvanceStatus_Should_NotAdvance_When_StatusIsVerified()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Issue issue = new Issue(validTitle, validDescription, validDueDate);
            issue.AdvanceStatus();
            issue.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.Verified, issue.Status);
        }

        [TestMethod]
        public void RevertStatus_Should_Revert_When_StatusIsVerified()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Issue issue = new Issue(validTitle, validDescription, validDueDate);

            issue.AdvanceStatus();
            Assert.AreEqual(Status.Verified, issue.Status);
            issue.RevertStatus();    
            Assert.AreEqual(Status.Open, issue.Status);
        }

        [TestMethod]
        public void RevertStatus_Should_NotRevert_When_StatusIsOpen()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Issue issue = new Issue(validTitle, validDescription, validDueDate);
            issue.RevertStatus();

            //Assert
            Assert.AreEqual(Status.Open, issue.Status);
        }
    }
}
