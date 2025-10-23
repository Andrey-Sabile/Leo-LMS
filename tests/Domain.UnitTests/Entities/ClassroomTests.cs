using System.Collections.Generic;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace LeoLMS.Domain.UnitTests.Entities;

public class ClassroomTests
{
    [Test]
    public void AddStudent_AddsToClassroomAndStudent()
    {
        var classroom = CreateClassroom();
        var student = CreateStudent();

        classroom.AddStudent(student);

        classroom.Students.ShouldContain(student);
        student.Classrooms.ShouldContain(classroom);
    }

    [Test]
    public void RemoveStudent_RemovesFromClassroomAndStudent()
    {
        var classroom = CreateClassroom();
        var student = CreateStudent();
        classroom.AddStudent(student);

        classroom.RemoveStudent(student);

        classroom.Students.ShouldNotContain(student);
        student.Classrooms.ShouldNotContain(classroom);
    }

    [Test]
    public void AddTeacher_AddsToClassroomAndTeacher()
    {
        var classroom = CreateClassroom();
        var teacher = CreateTeacher();

        classroom.AddTeacher(teacher);

        classroom.Teachers.ShouldContain(teacher);
        teacher.Classrooms.ShouldContain(classroom);
    }

    [Test]
    public void RemoveTeacher_RemovesFromClassroomAndTeacher()
    {
        var classroom = CreateClassroom();
        var teacher = CreateTeacher();
        classroom.AddTeacher(teacher);

        classroom.RemoveTeacher(teacher);

        classroom.Teachers.ShouldNotContain(teacher);
        teacher.Classrooms.ShouldNotContain(classroom);
    }

    private static Classroom CreateClassroom()
    {
        var classroom = Classroom.Create("Math 101", 1, 10, "Introductory course");
        classroom.Id = 100;
        return classroom;
    }

    private static Student CreateStudent()
    {
        var address = Address.Create("123 Main St", "Unit 1", "Metropolis", "NY", 12345, "USA");
        var student = Student.Create("John", "Doe", "john.doe@example.com", address);
        student.Id = 200;
        return student;
    }

    private static Teacher CreateTeacher()
    {
        var address = Address.Create("456 Elm St", "Suite 2", "Gotham", "NJ", 54321, "USA");
        var teacher = Teacher.Create("Jane", "Smith", "jane.smith@example.com", 5551234, address, new List<Classroom>());
        teacher.Id = 300;
        return teacher;
    }
}
