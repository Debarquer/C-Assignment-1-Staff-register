namespace CAssignment_1Staff_register
{
    internal class Employee(string name, int salary)
    {
        public string Name { get; private set; } = name;
        public int Salary { get; private set; } = salary;
    }
}
