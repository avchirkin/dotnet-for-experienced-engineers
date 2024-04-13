using ValueTypeObjectsAsParameters;

var student = new Student("Ivan");
ChangeStudentName(student, "Vladimir"); // Передаётся копия объекта!
Console.WriteLine(student.Name); // Ivan

Console.ReadLine();

ChangeStudent(student);
Console.WriteLine(student.Name); // Ivan

Console.ReadLine();

student = ChangeStudentAgain(student);
Console.WriteLine(student.Name); // Petr


void ChangeStudentName(Student student, string newName)
{
    student.Name = newName;
}

void ChangeStudent(Student student)
{
    student = new Student("Petr");
}

Student ChangeStudentAgain(Student student)
{
    student = new Student("Petr");
    return student;
}
