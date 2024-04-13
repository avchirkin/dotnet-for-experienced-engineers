
namespace ExplicitAndImplicitCasting
{
    internal class ExplicitlyStringableStudent
    {
        public string Name { get; set; }

        public ExplicitlyStringableStudent(string name)
        {
            Name = name;
        }

        public static explicit operator string(ExplicitlyStringableStudent student)
        {
            return student.Name;
        }

        public static explicit operator ExplicitlyStringableStudent(string value)
        {
            return new ExplicitlyStringableStudent(value);
        }
    }
}
