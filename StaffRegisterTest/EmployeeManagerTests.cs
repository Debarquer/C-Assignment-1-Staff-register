using StaffRegister;

namespace StaffRegisterTest
{
    [TestClass]
    public class EmployeeManagerTests
    {
        /// <summary>
        /// Verifies if calling SaveFile produces a file at SaveFilePath.
        /// </summary>
        [TestMethod]
        public void TestSaveFile()
        {
            EmployeeManager employeeManager = new();

            if(File.Exists(employeeManager.SaveFilePath)) File.Delete(employeeManager.SaveFilePath);

            employeeManager.SaveFile();

            Assert.IsTrue(File.Exists(employeeManager.SaveFilePath));
        }

        /// <summary>
        /// Verifies if calling AddEmployee increments employeeManager.NrOfEmployees.
        /// </summary>
        [TestMethod]
        public void AddEmployeeTest()
        {
            EmployeeManager employeeManager = new();
            int nrOfEmloyeesAtStart = employeeManager.NrOfEmployees;

            employeeManager.AddEmployee("test", 0);

            Assert.AreEqual(nrOfEmloyeesAtStart + 1, employeeManager.NrOfEmployees);
        }

        /// <summary>
        /// Verifies if calling LoadFile on an empty SaveFilePath produces an exception.
        /// </summary>
        [TestMethod()]
        public void TestLoadFileFail()
        {
            EmployeeManager employeeManager = new();
            employeeManager.SaveFilePath = "";

            try
            {
                employeeManager.LoadFile();
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail("Loading empty file did not throw an exception.");
        }

        /// <summary>
        /// Verifies if calling employeeManager.ContainsOnlyLetters on a string containing only letters returns true.
        /// </summary>
        [TestMethod()]
        public void TestOnlyLetters()
        {
            EmployeeManager employeeManager = new();
            string s = "abc";

            bool onlyLetters = employeeManager.ContainsOnlyLetters(s);

            Assert.IsTrue(onlyLetters);
        }

        /// <summary>
        /// Verifies if calling employeeManager.ContainsOnlyLetters on a string containing letters and numbers returns false.
        /// </summary>
        [TestMethod()]
        public void TestOnlyLettersFail()
        {
            EmployeeManager employeeManager = new();
            string s = "abc123";

            bool onlyLetters = employeeManager.ContainsOnlyLetters(s);

            Assert.IsFalse(onlyLetters);
        }
    }
}