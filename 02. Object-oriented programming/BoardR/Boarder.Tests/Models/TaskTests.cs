namespace Boarder.Tests.Models
{
    using Boarder.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Constructor_Should_CreateTask_When_ValidParametersPassed()
        {
            //Arrange
            string validTitle = "ValidTitle";
            string validAssignee = "ValidAssignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);

            //Assert
            Assert.AreEqual(validTitle, task.Title, "title should match");
            Assert.AreEqual(validAssignee, task.Assignee, "assignee should match");
            Assert.AreEqual(validDueDate, task.DueDate, "dueDate should match");
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_NullTitlePassed()
        {
            //Arrange
            string nullTitle = null;
            string validAssignee = "ValidAssignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(nullTitle, validAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ShortTitlePassed()
        {
            //Arrange
            string shortTitle = new string('a', 3);
            string validAssignee = "ValidAssignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(shortTitle, validAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_LongTitlePassed()
        {
            //Arrange
            string longTitle = new string('a', 40);
            string validAssignee = "ValidAssignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(longTitle, validAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_WhiteSpaceTitlePassed()
        {
            //Arrange
            string whiteSpaceTitle = "   ";
            string validAssignee = "ValidAssignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(whiteSpaceTitle, validAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_NullAssigneePassed()
        {
            //Arrange
            string validTitle = "ValidTitle";
            string nullAssignee = null;
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(validTitle, nullAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_ShortAssigneePassed()
        {
            //Arrange
            string validTitle = "ValidTitle";
            string shortAssignee = new string('a', 3);
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(validTitle, shortAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_LongAssigneePassed()
        {
            //Arrange
            string validTitle = "ValidTitle";
            string longAssignee = new string('a', 40);
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(validTitle, longAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_WhiteSpaceAssigneePassed()
        {
            //Arrange
            string validTitle = "ValidTitle";
            string whiteSpaceAssignee = "   ";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(validTitle, whiteSpaceAssignee, validDueDate));
        }

        [TestMethod]
        public void Constructor_Should_Throw_When_PastDueDatePassed()
        {
            //Arrange
            string validTitle = "ValidTitle";
            string validAssignee = "ValidAssignee";
            DateTime pastDueDate = Convert.ToDateTime("01-01-2022");

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Task(validTitle, validAssignee, pastDueDate));
        }

        [TestMethod]
        public void Constructor_Should_CallAddEventLog_When_Initialized()
        {
            //Arange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            string expectedResult = $"Task: 'Valid Title', [Todo|01-01-2025] Assignee: Valid Assignee";

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);

            //Assert
            Assert.AreEqual(expectedResult, task.ViewInfo(), "ViewInfo() should match");
        }

        [TestMethod]        
        public void Property_Should_ChangeTitle()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            string newValidTitle = "New Valid Title";
            task.Title = newValidTitle;

            //Assert
            Assert.AreEqual(newValidTitle, task.Title, "title should match");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "please provide a non-null value")]
        public void Property_Should_Throw_When_TitleChangedWithNull()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Title = null;

            ////Assert
            //Assert.ThrowsException<ArgumentException>(() => task.Title = null, "please provide a non-null value");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "please provide a non-empty value")]
        public void Property_Should_Throw_When_TitleChangedWithWhiteSpace()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Title = "   ";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "value too short")]
        public void Property_Should_Throw_When_TitleChangedWithShortValue()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Title = new string('a', 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "value too long")]
        public void Property_Should_Throw_When_TitleChangedWithLongValue()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Title = new string('a', 40);
        }

        [TestMethod]
        public void Property_Should_ChangeAssignee()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            string newValidAssignee = "New Valid Assignee";
            task.Assignee = newValidAssignee;

            //Assert
            Assert.AreEqual(newValidAssignee, task.Assignee, "assignee should match");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "please provide a non-null value")]
        public void Property_Should_Throw_When_AssigneeChangedWithNull()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Assignee = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "please provide a non-empty value")]
        public void Property_Should_Throw_When_AssigneeChangedWithWhiteSpace()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Assignee = "   ";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "value too short")]
        public void Property_Should_Throw_When_AssigneeChangedWithShortValue()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Assignee = new string('a', 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "value too long")]
        public void Property_Should_Throw_When_AssigneeChangedWithLongValue()
        {
            //Arrange

            string validTitle = "Valid Title";
            string validAssignee = "Valid Assignee";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validAssignee, validDueDate);
            task.Assignee = new string('a', 40);
        }

        [TestMethod]
        public void AdvanceStatus_Should_Advance_When_StatusIsToDo()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task= new Task(validTitle, validDescription, validDueDate);
            task.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.InProgress, task.Status);
        }

        [TestMethod]
        public void AdvanceStatus_Should_NotAdvance_When_StatusIsVerified()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validDescription, validDueDate);

            for (int i = 0; i < 7; i++)
            {
                task.AdvanceStatus();
            }

            //Assert
            Assert.AreEqual(Status.Verified, task.Status);
        }

        [TestMethod]
        public void RevertStatus_Should_Revert_When_StatusIsVerified()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act & Assert
            Task task = new Task(validTitle, validDescription, validDueDate);

            task.AdvanceStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();
            Assert.AreEqual(Status.Verified, task.Status);

            task.RevertStatus();            
            Assert.AreEqual(Status.Done, task.Status);
        }

        [TestMethod]
        public void RevertStatus_Should_NotRevert_When_StatusIsToDo()
        {
            //Arrange
            string validTitle = "Valid Title";
            string validDescription = "Valid Description";
            DateTime validDueDate = Convert.ToDateTime("01-01-2025");

            //Act
            Task task = new Task(validTitle, validDescription, validDueDate);
            task.RevertStatus();

            //Assert
            Assert.AreEqual(Status.Todo, task.Status);
        }
    }
}
