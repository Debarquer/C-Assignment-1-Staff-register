using StaffRegister;

namespace StaffRegisterTest
{
    [TestClass]
    public class EmployeeManagerTests
    {
        [TestMethod]
        public void TestSaveFile()
        {
            EmployeeManager employeeManager = new();

            if(File.Exists(employeeManager.SaveFilePath)) File.Delete(employeeManager.SaveFilePath);

            employeeManager.SaveFile();

            Assert.IsTrue(File.Exists(employeeManager.SaveFilePath));
        }

        [TestMethod]
        public void AddEmployeeTest()
        {
            EmployeeManager employeeManager = new();
            int nrOfEmloyeesAtStart = employeeManager.NrOfEmployees;
            employeeManager.AddEmployee("est", 0);
            Assert.AreEqual(nrOfEmloyeesAtStart + 1, employeeManager.NrOfEmployees);
        }

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
    }
}