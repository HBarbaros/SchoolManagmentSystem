using System;

public class GradeUI
{
    private GradeRepo _gradeRepo;

    public GradeUI(GradeRepo gradeRepo)
    {
        _gradeRepo = gradeRepo;
    }

    public void AddGrade()
    {
        int studentId;
        while (true)
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out studentId) && studentId > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid student ID.");
        }

        int courseId;
        while (true)
        {
            Console.Write("Enter course ID: ");
            if (int.TryParse(Console.ReadLine(), out courseId) && courseId > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid course ID.");
        }

        string value;
        while (true)
        {
            Console.Write("Enter grade value (e.g., A, B, C): ");
            value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                break;

            Console.WriteLine("Invalid input. Please enter a valid grade value.");
        }

        var grade = new Grade { StudentID = studentId, Id = courseId, Value = value };
        if (_gradeRepo.AddGrade(grade))
            Console.WriteLine("Grade added successfully.");
        else
            Console.WriteLine("Error adding grade.");
    }

    public void UpdateGrade()
    {
        int gradeId;
        while (true)
        {
            Console.Write("Enter the grade ID to update: ");
            if (int.TryParse(Console.ReadLine(), out gradeId) && gradeId > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid grade ID.");
        }

        string value;
        while (true)
        {
            Console.Write("Enter new grade value (e.g., A, B, C): ");
            value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                break;

            Console.WriteLine("Invalid input. Please enter a valid grade value.");
        }

        var grade = new Grade { Id = gradeId, Value = value };
        if (_gradeRepo.UpdateGrade(grade))
            Console.WriteLine("Grade updated successfully.");
        else
            Console.WriteLine("Error updating grade.");
    }

    public void DeleteGrade()
    {
        int gradeId;
        while (true)
        {
            Console.Write("Enter the grade ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out gradeId) && gradeId > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid grade ID.");
        }

        if (_gradeRepo.DeleteGrade(gradeId))
            Console.WriteLine("Grade deleted successfully.");
        else
            Console.WriteLine("Error deleting grade.");
    }

    public void ShowAllGrades()
    {
        var grades = _gradeRepo.GetAllGrades();
        Console.WriteLine("List of Grades:");
        foreach (var grade in grades)
        {
            Console.WriteLine($"Id: {grade.Id}, StudentID: {grade.StudentID}, Value: {grade.Value}");
        }
    }

    public void ShowGradesByStudent()
    {
        int studentId;
        while (true)
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out studentId) && studentId > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid student ID.");
        }

        var grades = _gradeRepo.GetGradesByStudent(studentId);
        Console.WriteLine($"Grades for Student ID: {studentId}");
        foreach (var grade in grades)
        {
            Console.WriteLine($"CourseID: {grade.Id}, Value: {grade.Value}");
        }
    }

    public void ShowGradesByCourse()
    {
        int courseId;
        while (true)
        {
            Console.Write("Enter course ID: ");
            if (int.TryParse(Console.ReadLine(), out courseId) && courseId > 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid course ID.");
        }

        var grades = _gradeRepo.GetGradesByCourse(courseId);
        Console.WriteLine($"Grades for Course ID: {courseId}");
        foreach (var grade in grades)
        {
            Console.WriteLine($"StudentID: {grade.StudentID}, Value: {grade.Value}");
        }
    }
}