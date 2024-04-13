using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeObjectsAsParameters
{
    internal struct Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }
    }
}
