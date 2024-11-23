using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

public class StudentRepo
{
    private readonly DatabaseConnection _databaseConnection;

    public StudentRepo(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public void AddStudent(Student student)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "INSERT INTO Students (Name, BirthDate, HouseId) VALUES (@Name, @BirthDate, @HouseId)";
            connection.Execute(sql, student);
        }
    }

    public List<Student> GetAllStudents()
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "SELECT * FROM Students";
            return connection.Query<Student>(sql).AsList();
        }
    }

    public Student GetStudentById(int id)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "SELECT * FROM Students WHERE Id = @Id";
            return connection.QuerySingleOrDefault<Student>(sql, new { Id = id });
        }
    }

    public void UpdateStudent(Student student)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "UPDATE Students SET Name = @Name, BirthDate = @BirthDate, HouseId = @HouseId WHERE Id = @Id";
            connection.Execute(sql, student);
        }
    }

    public bool DeleteStudent(int id)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "DELETE FROM Students WHERE Id = @Id";
            int rowsAffected = connection.Execute(sql, new { Id = id });

            return rowsAffected > 0;
        }
    }

    public List<Student> GetStudentsByHouse(int houseId)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "SELECT * FROM Students WHERE HouseId = @HouseId";
            return connection.Query<Student>(sql, new { HouseId = houseId }).AsList();
        }
    }

}
