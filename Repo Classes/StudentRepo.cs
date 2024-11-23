using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

public class StudentRepo
{
    private readonly DatabaseConnection _databaseConnection;

    // Constructor: DatabaseConnection sınıfını alır.
    public StudentRepo(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    // Yeni bir öğrenci ekler.
    public void AddStudent(Student student)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "INSERT INTO Students (Name, BirthDate, HouseId) VALUES (@Name, @BirthDate, @HouseId)";
            connection.Execute(sql, student);
        }
    }

    // Tüm öğrencileri listeleyen sorgu.
    public List<Student> GetAllStudents()
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "SELECT * FROM Students";
            return connection.Query<Student>(sql).AsList();
        }
    }

    // Belirli bir öğrenci ID'sine göre öğrenci döndürür.
    public Student GetStudentById(int id)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "SELECT * FROM Students WHERE Id = @Id";
            return connection.QuerySingleOrDefault<Student>(sql, new { Id = id });
        }
    }

    // Bir öğrenciyi günceller.
    public void UpdateStudent(Student student)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "UPDATE Students SET Name = @Name, BirthDate = @BirthDate, HouseId = @HouseId WHERE Id = @Id";
            connection.Execute(sql, student);
        }
    }

    // Bir öğrenciyi siler.
    public bool DeleteStudent(int id)
    {
        using (var connection = _databaseConnection.CreateConnection())
        {
            string sql = "DELETE FROM Students WHERE Id = @Id";
            int rowsAffected = connection.Execute(sql, new { Id = id });

            // Etkilenen satır sayısına göre silme işleminin başarılı olup olmadığını döner.
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
