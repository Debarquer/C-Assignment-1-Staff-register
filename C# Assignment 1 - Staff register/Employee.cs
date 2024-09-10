using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAssignment_1Staff_register
{
    internal class Employee(string name, int salary)
    {
        public string Name { get; private set; } = name;
        public int Salary { get; private set; } = salary;
    }
}
