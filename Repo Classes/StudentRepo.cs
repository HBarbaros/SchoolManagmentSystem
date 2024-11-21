using System;
using System.Collections.Generic;
using Dapper;

public class StudentRepo : DapperRepo<Student>
{
    public StudentRepo(DatabaseConnection databaseConnection) : base(databaseConnection) { }

    public IEnumerable<Student> GetAllStudents()
    {
        return GetAll("Students");
    }

    public Student GetStudentById(int id)
    {
        return GetById(id, "Students");
    }

    public bool AddStudent(Student student)
    {
        string insertSql = "INSERT INTO Students (Name, BirthDate, HouseId) VALUES (@Name, @BirthDate, @HouseId )";
        try
        {
            Add(insertSql, student);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding student: {ex.Message}");
            return false;
        }
    }

    public bool UpdateStudent(Student student)
    {
        string updateSql = "UPDATE Students SET Name = @Name, BirthDate = @BirthDate, HouseId = @HouseId, WHERE Id = @Id";
        try
        {
            Update(updateSql, student);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating student: {ex.Message}");
            return false;
        }
    }

    public bool DeleteStudent(int id)
    {
        try
        {
            Delete(id, "Students");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting student: {ex.Message}");
            return false;
        }
    }

    public IEnumerable<Student> GetStudentsByHouse(int houseId)
    {
        return GetAllByCondition("Students", "HouseId = @HouseId", new { HouseId = houseId });
    }
}
