
namespace ExplicitAndImplicitCasting
{
    internal class ImplicitlyStringableStudent
    {
        public string Name { get; set; }

        public ImplicitlyStringableStudent(string name)
        {
            Name = name;
        }

        public static implicit operator string(ImplicitlyStringableStudent student)
        {
            return student.Name;
        }

        public static implicit operator ImplicitlyStringableStudent(string value)
        {
            return new ImplicitlyStringableStudent(value);
        }
    }
}
