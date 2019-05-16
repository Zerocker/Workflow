using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class EmployeeTest
    {
        private Lab.Employee Subject = new Lab.Employee();

        [TestMethod]
        public void ID_1()
        {
            try
            {
                Subject.ID = "1";
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got: {ex.Message}");
            }
        }

        [TestMethod]
        public void ID_Neg_1()
        {
            Assert.ThrowsException<Exception>(() => Subject.ID = "-1");
        }

        [TestMethod]
        public void ID_NotNumber()
        {
            Assert.ThrowsException<Exception>(() => Subject.ID = "DEAD");
        }

        [TestMethod]
        public void Job_Employee()
        {
            try
            {
                Subject.Job = "SA_MAN";
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got: {ex.Message}");
            }
        }

        [TestMethod]
        public void Job_NotEmployee()
        {
            Assert.ThrowsException<Exception>(() => Subject.Job = "Me");
        }

        [TestMethod]
        public void Mail_Example()
        {
            try
            {
                Subject.Mail = "example@admin.com";
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got: {ex.Message}");
            }
        }

        [TestMethod]
        public void Mail_ContainsMail()
        {
            Assert.ThrowsException<Exception>(() => Subject.Mail = "here is my mail: example@admin.com");
        }

        [TestMethod]
        public void Hiredate_Example()
        {
            try
            {
                Subject.HireDate = "29.01.2011 12:00";
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got: {ex.Message}");
            }
        }

        [TestMethod]
        public void Hiredate_LostInTime()
        {
            Assert.ThrowsException<Exception>(() => Subject.HireDate = "32.04.1001 25:61");
        }
    }
}
