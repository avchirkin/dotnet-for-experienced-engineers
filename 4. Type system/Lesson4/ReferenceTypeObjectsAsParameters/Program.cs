using ReferenceTypeObjectsAsParameters;

var student = new Student("Ivan");
ChangeStudentName(student, "Vladimir");
Console.WriteLine(student.Name); // Vladimir

Console.ReadLine();

ChangeStudent(student);
Console.WriteLine(student.Name); // ВОПРОС - что выведется на консоль?

Console.ReadLine();

student = ChangeStudentAgain(student);
Console.WriteLine(student.Name); // ВОПРОС - что выведется на консоль?


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

