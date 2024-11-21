using System.Collections.Generic;
using Dapper;

public class GradeRepo : DapperRepo<Grade>
{
    public GradeRepo(DatabaseConnection databaseConnection) : base(databaseConnection) { }

    // Add a new grade
    public bool AddGrade(Grade grade)
    {
        string sql = "INSERT INTO Grades (StudentID, CourseID, Value) VALUES (@StudentID, @CourseID, @Value)";
        try
        {
            Add(sql, grade);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Update an existing grade
    public bool UpdateGrade(Grade grade)
    {
        string sql = "UPDATE Grades SET Value = @Value WHERE Id = @Id";
        try
        {
            Update(sql, grade);
            return true;
        }
        catch
        {
            return false;
        }
    }

  public bool DeleteGrade(int id)
    {
        try
        {
            DeleteGrade(id);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting grade: {ex.Message}");
            return false;
        }
    }

    // Retrieve all grades
    public IEnumerable<Grade> GetAllGrades()
    {
        return GetAll("Grades");
    }

    // Retrieve all grades for a specific student
    public IEnumerable<Grade> GetGradesByStudent(int studentId)
    {
        return GetAllByCondition("Grades", "StudentID = @StudentID", new { StudentID = studentId });
    }

    // Retrieve all grades for a specific course
    public IEnumerable<Grade> GetGradesByCourse(int courseId)
    {
        return GetAllByCondition("Grades", "CourseID = @CourseID", new { CourseID = courseId });
    }
}