namespace HW_L3_Q2;

class Person
{
    // Common person properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Create person object
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Return person information
    public virtual string GetDetails()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

// Represents student information
class Student : Person
{
    // Student specific data
    public int StudentID { get; set; }
    public string Major { get; set; }

    // Create student object
    public Student(
        string name,
        int age,
        int studentId,
        string major
    ) : base(name, age)
    {
        StudentID = studentId;
        Major = major;
    }

    // Override student details
    public override string GetDetails()
    {
        return base.GetDetails() +
               $", ID: {StudentID}, Major: {Major}";
    }
}

// Represents professor information
class Professor : Person
{
    // Professor specific data
    public int ProfessorId { get; set; }
    public string Subject { get; set; }

    // Create professor object
    public Professor(
        string name,
        int age,
        int professorId,
        string subject
    ) : base(name, age)
    {
        ProfessorId = professorId;
        Subject = subject;
    }

    // Override professor details
    public override string GetDetails()
    {
        return base.GetDetails() +
               $", ID: {ProfessorId}, Subject: {Subject}";
    }
}


class Question2
{
    public static void Q2()
    {
        // Store all persons
        List<Person> people = new List<Person>();

        // Add student object
        people.Add(
            new Student(
                "Ali",
                20,
                1001,
                "Computer Engineering"
            )
        );

        // Add professor object
        people.Add(
            new Professor(
                "Dr Smith",
                45,
                5001,
                "Programming"
            )
        );

        // Display all details
        foreach (Person person in people)
        {
            Console.WriteLine(
                person.GetDetails()
            );
        }
    }
}